using System;

namespace Sholo.HomeAssistant.Exceptions;

[PublicAPI]
public class HomeAssistantConnectionHealthCheckException : Exception
{
    public HomeAssistantConnectionHealthCheckException()
    {
    }

    public HomeAssistantConnectionHealthCheckException(string message)
        : base(message)
    {
    }

    public HomeAssistantConnectionHealthCheckException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
