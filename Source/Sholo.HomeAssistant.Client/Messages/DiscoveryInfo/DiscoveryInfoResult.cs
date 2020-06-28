using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Messages.DiscoveryInfo
{
#pragma warning disable CA1056
    [PublicAPI]
    public class DiscoveryInfoResult
    {
        public string BaseUrl { get; set; }
        public string LocationName { get; set; }
        public bool RequiresApiPassword { get; set; }
        public string Version { get; set; }
    }
#pragma warning restore CA1056
}
