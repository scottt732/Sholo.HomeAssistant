using System.Net.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets.Messages;

namespace Sholo.HomeAssistant.Client.Http.WebSockets.Callbacks;

internal sealed class MessageCallback<TMessage, TMessageResult> : BaseMessageCallback
    where TMessage : BaseMessageWithId
{
    public TMessage Command { get; }
    public Task<TMessageResult> Task => TaskCompletionSource.Task;

    private Func<WebSocket, CancellationToken, Task> Invoker { get; }
    private Func<Stream, CancellationToken, Task<TMessageResult>> ResultReader { get; }

    private TaskCompletionSource<TMessageResult> TaskCompletionSource { get; } = new();

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

    public override Task InvokeAsync(WebSocket webSocket, CancellationToken cancellationToken) => Invoker(webSocket, cancellationToken);

    public override async Task HandleResultAsync(Stream responseStream, CancellationToken cancellationToken)
    {
        var result = await ResultReader(responseStream, cancellationToken);
        TaskCompletionSource.SetResult(result);
    }
}
