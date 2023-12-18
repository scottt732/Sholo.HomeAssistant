using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Sholo.HomeAssistant.Client.Http.WebSockets.ConnectionService;
using Sholo.HomeAssistant.Client.WebSockets.Events;
using Sholo.HomeAssistant.Client.WebSockets.Messages;

namespace Sholo.HomeAssistant.Client.WebSockets.ConnectionService;

[PublicAPI]
public interface IHomeAssistantWebSocketsConnectionService
{
    ManualResetEventSlim OnlineEvent { get; }
    IObservable<WebsocketsConnectionState> ConnectionStateChanges { get; }
    IObservable<IEventMessage> EventMessages { get; }
    WebSocketsClientServicePhase Phase { get; }

    Task RunAsync(CancellationToken cancellationToken);

    Task<TCommandResult> SendCommandAsync<TCommand, TCommandResult>(TCommand command, CancellationToken cancellationToken)
        where TCommand : BaseCommand;

    Task<TEventMessage> SendCommandAndWaitForEventAsync<TCommand, TCommandResult, TEventMessage>(TCommand command, float? timeout = null, CancellationToken cancellationToken = default)
        where TCommand : BaseCommand
        where TCommandResult : BaseCommandResult
        where TEventMessage : IEventMessage;

    IAsyncEnumerable<TEventMessage> SendCommandAndSubscribeEventsAsync<TCommand, TCommandResult, TEventMessage>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : BaseCommand
        where TCommandResult : BaseCommandResult
        where TEventMessage : IEventMessage;

    IAsyncEnumerable<IEventMessage> SubscribeAsync(
        string? eventType = null,
        Func<IEventMessage, bool>? predicate = null,
        CancellationToken cancellationToken = default
    );

    IAsyncEnumerable<TEventMessage> SubscribeAsync<TEventMessage>(
        string? eventType = null,
        Func<TEventMessage, bool>? predicate = null,
        CancellationToken cancellationToken = default
    )
        where TEventMessage : IEventMessage;
}
