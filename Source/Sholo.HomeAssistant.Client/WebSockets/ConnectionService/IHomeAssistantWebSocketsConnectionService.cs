using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Sholo.HomeAssistant.Client.Events;
using Sholo.HomeAssistant.Client.Messages;

namespace Sholo.HomeAssistant.Client.WebSockets.ConnectionService
{
    [PublicAPI]
    public interface IHomeAssistantWebSocketsConnectionService
    {
        ManualResetEventSlim OnlineEvent { get; }
        IObservable<WebsocketsConnectionState> ConnectionStateChanges { get; }
        IObservable<IEventMessage> EventMessages { get; }

        Task RunAsync(CancellationToken cancellationToken);

        Task<TCommandResult> SendCommandAsync<TCommand, TCommandResult>(TCommand command, CancellationToken cancellationToken)
            where TCommand : BaseCommand;

        IAsyncEnumerable<IEventMessage> Subscribe(
            string eventType = null,
            Func<IEventMessage, bool> predicate = null,
            CancellationToken cancellationToken = default
        );

        IAsyncEnumerable<TEventMessage> Subscribe<TEventMessage>(
            string eventType = null,
            Func<TEventMessage, bool> predicate = null,
            CancellationToken cancellationToken = default
        )
            where TEventMessage : IEventMessage;
    }
}
