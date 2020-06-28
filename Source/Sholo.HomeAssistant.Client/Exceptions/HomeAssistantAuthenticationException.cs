using System;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Exceptions
{
    [PublicAPI]
    public class HomeAssistantAuthenticationException : Exception
    {
        public HomeAssistantAuthenticationException()
        {
        }

        public HomeAssistantAuthenticationException(string message)
            : base(message)
        {
        }

        public HomeAssistantAuthenticationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
