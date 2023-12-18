using System.Threading;
using System.Threading.Tasks;
using Sholo.HomeAssistant.Client.Speech.Messages.GetPipeline;
using Sholo.HomeAssistant.Client.Speech.Messages.GetPipelineDebug;
using Sholo.HomeAssistant.Client.Speech.Messages.ListPipeline;
using Sholo.HomeAssistant.Client.Speech.Messages.ListPipelineDebug;
using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Speech;

[PublicAPI]
public static class HomeAssistantWebSocketsClientExtensions
{
    public static async Task<ListPipelineResult> ListPipelinesAsync(this IHomeAssistantWebSocketsClient client, CancellationToken cancellationToken = default)
    {
        var result = await client.Connection.SendCommandAsync<ListPipelineMessage, ListPipelineResult>(new ListPipelineMessage(false), cancellationToken);
        return result;
    }

    public static async Task<ListPipelineDebugResult> ListPipelineRunsDebugAsync(this IHomeAssistantWebSocketsClient client, string pipelineId, CancellationToken cancellationToken = default)
    {
        var result = await client.Connection.SendCommandAsync<ListPipelineDebugMessage, ListPipelineDebugResult>(new ListPipelineDebugMessage(pipelineId), cancellationToken);
        return result;
    }

    public static async Task<GetPipelineResult> GetPipelineAsync(this IHomeAssistantWebSocketsClient client, CancellationToken cancellationToken = default)
    {
        var result = await client.Connection.SendCommandAsync<GetPipelineMessage, GetPipelineResult>(new GetPipelineMessage(), cancellationToken);
        return result;
    }

    public static async Task<GetPipelineDebugResult> GetPipelineDebugAsync(this IHomeAssistantWebSocketsClient client, string pipelineId, string pipelineRunId, CancellationToken cancellationToken = default)
    {
        var result = await client.Connection.SendCommandAsync<GetPipelineDebugMessage, GetPipelineDebugResult>(new GetPipelineDebugMessage(pipelineId, pipelineRunId), cancellationToken);
        return result;
    }
}
