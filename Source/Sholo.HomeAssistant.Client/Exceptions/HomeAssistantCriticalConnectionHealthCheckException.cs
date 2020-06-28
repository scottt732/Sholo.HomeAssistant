using System;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Exceptions
{
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
}
