namespace Sholo.HomeAssistant.Client.WebSockets
{
    public enum HomeAssistantWsMessageType
    {
        // Send
        Auth,

        // Command
        Ping,
        Event,
        SubscribeEvents,
        UnsubscribeEvents,
        CallService,
        GetStates,
        GetConfig,
        GetServices,
        GetPanels,
        CameraThumbnail,
        MediaPlayerThumbnail,

        // Result
        AuthOk,
        AuthInvalid,
        AuthRequired,
        Result,
        Pong
    }
}