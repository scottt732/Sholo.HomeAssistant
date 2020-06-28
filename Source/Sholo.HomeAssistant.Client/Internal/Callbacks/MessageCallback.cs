using System;
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Sholo.HomeAssistant.Client.Messages;

namespace Sholo.HomeAssistant.Client.Internal.Callbacks
{
    internal class MessageCallback<TMessage, TMessageResult> : BaseMessageCallback
        where TMessage : BaseMessageWithId
    {
        public TMessage Command { get; }
        public Task<TMessageResult> Task => TaskCompletionSource.Task;

        private Func<WebSocket, CancellationToken, Task> Invoker { get; }
        private Func<Stream, CancellationToken, Task<TMessageResult>> ResultReader { get; }

        private TaskCompletionSource<TMessageResult> TaskCompletionSource { get; } = new TaskCompletionSource<TMessageResult>();

        public MessageCallback(
            TMessage command,
            Func<WebSocket, CancellationToken, Task> invoker,
            Func<Stream, CancellationToken, Task<TMessageResult>> resultReader
        )
            : base(
                command.Id,
                command.MessageType
            )
        {
            Command = command;
            Invoker = invoker;
            ResultReader = resultReader;
        }

        public override Task Invoke(WebSocket webSocket, CancellationToken cancellationToken) => Invoker(webSocket, cancellationToken);

        public override async Task HandleResult(Stream responseStream, CancellationToken cancellationToken)
        {
            var result = await ResultReader(responseStream, cancellationToken);
            TaskCompletionSource.SetResult(result);
        }
    }
}
