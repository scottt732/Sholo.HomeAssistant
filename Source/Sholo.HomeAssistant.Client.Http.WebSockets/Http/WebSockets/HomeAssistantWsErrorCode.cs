namespace Sholo.HomeAssistant.Client.Http.WebSockets;

[PublicAPI]
public enum HomeAssistantWsErrorCode
{
    Unknown = 0,
    NonIncreasingIdentifier = 1,
    MessageValidationError = 2,
    RequestedItemNotFound = 3
}
