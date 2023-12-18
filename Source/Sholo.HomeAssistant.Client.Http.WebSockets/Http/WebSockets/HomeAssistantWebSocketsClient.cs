using System.Runtime.CompilerServices;
using Sholo.HomeAssistant.Client.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets.ConnectionService;
using Sholo.HomeAssistant.Client.WebSockets.Events;
using Sholo.HomeAssistant.Client.WebSockets.Messages.CallService;
using Sholo.HomeAssistant.Client.WebSockets.Messages.CameraThumbnails;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Config;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Heartbeats;
using Sholo.HomeAssistant.Client.WebSockets.Messages.MediaPlayerThumbnails;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Panels;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Services;
using Sholo.HomeAssistant.Client.WebSockets.Messages.States;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Templates;

namespace Sholo.HomeAssistant.Client.Http.WebSockets;

public class HomeAssistantWebSocketsClient : IHomeAssistantWebSocketsClient
{
    public IObservable<WebsocketsConnectionState> ConnectionStateChanges => Connection.ConnectionStateChanges;

    public IHomeAssistantWebSocketsConnectionService Connection { get; }

    public HomeAssistantWebSocketsClient(
        IHomeAssistantWebSocketsConnectionService connection
    )
    {
        Connection = connection;
    }

    public void WaitForConnection(CancellationToken cancellationToken = default)
    {
        Connection.OnlineEvent.Wait(cancellationToken);
    }

    public Task<RenderedTemplateEvent> RenderTemplateAsync(
        string template,
        IDictionary<string, object?>? variables = null,
        float? timeout = null,
        bool? strict = null,
        bool? reportErrors = null,
        CancellationToken cancellationToken = default
    )
    {
        var entityIds = (string[]?)null;
        return RenderTemplateAsync(template, entityIds, variables, timeout, strict, reportErrors, cancellationToken);
    }

    public Task<RenderedTemplateEvent> RenderTemplateAsync(
        string template,
        string entityId,
        IDictionary<string, object?>? variables = null,
        float? timeout = null,
        bool? strict = null,
        bool? reportErrors = null,
        CancellationToken cancellationToken = default
    )
    {
        var entityIds = new[] { entityId };
        return RenderTemplateAsync(template, entityIds, variables, timeout, strict, reportErrors, cancellationToken);
    }

    public async Task<RenderedTemplateEvent> RenderTemplateAsync(
        string template,
        string[]? entityIds = null,
        IDictionary<string, object?>? variables = null,
        float? timeout = null,
        bool? strict = null,
        bool? reportErrors = null,
        CancellationToken cancellationToken = default
    )
    {
        var renderTemplateCommand = new RenderTemplateCommand(template, entityIds, variables, timeout, strict, reportErrors);

        var res = await Connection.SendCommandAndWaitForEventAsync<RenderTemplateCommand, RenderTemplateCommandResult, RenderedTemplateEvent>(renderTemplateCommand, timeout, cancellationToken);

        /*
        {
          "id": 82,
          "type": "event",
          "event": {
            "result": "on",
            "listeners": {
              "all": false,
              "entities": [
                "light.studio"
              ],
              "domains": [],
              "time": false
            }
          }
        }
        */

        return default!;
    }

    public async IAsyncEnumerable<RenderedTemplateEvent> SubscribeRenderTemplateAsync(
        string template,
        IDictionary<string, object?>? variables = null,
        bool? strict = null,
        bool? reportErrors = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        var entityIds = (string[]?)null;
        await foreach (var result in SubscribeRenderTemplateAsync(template, entityIds, variables, strict, reportErrors, cancellationToken))
        {
            yield return result;
        }
    }

    public async IAsyncEnumerable<RenderedTemplateEvent> SubscribeRenderTemplateAsync(
        string template,
        string entityId,
        IDictionary<string, object?>? variables = null,
        bool? strict = null,
        bool? reportErrors = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        var entityIds = new[] { entityId };
        await foreach (var result in SubscribeRenderTemplateAsync(template, entityIds, variables, strict, reportErrors, cancellationToken))
        {
            yield return result;
        }
    }

    public async IAsyncEnumerable<RenderedTemplateEvent> SubscribeRenderTemplateAsync(
        string template,
        string[]? entityIds = null,
        IDictionary<string, object?>? variables = null,
        bool? strict = null,
        bool? reportErrors = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        var renderTemplateCommand = new RenderTemplateCommand(template, entityIds, variables, null, strict, reportErrors);

        await foreach (var evt in Connection.SendCommandAndSubscribeEventsAsync<RenderTemplateCommand, RenderTemplateCommandResult, RenderedTemplateEvent>(renderTemplateCommand, cancellationToken))
        {
            yield return evt;
        }
    }

    public async IAsyncEnumerable<IEventMessage> SubscribeEventsAsync(
        string? eventType = null,
        Func<IEventMessage, bool>? predicate = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        await foreach (var eventMessage in Connection.SubscribeAsync(eventType, predicate, cancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return eventMessage;
        }
    }

    public async IAsyncEnumerable<IEventMessage<TPayload>> SubscribeEventsAsync<TPayload>(
        string? eventType = null,
        Func<IEventMessage<TPayload>, bool>? predicate = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        await foreach (var eventMessage in Connection.SubscribeAsync(eventType, predicate, cancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return eventMessage;
        }
    }

    public async Task CallServiceAsync(string domain, string service, IDictionary<string, object>? serviceData = null, CancellationToken cancellationToken = default)
    {
        var callServiceCommand = new CallServiceCommand(domain, service, serviceData);
        var callServiceCommandResult = await Connection.SendCommandAsync<CallServiceCommand, CallServiceCommandResult>(callServiceCommand, cancellationToken);

        callServiceCommandResult.EnsureSuccessResult();
    }

    public async Task<StatesResult> GetStatesAsync(CancellationToken cancellationToken = default)
    {
        var getStatesCommand = new GetStatesCommand();
        var getStatesCommandResult = await Connection.SendCommandAsync<GetStatesCommand, GetStatesCommandResult>(getStatesCommand, cancellationToken);

        getStatesCommandResult.EnsureSuccessResult();

        return new StatesResult(getStatesCommandResult.Result!);
    }

    public async Task<ConfigurationResult> GetConfigurationAsync(CancellationToken cancellationToken = default)
    {
        var getConfigurationCommand = new GetConfigurationCommand();
        var getConfigurationCommandResult = await Connection.SendCommandAsync<GetConfigurationCommand, GetConfigurationCommandResult>(getConfigurationCommand, cancellationToken);

        getConfigurationCommandResult.EnsureSuccessResult();

        return getConfigurationCommandResult.Result!;
    }

    public async Task<IDictionary<string, IDictionary<string, ServiceDefinition>>> GetServicesAsync(CancellationToken cancellationToken = default)
    {
        var getServicesCommand = new GetServicesCommand();
        var getServicesCommandResult = await Connection.SendCommandAsync<GetServicesCommand, GetServicesCommandResult>(getServicesCommand, cancellationToken);

        getServicesCommandResult.EnsureSuccessResult();

        return getServicesCommandResult.Result!;
    }

    public async Task<IDictionary<string, ComponentRegistration>> GetPanelsAsync(CancellationToken cancellationToken = default)
    {
        var getPanelsCommand = new GetPanelsCommand();
        var getPanelsCommandResult = await Connection.SendCommandAsync<GetPanelsCommand, GetPanelsCommandResult>(getPanelsCommand, cancellationToken);

        getPanelsCommandResult.EnsureSuccessResult();

        return getPanelsCommandResult.Result!;
    }

    public async Task<CameraThumbnailResult> GetCameraThumbnailAsync(string entityId, CancellationToken cancellationToken = default)
    {
        var getCameraThumbnailCommand = new GetCameraThumbnailCommand(entityId);
        var getCameraThumbnailCommandResult = await Connection.SendCommandAsync<GetCameraThumbnailCommand, GetCameraThumbnailCommandResult>(getCameraThumbnailCommand, cancellationToken);

        getCameraThumbnailCommandResult.EnsureSuccessResult();

        var content = Convert.FromBase64String(getCameraThumbnailCommandResult.Result!.Content);
        var contentType = getCameraThumbnailCommandResult.Result.ContentType;
        return new CameraThumbnailResult(content, contentType);
    }

    public async Task<MediaPlayerThumbnailResult> GetMediaPlayerThumbnailAsync(string entityId, CancellationToken cancellationToken = default)
    {
        var getMediaPlayerThumbnailCommand = new GetMediaPlayerThumbnailCommand(entityId);
        var getMediaPlayerThumbnailCommandResult = await Connection.SendCommandAsync<GetMediaPlayerThumbnailCommand, GetMediaPlayerThumbnailCommandResult>(getMediaPlayerThumbnailCommand, cancellationToken);

        getMediaPlayerThumbnailCommandResult.EnsureSuccessResult();

        var content = Convert.FromBase64String(getMediaPlayerThumbnailCommandResult.Result!.Content);
        var contentType = getMediaPlayerThumbnailCommandResult.Result.ContentType;
        return new MediaPlayerThumbnailResult(content, contentType);
    }

    public Task SendPingAsync(CancellationToken cancellationToken = default)
        => Connection.SendCommandAsync<PingCommand, PongResult>(new PingCommand(), cancellationToken);
}
