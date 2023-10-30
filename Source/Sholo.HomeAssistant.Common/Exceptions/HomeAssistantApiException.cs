using System;

namespace Sholo.HomeAssistant.Exceptions;

[PublicAPI]
public class HomeAssistantApiException : Exception
{
    public HomeAssistantApiException()
        : base("HomeAssistant result did not indicate success")
    {
    }

    public HomeAssistantApiException(Exception innerException)
        : base("HomeAssistant result did not indicate success", innerException)
    {
    }

    public HomeAssistantApiException(string message)
        : base($"HomeAssistant result did not indicate success: {message}")
    {
    }

    public HomeAssistantApiException(string message, Exception innerException)
        : base($"HomeAssistant result did not indicate success: {message}", innerException)
    {
    }
}
