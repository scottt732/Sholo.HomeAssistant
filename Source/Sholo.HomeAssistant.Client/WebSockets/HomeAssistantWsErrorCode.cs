using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.WebSockets
{
    [PublicAPI]
    public enum HomeAssistantWsErrorCode
    {
        NonIncreasingIdentifier = 1,
        MessageValidationError = 2,
        RequestedItemNotFound = 3
    }
}
