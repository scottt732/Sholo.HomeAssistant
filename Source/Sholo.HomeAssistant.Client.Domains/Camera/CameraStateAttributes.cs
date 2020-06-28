using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Camera
{
    [PublicAPI]
    public class CameraStateAttributes
    {
        public string AccessToken { get; set; }
        public string EntityPicture { get; set; }
        public string FriendlyName { get; set; }
        public int? SupportedFeatures { get; set; }
        public bool? Restored { get; set; }
    }
}
