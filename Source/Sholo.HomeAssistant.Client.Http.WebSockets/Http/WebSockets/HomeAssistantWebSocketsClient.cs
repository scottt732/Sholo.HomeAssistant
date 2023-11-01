using System.Runtime.CompilerServices;
using Sholo.HomeAssistant.Client.Http.WebSockets.ConnectionService;
using Sholo.HomeAssistant.Client.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets.Events;
using Sholo.HomeAssistant.Client.WebSockets.Messages.CallService;
using Sholo.HomeAssistant.Client.WebSockets.Messages.CameraThumbnails;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Config;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Heartbeats;
using Sholo.HomeAssistant.Client.WebSockets.Messages.MediaPlayerThumbnails;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Panels;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Services;
using Sholo.HomeAssistant.Client.WebSockets.Messages.States;

namespace Sholo.HomeAssistant.Client.Http.WebSockets;

public class HomeAssistantWebSocketsClient : IHomeAssistantWebSocketsClient
{
    public IObservable<WebsocketsConnectionState> ConnectionStateChanges => ConnectionService.ConnectionStateChanges;

    private IHomeAssistantWebSocketsConnectionService ConnectionService { get; }

    public HomeAssistantWebSocketsClient(
        IHomeAssistantWebSocketsConnectionService connectionService
    )
    {
        ConnectionService = connectionService;
    }

    public void WaitForConnection(CancellationToken cancellationToken = default)
    {
        ConnectionService.OnlineEvent.Wait(cancellationToken);
    }

    public async IAsyncEnumerable<IEventMessage> SubscribeAsync(
        string? eventType = null,
        Func<IEventMessage, bool>? predicate = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        await foreach (var eventMessage in ConnectionService.SubscribeAsync(eventType, predicate, cancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return eventMessage;
        }
    }

    public async IAsyncEnumerable<IEventMessage<TPayload>> SubscribeAsync<TPayload>(
        string? eventType = null,
        Func<IEventMessage<TPayload>, bool>? predicate = null,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        await foreach (var eventMessage in ConnectionService.SubscribeAsync(eventType, predicate, cancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            yield return eventMessage;
        }
    }

    public async Task CallServiceAsync(string domain, string service, IDictionary<string, object>? serviceData = null, CancellationToken cancellationToken = default)
    {
        var callServiceCommand = new CallServiceCommand(domain, service, serviceData);
        var callServiceCommandResult = await ConnectionService.SendCommandAsync<CallServiceCommand, CallServiceCommandResult>(callServiceCommand, cancellationToken);

        callServiceCommandResult.EnsureSuccessResult();
    }

    public async Task<StatesResult> GetStatesAsync(CancellationToken cancellationToken = default)
    {
        var getStatesCommand = new GetStatesCommand();
        var getStatesCommandResult = await ConnectionService.SendCommandAsync<GetStatesCommand, GetStatesCommandResult>(getStatesCommand, cancellationToken);

        getStatesCommandResult.EnsureSuccessResult();

        return new StatesResult(getStatesCommandResult.Result);
    }

    public async Task<ConfigurationResult> GetConfigurationAsync(CancellationToken cancellationToken = default)
    {
        var getConfigurationCommand = new GetConfigurationCommand();
        var getConfigurationCommandResult = await ConnectionService.SendCommandAsync<GetConfigurationCommand, GetConfigurationCommandResult>(getConfigurationCommand, cancellationToken);

        getConfigurationCommandResult.EnsureSuccessResult();

        return getConfigurationCommandResult.Result;
    }

    public async Task<IDictionary<string, IDictionary<string, ServiceDefinition>>> GetServicesAsync(CancellationToken cancellationToken = default)
    {
        var getServicesCommand = new GetServicesCommand();
        var getServicesCommandResult = await ConnectionService.SendCommandAsync<GetServicesCommand, GetServicesCommandResult>(getServicesCommand, cancellationToken);

        getServicesCommandResult.EnsureSuccessResult();

        return getServicesCommandResult.Result;
    }

    public async Task<IDictionary<string, ComponentRegistration>> GetPanelsAsync(CancellationToken cancellationToken = default)
    {
        var getPanelsCommand = new GetPanelsCommand();
        var getPanelsCommandResult = await ConnectionService.SendCommandAsync<GetPanelsCommand, GetPanelsCommandResult>(getPanelsCommand, cancellationToken);

        getPanelsCommandResult.EnsureSuccessResult();

        return getPanelsCommandResult.Result;
    }

    public async Task<CameraThumbnailResult> GetCameraThumbnailAsync(string entityId, CancellationToken cancellationToken = default)
    {
        var getCameraThumbnailCommand = new GetCameraThumbnailCommand(entityId);
        var getCameraThumbnailCommandResult = await ConnectionService.SendCommandAsync<GetCameraThumbnailCommand, GetCameraThumbnailCommandResult>(getCameraThumbnailCommand, cancellationToken);

        getCameraThumbnailCommandResult.EnsureSuccessResult();

        var content = Convert.FromBase64String(getCameraThumbnailCommandResult.Result.Content);
        var contentType = getCameraThumbnailCommandResult.Result.ContentType;
        return new CameraThumbnailResult(content, contentType);
    }

    public async Task<MediaPlayerThumbnailResult> GetMediaPlayerThumbnailAsync(string entityId, CancellationToken cancellationToken = default)
    {
        var getMediaPlayerThumbnailCommand = new GetMediaPlayerThumbnailCommand(entityId);
        var getMediaPlayerThumbnailCommandResult = await ConnectionService.SendCommandAsync<GetMediaPlayerThumbnailCommand, GetMediaPlayerThumbnailCommandResult>(getMediaPlayerThumbnailCommand, cancellationToken);

        getMediaPlayerThumbnailCommandResult.EnsureSuccessResult();

        var content = Convert.FromBase64String(getMediaPlayerThumbnailCommandResult.Result.Content);
        var contentType = getMediaPlayerThumbnailCommandResult.Result.ContentType;
        return new MediaPlayerThumbnailResult(content, contentType);
    }

    public Task PingAsync(CancellationToken cancellationToken = default)
        => ConnectionService.SendCommandAsync<PingCommand, PongResult>(new PingCommand(), cancellationToken);
}
