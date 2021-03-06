using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Sholo.HomeAssistant.Client.Events;
using Sholo.HomeAssistant.Client.Exceptions;
using Sholo.HomeAssistant.Client.Internal.Callbacks;
using Sholo.HomeAssistant.Client.Internal.Subscriptions;
using Sholo.HomeAssistant.Client.Messages;
using Sholo.HomeAssistant.Client.Messages.Authentication;
using Sholo.HomeAssistant.Client.Messages.Heartbeats;
using Sholo.HomeAssistant.Client.Messages.Subscriptions;
using Sholo.HomeAssistant.Client.Settings;
using Sholo.HomeAssistant.Client.StateDeserializers;
using Sholo.HomeAssistant.Client.WebSockets.BackgroundService;
using Sholo.HomeAssistant.Serialization;
using Sholo.HomeAssistant.Validation;

namespace Sholo.HomeAssistant.Client.WebSockets.ConnectionService
{
    public class HomeAssistantWebSocketsConnectionService : IHomeAssistantWebSocketsConnectionService
    {
        public ManualResetEventSlim OnlineEvent { get; } = new ManualResetEventSlim(false);
        public IObservable<IEventMessage> EventMessages { get; }
        public IObservable<WebsocketsConnectionState> ConnectionStateChanges { get; }

        private IValidator Validator { get; }
        private IOptionsMonitor<HomeAssistantClientOptions> HomeAssistantOptions { get; }
        private IStateProvider StateProvider { get; }
        private ILogger Logger { get; }

        private JsonSerializerSettings JsonSerializerSettings { get; }
        private JsonSerializer JsonSerializer { get; }

        private ISubject<IEventMessage> EventMessageSubject { get; } = new Subject<IEventMessage>();
        private ISubject<WebsocketsConnectionState> ConnectionStateChangesSubject { get; } = new Subject<WebsocketsConnectionState>();
        private ConcurrentDictionary<long, ISubscription> SubscriptionsById { get; } = new ConcurrentDictionary<long, ISubscription>();
        private ConcurrentDictionary<long, IMessageCallback> OutstandingCommands { get; } = new ConcurrentDictionary<long, IMessageCallback>();
        private BlockingCollection<IMessageCallback> PendingCommands { get; } = new BlockingCollection<IMessageCallback>();

        private (WebSocketsClientServicePhase Original, WebSocketsClientServicePhase Current)[] ValidStateTransitions { get; } =
        {
            (WebSocketsClientServicePhase.Offline, WebSocketsClientServicePhase.AuthenticationRequired),
            (WebSocketsClientServicePhase.AuthenticationRequired, WebSocketsClientServicePhase.Online),
            (WebSocketsClientServicePhase.AuthenticationRequired, WebSocketsClientServicePhase.Offline),
            (WebSocketsClientServicePhase.Online, WebSocketsClientServicePhase.AuthenticationRequired),
            (WebSocketsClientServicePhase.Online, WebSocketsClientServicePhase.Offline)
        };

        private int _phase;
        private long _connectionId;
        private long _sequenceNumber;

        private WebSocketsClientServicePhase Phase
        {
            // ReSharper disable once UnusedMember.Local
            get => (WebSocketsClientServicePhase)Interlocked.CompareExchange(ref _phase, 0, 0);
            set
            {
                var originalValue = (WebSocketsClientServicePhase)Interlocked.Exchange(ref _phase, (int)value);

                if (!ValidStateTransitions.Any(x => x.Original == originalValue && x.Current == value) && originalValue != value)
                {
                    Interlocked.Exchange(ref _phase, (int)originalValue);
                    throw new InvalidOperationException($"Illegal phase transition (from {originalValue} to {value})");
                }

                Logger.LogDebug("Phase changed from {originalValue} to {currentValue}", originalValue, value);

                if (value == WebSocketsClientServicePhase.Online)
                {
                    OnlineEvent.Set();
                    ConnectionStateChangesSubject.OnNext(WebsocketsConnectionState.Online);
                }
                else if (value == WebSocketsClientServicePhase.Offline)
                {
                    var connectionId = Interlocked.Increment(ref _connectionId);
                    Logger.LogDebug("Incrementing connectionId to {connectionId}", connectionId);

                    OnlineEvent.Reset();
                    ConnectionStateChangesSubject.OnNext(WebsocketsConnectionState.Offline);
                }
            }
        }

        private long GetConnectionId() => Interlocked.Read(ref _connectionId);

        private enum WebSocketsClientServicePhase
        {
            Offline,
            AuthenticationRequired,
            Online
        }

        public HomeAssistantWebSocketsConnectionService(
            IValidator validator,
            IOptionsMonitor<HomeAssistantClientOptions> homeAssistantOptions,
            IStateProvider stateProvider,
            ILogger<HomeAssistantWebSocketsClientBackgroundService> logger)
        {
            JsonSerializerSettings = HomeAssistantSerializerSettings.CreateJsonSerializerSettings(Formatting.None);
            JsonSerializer = JsonSerializer.Create(JsonSerializerSettings);

            EventMessages = EventMessageSubject.AsObservable();
            ConnectionStateChanges = ConnectionStateChangesSubject.AsObservable();

            Validator = validator;
            HomeAssistantOptions = homeAssistantOptions;
            StateProvider = stateProvider;
            Logger = logger;
        }

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                using var authenticated = new EventWaitHandle(false, EventResetMode.AutoReset);
                using var intervalCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

                var intervalCancellationToken = intervalCancellationTokenSource.Token;

                try
                {
                    using var webSocket = await ConnectAsync(cancellationToken);

                    // ReSharper disable AccessToDisposedClosure
                    var allTasks = new List<Task>();
                    var longRunningTasks = new List<Task>
                    {
                        Task.Run(async () => await DispatchMessages(webSocket, intervalCancellationToken), intervalCancellationToken),
                        Task.Run(async () => await ReceiveMessages(webSocket, authenticated, intervalCancellationToken), intervalCancellationToken)
                    };

                    allTasks.AddRange(longRunningTasks);

                    if (HomeAssistantOptions.CurrentValue.HealthChecks.Enabled)
                    {
                        longRunningTasks.Add(Task.Run(async () => await RestoreSubscriptionsAndPerformHealthChecks(authenticated, intervalCancellationToken), intervalCancellationToken));
                    }
                    else
                    {
                        allTasks.Add(Task.Run(async () => await RestoreSubscriptionsAndPerformHealthChecks(authenticated, intervalCancellationToken), intervalCancellationToken));
                    }

                    // ReSharper restore AccessToDisposedClosure
                    await Task.WhenAny(longRunningTasks);

                    intervalCancellationTokenSource.Cancel();

                    await Task.WhenAll(allTasks);
                }
                catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
                {
                    // The application is shutting down.
                    return;
                }
                catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
                {
                    // The interval completed for some reason or another.  Loop around again.
                }
                catch (HomeAssistantCriticalConnectionFailureException exc)
                {
                    Logger.LogCritical(exc, "Critical connection failure: {Message}", exc.Message);
                    throw;
                }
                catch (HomeAssistantCriticalConnectionHealthCheckException exc)
                {
                    Logger.LogCritical(exc, "Critical connection health check failure: {Message}", exc.Message);
                    throw;
                }
                catch (HomeAssistantConnectionHealthCheckException)
                {
                    Logger.LogWarning("Connection failed health checks.  Resetting connection");
                }
                catch (Exception exc)
                {
                    Logger.LogError(exc, "An unhandled error occurred: {Message}", exc.Message);
                    Logger.LogWarning("Resetting connection...");
                }

                Phase = WebSocketsClientServicePhase.Offline;
            }
        }

        public Task<TCommandResult> SendCommandAsync<TCommand, TCommandResult>(TCommand command, CancellationToken cancellationToken)
            where TCommand : BaseCommand
            => SendMessageAsync<TCommand, TCommandResult>(command, cancellationToken);

        public Task<SubscribeResult> SubscribeAsync(SubscribeCommand subscribeMessage, CancellationToken cancellationToken)
            => SendMessageAsync<SubscribeCommand, SubscribeResult>(subscribeMessage, cancellationToken);

        private async Task<ClientWebSocket> ConnectAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Connecting to HA at {WebSocketsUrl}...", HomeAssistantOptions.CurrentValue.WsUrl);
            ClientWebSocket webSocket = null;

            int connectionFailures = 0;
            while (!cancellationToken.IsCancellationRequested && HomeAssistantOptions.CurrentValue.ConnectionResiliency.Enabled)
            {
                try
                {
                    webSocket = new ClientWebSocket();
                    webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(5);

                    await webSocket.ConnectAsync(HomeAssistantOptions.CurrentValue.WsUrl, cancellationToken);
                    Logger.LogInformation("Connected to HA via WebSockets");
                    connectionFailures = 0;
                    break;
                }
                catch
                {
                    var intervalBetweenConnectionAttempts = HomeAssistantOptions.CurrentValue.ConnectionResiliency.IntervalBetweenConnectionAttempts;
                    Logger.LogDebug("Retrying HA connection in {Delay}...", intervalBetweenConnectionAttempts);

                    await Task.Delay(intervalBetweenConnectionAttempts, cancellationToken);
                    webSocket?.Dispose();

                    connectionFailures++;

                    var maximumAttemptsBeforeFailure = HomeAssistantOptions.CurrentValue.ConnectionResiliency.MaximumAttemptsBeforeFailure;
                    if (maximumAttemptsBeforeFailure.HasValue && connectionFailures == maximumAttemptsBeforeFailure.Value)
                    {
                        throw new HomeAssistantCriticalConnectionFailureException($"Failed to connect {maximumAttemptsBeforeFailure} times at {intervalBetweenConnectionAttempts} intervals to HA via WebSockets");
                    }
                }
            }

            return webSocket;
        }

        private async Task RestoreSubscriptionsAndPerformHealthChecks(WaitHandle authenticated, CancellationToken cancellationToken)
        {
            var missedHeartbeats = 0;
            authenticated.WaitOne();

            await RestoreSubscriptions(cancellationToken);

            if (HomeAssistantOptions.CurrentValue.HealthChecks.Enabled)
            {
                Logger.LogInformation("Health checking is online...");
                while (!cancellationToken.IsCancellationRequested && HomeAssistantOptions.CurrentValue.HealthChecks.Enabled)
                {
                    var healthCheckTimeout = HomeAssistantOptions.CurrentValue.HealthChecks.HealthCheckTimeout;
                    var healthCheckInterval = HomeAssistantOptions.CurrentValue.HealthChecks.HealthCheckInterval;
                    var consecutiveFailuresBeforeFailureAction = HomeAssistantOptions.CurrentValue.HealthChecks.ConsecutiveFailuresBeforeFailureAction;
                    var consecutiveHealthCheckFailureAction = HomeAssistantOptions.CurrentValue.HealthChecks.ConsecutiveHealthCheckFailureAction;

                    try
                    {
                        using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

                        cts.CancelAfter(healthCheckTimeout);

                        Logger.LogDebug("Sending ping command...");
                        await SendCommandAsync<PingCommand, PongResult>(new PingCommand(), cts.Token);
                        Logger.LogDebug("Received pong response");

                        missedHeartbeats = 0;

                        await Task.Delay(healthCheckInterval, cancellationToken);
                    }
                    catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
                    {
                        Logger.LogWarning("Server did not respond to ping request.");
                        missedHeartbeats++;

                        if (missedHeartbeats > consecutiveFailuresBeforeFailureAction)
                        {
                            if (consecutiveHealthCheckFailureAction == ConsecutiveHealthCheckFailureAction.Terminate)
                            {
                                throw new HomeAssistantCriticalConnectionHealthCheckException($"The websocket connection failed {consecutiveFailuresBeforeFailureAction} health checks at {healthCheckInterval} intervals.  Terminating.");
                            }
                            else
                            {
                                throw new HomeAssistantConnectionHealthCheckException($"The websocket connection failed {consecutiveFailuresBeforeFailureAction} health checks at {healthCheckInterval} intervals.  Reconnecting.");
                            }
                        }
                    }
                }
            }
            else
            {
                Logger.LogInformation("Health checks are disabled.");
            }
        }

        private async Task DispatchMessages(WebSocket webSocket, CancellationToken cancellationToken)
        {
            foreach (var callback in PendingCommands.GetConsumingEnumerable(cancellationToken))
            {
                OutstandingCommands.TryAdd(callback.Id, callback);
                await callback.Invoke(webSocket, cancellationToken);
            }
        }

        private async Task<UnsubscribeResult> UnsubscribeAsync(long connectionId, long subscriptionId, CancellationToken cancellationToken)
        {
            if (connectionId == GetConnectionId())
            {
                return await SendMessageAsync<UnsubscribeCommand, UnsubscribeResult>(new UnsubscribeCommand(subscriptionId), cancellationToken);
            }
            else
            {
                // The unsubscribe wasn't necessary because the connection it was WS created on is dead.  Return a success result
                return new UnsubscribeResult();
            }
        }

        private async Task<TMessageResult> SendMessageAsync<TMessage, TMessageResult>(TMessage message, CancellationToken cancellationToken)
            where TMessage : BaseMessageWithId
        {
            message.Id = Interlocked.Increment(ref _sequenceNumber);
            var callback = new MessageCallback<TMessage, TMessageResult>(
                message,
                (ws, ct) => SendSerialized(ws, message, ct),
                ReadAsMessage<TMessageResult>);
            PendingCommands.Add(callback, cancellationToken);
            return await callback.Task;
        }

        private async Task ReceiveMessages(WebSocket webSocket, EventWaitHandle authenticated, CancellationToken cancellationToken)
        {
            Logger.LogDebug("Listening for HA WebSocket messages...");
            var buffer = new ArraySegment<byte>(new byte[8192]);
            while (!cancellationToken.IsCancellationRequested)
            {
                using var ms = new MemoryStream();

                WebSocketReceiveResult result;
                do
                {
                    result = await webSocket.ReceiveAsync(buffer, cancellationToken);

                    if (buffer.Array == null)
                    {
                        throw new InvalidOperationException();
                    }

#if NETSTANDARD2_1
                    var memory = new ReadOnlyMemory<byte>(buffer.Array, buffer.Offset, result.Count);
                    await ms.WriteAsync(memory, cancellationToken);
#else
                    await ms.WriteAsync(buffer.Array, buffer.Offset, result.Count, cancellationToken);
#endif
                }
                while (!result.EndOfMessage);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var (messageType, id) = await GetMessageIdAndType(ms, cancellationToken);

                    if (id.HasValue)
                    {
                        Logger.LogDebug("Retrieved message of type {messageType}, Id {id}", messageType, id.Value);
                    }
                    else if (messageType != HomeAssistantWsMessageType.Pong)
                    {
                        Logger.LogDebug("Retrieved message of type {messageType}", messageType);
                    }

                    if (messageType == HomeAssistantWsMessageType.AuthRequired)
                    {
                        Phase = WebSocketsClientServicePhase.AuthenticationRequired;

                        Logger.LogError("Sending authentication payload");

                        await SendSerialized(
                            webSocket,
                            new AuthRequestMessage
                            {
                                AccessToken = HomeAssistantOptions.CurrentValue.Auth.Token
                            },
                            cancellationToken);
                    }
                    else if (messageType == HomeAssistantWsMessageType.AuthOk || messageType == HomeAssistantWsMessageType.AuthInvalid)
                    {
                        var authResult = await ReadAsMessage<AuthResultMessage>(ms, cancellationToken);
                        if (authResult.MessageType == HomeAssistantWsMessageType.AuthInvalid)
                        {
                            Logger.LogError($"Authentication failed: {authResult.Message}");
                            throw new HomeAssistantAuthenticationException(authResult.Message);
                        }
                        else if (authResult.MessageType == HomeAssistantWsMessageType.AuthOk)
                        {
                            Phase = WebSocketsClientServicePhase.Online;
                            authenticated.Set();
                            Logger.LogInformation("Authenticated successfully");
                        }
                        else
                        {
                            throw new InvalidOperationException($"Unexpected message type in auth response: {authResult.MessageType}");
                        }
                    }
                    else if (messageType == HomeAssistantWsMessageType.Event)
                    {
                        if (!id.HasValue)
                        {
                            throw new InvalidOperationException();
                        }

                        /*
                        EventMessage eventMessage;
                        if (SubscriptionsById.TryGetValue(id.Value, out var subscription))
                        {
                            eventMessage = await subscription.ParseMessage(ms, cancellationToken);
                        }
                        else
                        {
                            eventMessage = await ReadAsMessage<EventMessage>(ms, cancellationToken);
                        }

                        EventMessageSubject.OnNext(eventMessage);
                        */

                        await ProcessStateChangeMessage(ms, cancellationToken);
                    }
                    else if (id.HasValue)
                    {
                        if (OutstandingCommands.TryRemove(id.Value, out var callback))
                        {
                            await callback.HandleResult(ms, cancellationToken);
                        }
                        else
                        {
                            Logger.LogWarning("Received unexpected {MessageType} message with id {Id}", messageType, id.Value);
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"Expecting an Id for messages of type {messageType}");
                    }
                }
                else if (result.MessageType == WebSocketMessageType.Binary)
                {
                    // Not handled but don't throw for now
                    Logger.LogWarning("Received Binary message; not implemented");
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    // Not handled but don't throw for now
                    Logger.LogWarning("Server requested close");
                    return;
                }
            }
        }

        private async Task SendSerialized<TMessage>(WebSocket webSocket, TMessage objectToSerialize, CancellationToken cancellationToken)
            where TMessage : class
        {
            if (!Validator.Validate(objectToSerialize))
            {
                throw new InvalidOperationException("The outbound message is invalid");
            }

            var sb = new StringBuilder();
#if NETSTANDARD2_0
            using (var sw = new StringWriter(sb))
#else
            await using (var sw = new StringWriter(sb))
#endif
            {
                using var jw = new JsonTextWriter(sw);
                JsonSerializer.Serialize(jw, objectToSerialize);
            }

            var encoded = Encoding.UTF8.GetBytes(sb.ToString());
            var buffer = new ArraySegment<byte>(encoded, 0, encoded.Length);

            await webSocket.SendAsync(buffer, WebSocketMessageType.Text, true, cancellationToken);
        }

        private Task ProcessStateChangeMessage(Stream ms, CancellationToken cancellationToken)
        {
            Type messageType;
            using (var reader = new StreamReader(ms, Encoding.UTF8, false, 16384, true))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var jObject = JObject.Load(jsonReader);

                var eventObject = jObject["event"];
                var eventDataObject = eventObject?["data"];
                var entityIdObject = eventDataObject?["entity_id"];
                var newStateObject = eventDataObject?["new_state"];
                var newStateAttributesObject = newStateObject?["attributes"];

                if (entityIdObject != null && newStateAttributesObject != null)
                {
                    var entityId = entityIdObject.Value<string>() ?? throw new InvalidOperationException();

                    var attributes = newStateAttributesObject.HasValues
                        ? newStateAttributesObject.ToObject<Dictionary<string, object>>() ?? new Dictionary<string, object>()
                        : new Dictionary<string, object>();

                    messageType = StateProvider.GetStateChangeEventMessageType(entityId, attributes);
                }
                else
                {
                    return Task.CompletedTask;
                }
            }

            cancellationToken.ThrowIfCancellationRequested();
            ms.Seek(0, SeekOrigin.Begin);

            using (var reader = new StreamReader(ms, Encoding.UTF8, false, 16384, true))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var message = JsonSerializer.Deserialize(jsonReader, messageType);
                var eventMessage = (IEventMessage)message;

                EventMessageSubject.OnNext(eventMessage);
            }

            return Task.CompletedTask;
        }

        private Task<TMessage> ReadAsMessage<TMessage>(Stream ms, CancellationToken cancellationToken)
        {
            using var reader = new StreamReader(ms, Encoding.UTF8, false, 16384, true);
            using var jsonReader = new JsonTextReader(reader);
            var message = JsonSerializer.Deserialize<TMessage>(jsonReader);
            return Task.FromResult(message ?? throw new InvalidOperationException());
        }

        private async ValueTask<(HomeAssistantWsMessageType MessageType, long? Id)> GetMessageIdAndType(Stream ms, CancellationToken cancellationToken)
        {
            ms.Seek(0, SeekOrigin.Begin);

            using var reader = new StreamReader(ms, Encoding.UTF8, false, 16384, true);
            using var jsonReader = new JsonTextReader(reader);

            HomeAssistantWsMessageType? type = null;
            int? id = null;

            var objectDepth = 0;
            var state = ReaderState.NoExpectations;

            var enumConverter = new StringEnumConverter(new SnakeCaseNamingStrategy());

            while (await jsonReader.ReadAsync(cancellationToken))
            {
                if (jsonReader.TokenType == JsonToken.StartObject)
                {
                    objectDepth++;
                }
                else if (jsonReader.TokenType == JsonToken.EndObject)
                {
                    objectDepth--;
                }
                else if (objectDepth == 1 && jsonReader.TokenType == JsonToken.PropertyName && (jsonReader.Value?.ToString()?.Equals("id", StringComparison.Ordinal) ?? false))
                {
                    state = ReaderState.ExpectingIdValue;
                }
                else if (objectDepth == 1 && state == ReaderState.ExpectingIdValue && jsonReader.TokenType == JsonToken.Integer && int.TryParse(jsonReader.Value?.ToString() ?? string.Empty, out var idValue))
                {
                    id = idValue;
                    state = ReaderState.NoExpectations;
                }
                else if (objectDepth == 1 && jsonReader.TokenType == JsonToken.PropertyName && (jsonReader.Value?.ToString()?.Equals("type", StringComparison.Ordinal) ?? false))
                {
                    state = ReaderState.ExpectingTypeValue;
                }
                else if (objectDepth == 1 && state == ReaderState.ExpectingTypeValue && jsonReader.TokenType == JsonToken.String && jsonReader.Value != null)
                {
                    var typeObject = enumConverter.ReadJson(jsonReader, typeof(HomeAssistantWsMessageType), null, JsonSerializer);
                    type = (HomeAssistantWsMessageType?)typeObject ?? throw new InvalidOperationException("Unable to parse the message type");
                    state = ReaderState.NoExpectations;
                }
                else if (state == ReaderState.ExpectingIdValue || state == ReaderState.ExpectingIdValue)
                {
                    throw new InvalidOperationException();
                }

                if (type.HasValue)
                {
                    // The examples show the id attribute coming before the type attribute.  If that holds up, then either we already have
                    // an id or there isn't going to be one.  Short circuit out.  Fingers crossed this optimization is worth the headaches
                    break;
                }
            }

            ms.Seek(0, SeekOrigin.Begin);

            if (!type.HasValue)
            {
                throw new InvalidOperationException("Unable to identify message type");
            }

            return (type.Value, id);
        }

        private enum ReaderState
        {
            ExpectingIdValue,
            ExpectingTypeValue,
            NoExpectations
        }

        public async IAsyncEnumerable<TEventMessage> Subscribe<TEventMessage>(
            string eventType = null,
            Func<TEventMessage, bool> predicate = null,
            [EnumeratorCancellation] CancellationToken cancellationToken = default
        )
            where TEventMessage : IEventMessage
        {
            var localId = Guid.NewGuid();
            var subscribeCommand = new SubscribeCommand(eventType);
            var subscribeResult = await SubscribeAsync(subscribeCommand, cancellationToken);
            var subscriptionId = subscribeResult.Id;

            var subscription = (Subscription<TEventMessage>)SubscriptionsById.GetOrAdd(subscribeResult.Id, lid =>
            {
                var sub = new Subscription<TEventMessage>(
                    localId,
                    eventType,
                    subscriptionId,
                    em => em.Where(x => predicate?.Invoke(x) ?? true),
                    ReadAsMessage<TEventMessage>,
                    UnsubscribeAsync
                );

                return sub;
            });

            var connectionId = GetConnectionId();
            subscription.Bind(EventMessages, connectionId, subscriptionId, cancellationToken);

            await foreach (var message in subscription.WithCancellation(cancellationToken))
            {
                cancellationToken.ThrowIfCancellationRequested();
                yield return message;
            }
        }

        public IAsyncEnumerable<IEventMessage> Subscribe(
            string eventType = null,
            Func<IEventMessage, bool> predicate = null,
            CancellationToken cancellationToken = default
        )
            => Subscribe<IEventMessage>(eventType, predicate, cancellationToken);

        private async Task RestoreSubscriptions(CancellationToken cancellationToken)
        {
            var subscriptionsSnapshot = SubscriptionsById.ToArray();
            if (subscriptionsSnapshot.Length > 0)
            {
                Logger.LogInformation("Restoring {SubscriptionCount} subscriptions...", subscriptionsSnapshot.Length);

                var newConnectionId = GetConnectionId();
                foreach (var subscriptionValue in subscriptionsSnapshot)
                {
                    var subscription = subscriptionValue.Value;

                    var subscribeResult = await SubscribeAsync(new SubscribeCommand(subscription.EventType), cancellationToken);
                    var originalSubscriptionId = subscription.CurrentSubscriptionId;
                    var newSubscriptionId = subscribeResult.Id;

                    subscription.Bind(EventMessages, newConnectionId, newSubscriptionId, cancellationToken);

                    if (subscription.EventType != null)
                    {
                        Logger.LogInformation(
                            "Replaced subscription {OriginalSubscriptionId} for {EventType} with {NewSubscriptionId}",
                            originalSubscriptionId,
                            subscription.EventType,
                            newSubscriptionId
                        );
                    }
                    else
                    {
                        Logger.LogInformation(
                            "Replaced subscription {OriginalSubscriptionId} with {NewSubscriptionId}",
                            originalSubscriptionId,
                            newSubscriptionId
                        );
                    }
                }

                // TODO: There may be a race condition.  Ideally we'd want to prevent non-subscription related request+response
                // after authenticating new connection before processing requests.  This may not be an issue b/c new connection won't
                // have any incoming messages.

                SubscriptionsById.Clear();

                foreach (var subscriptionValue in subscriptionsSnapshot)
                {
                    var subscription = subscriptionValue.Value;

                    var addedSuccessfully = SubscriptionsById.TryAdd(subscription.CurrentSubscriptionId, subscription);
                    if (!addedSuccessfully)
                    {
                        Logger.LogWarning("Failed to register replaced subscription");
                    }
                }
            }
        }
    }
}
