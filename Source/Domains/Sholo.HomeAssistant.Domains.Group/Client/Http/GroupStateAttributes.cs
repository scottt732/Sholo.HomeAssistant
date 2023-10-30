namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class GroupStateAttributes
{
    public string[] EntityId { get; set; } = null!;
    public string FriendlyName { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public int? Order { get; set; }
}
