using Sholo.HomeAssistant.Client.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets.Events;
using Sholo.HomeAssistant.Client.WebSockets.Messages;

namespace Sholo.HomeAssistant.Client.Http.WebSockets.ConnectionService;

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
