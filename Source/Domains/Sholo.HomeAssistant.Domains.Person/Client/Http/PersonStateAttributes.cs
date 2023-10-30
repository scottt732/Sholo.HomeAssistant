namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class PersonStateAttributes
{
    public bool Editable { get; set; }
    public string EntityPicture { get; set; } = null!;
    public string FriendlyName { get; set; } = null!;
    public int? GpsAccuracy { get; set; }
    public string Id { get; set; } = null!;
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string Source { get; set; } = null!;
    public string UserId { get; set; } = null!;
}
