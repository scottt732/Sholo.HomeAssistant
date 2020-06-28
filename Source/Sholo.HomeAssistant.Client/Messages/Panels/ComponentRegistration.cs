using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Messages.Panels
{
#pragma warning disable CA1056
    [PublicAPI]
    public class ComponentRegistration
    {
        public string ComponentName { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public ComponentConfiguration Config { get; set; }
        public string UrlPath { get; set; }
        public bool RequireAdmin { get; set; }
    }
#pragma warning restore CA1056
}
