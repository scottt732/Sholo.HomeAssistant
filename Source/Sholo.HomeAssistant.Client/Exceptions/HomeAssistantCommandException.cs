using System;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Exceptions
{
    [PublicAPI]
    public class HomeAssistantCommandException : Exception
    {
        public HomeAssistantCommandException()
            : base("HomeAssistant result did not indicate success")
        {
        }

        public HomeAssistantCommandException(Exception innerException)
            : base("HomeAssistant result did not indicate success", innerException)
        {
        }

        public HomeAssistantCommandException(string message)
            : base($"HomeAssistant result did not indicate success: {message}")
        {
        }

        public HomeAssistantCommandException(string message, Exception innerException)
            : base($"HomeAssistant result did not indicate success: {message}", innerException)
        {
        }
    }
}
