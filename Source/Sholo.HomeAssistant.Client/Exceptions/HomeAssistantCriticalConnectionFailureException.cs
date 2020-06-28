using System;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Exceptions
{
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
}
