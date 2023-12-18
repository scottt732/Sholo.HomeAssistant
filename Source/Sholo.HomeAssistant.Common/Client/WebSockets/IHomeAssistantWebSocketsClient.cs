using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sholo.HomeAssistant.Client.WebSockets.ConnectionService;
using Sholo.HomeAssistant.Client.WebSockets.Events;
using Sholo.HomeAssistant.Client.WebSockets.Messages.CameraThumbnails;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Config;
using Sholo.HomeAssistant.Client.WebSockets.Messages.MediaPlayerThumbnails;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Panels;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Services;
using Sholo.HomeAssistant.Client.WebSockets.Messages.States;
using Sholo.HomeAssistant.Client.WebSockets.Messages.Templates;

namespace Sholo.HomeAssistant.Client.WebSockets;

[PublicAPI]
public interface IHomeAssistantWebSocketsClient
{
    IHomeAssistantWebSocketsConnectionService Connection { get; }
    IObservable<WebsocketsConnectionState> ConnectionStateChanges { get; }
    void WaitForConnection(CancellationToken cancellationToken = default);

    Task CallServiceAsync(string domain, string service, IDictionary<string, object>? serviceData = null, CancellationToken cancellationToken = default);

    // TODO: GetEntitySourceAsync()

    // TODO: ExecuteScriptAsync()

    // TODO: FireEventAsync() - https://developers.home-assistant.io/docs/api/websocket#fire-an-event

    Task<ConfigurationResult> GetConfigurationAsync(CancellationToken cancellationToken = default);
    Task<IDictionary<string, IDictionary<string, ServiceDefinition>>> GetServicesAsync(CancellationToken cancellationToken = default);
    Task<StatesResult> GetStatesAsync(CancellationToken cancellationToken = default);

    // TODO: GetManifestAsync()

    // TODO: HandleIntegrationSetupInfoAsync()

    // TODO: GetManifestListAsync()

    Task SendPingAsync(CancellationToken cancellationToken = default);

    Task<RenderedTemplateEvent> RenderTemplateAsync(
        string template,
        IDictionary<string, object?>? variables = null,
        float? timeout = null,
        bool? strict = null,
        bool? reportErrors = null,
        CancellationToken cancellationToken = default
    );

    Task<RenderedTemplateEvent> RenderTemplateAsync(
        string template,
        string entityId,
        IDictionary<string, object?>? variables = null,
        float? timeout = null,
        bool? strict = null,
        bool? reportErrors = null,
        CancellationToken cancellationToken = default
    );

    Task<RenderedTemplateEvent> RenderTemplateAsync(
        string template,
        string[]? entityIds = null,
        IDictionary<string, object?>? variables = null,
        float? timeout = null,
        bool? strict = null,
        bool? reportErrors = null,
        CancellationToken cancellationToken = default
    );

    IAsyncEnumerable<RenderedTemplateEvent> SubscribeRenderTemplateAsync(
        string template,
        IDictionary<string, object?>? variables = null,
        bool? strict = null,
        bool? reportErrors = null,
        CancellationToken cancellationToken = default
    );

    IAsyncEnumerable<RenderedTemplateEvent> SubscribeRenderTemplateAsync(
        string template,
        string entityId,
        IDictionary<string, object?>? variables = null,
        bool? strict = null,
        bool? reportErrors = null,
        CancellationToken cancellationToken = default
    );

    IAsyncEnumerable<RenderedTemplateEvent> SubscribeRenderTemplateAsync(
        string template,
        string[]? entityIds = null,
        IDictionary<string, object?>? variables = null,
        bool? strict = null,
        bool? reportErrors = null,
        CancellationToken cancellationToken = default
    );

    // TODO: SubscribeBootstrapIntegrationsAsync()

    IAsyncEnumerable<IEventMessage> SubscribeEventsAsync(string? eventType = null, Func<IEventMessage, bool>? predicate = null, CancellationToken cancellationToken = default);
    IAsyncEnumerable<IEventMessage<TPayload>> SubscribeEventsAsync<TPayload>(string? eventType = null, Func<IEventMessage<TPayload>, bool>? predicate = null, CancellationToken cancellationToken = default);

    // TODO: Implicitly UnsubscribeEventsAsync? - https://developers.home-assistant.io/docs/api/websocket#unsubscribing-from-events

    // TODO: SubscribeTriggerAsync() - https://developers.home-assistant.io/docs/api/websocket#subscribe-to-trigger

    // TODO: HandleTestConditionAsync()

    // TODO: ValidateConfigAsync(); - https://developers.home-assistant.io/docs/api/websocket#validate-config

    // TODO: SubscribeEntitiesAsync();

    // TODO: GetSupportedFeaturesAsync();

    // TODO: GetIntegrationDescriptionsAsync();

    Task<IDictionary<string, ComponentRegistration>> GetPanelsAsync(CancellationToken cancellationToken = default);
    Task<CameraThumbnailResult> GetCameraThumbnailAsync(string entityId, CancellationToken cancellationToken = default);
    Task<MediaPlayerThumbnailResult> GetMediaPlayerThumbnailAsync(string entityId, CancellationToken cancellationToken = default);
}

public static class HomeAssistantUndocumentedWebSocketsClientExtensions
{
}
