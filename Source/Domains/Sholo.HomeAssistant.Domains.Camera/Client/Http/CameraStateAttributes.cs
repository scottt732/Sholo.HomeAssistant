namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class CameraStateAttributes
{
    public string AccessToken { get; set; } = null!;
    public string EntityPicture { get; set; } = null!;
    public string FriendlyName { get; set; } = null!;
    public int? SupportedFeatures { get; set; }
    public bool? Restored { get; set; }
}
