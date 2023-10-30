using System;

namespace Sholo.HomeAssistant.Exceptions;

[PublicAPI]
public class HomeAssistantCriticalConnectionHealthCheckException : Exception
{
    public HomeAssistantCriticalConnectionHealthCheckException()
    {
    }

    public HomeAssistantCriticalConnectionHealthCheckException(string message)
        : base(message)
    {
    }

    public HomeAssistantCriticalConnectionHealthCheckException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
