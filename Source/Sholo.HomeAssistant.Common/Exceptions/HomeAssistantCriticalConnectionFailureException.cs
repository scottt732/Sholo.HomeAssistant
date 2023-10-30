using System;

namespace Sholo.HomeAssistant.Exceptions;

[PublicAPI]
public class HomeAssistantCriticalConnectionFailureException : Exception
{
    public HomeAssistantCriticalConnectionFailureException()
    {
    }

    public HomeAssistantCriticalConnectionFailureException(string message)
        : base(message)
    {
    }

    public HomeAssistantCriticalConnectionFailureException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
