namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class CalendarStateAttributes
{
    public bool? AllDay { get; set; }
    public string Description { get; set; } = null!;
    public string EndTime { get; set; } = null!;
    public string FriendlyName { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string Message { get; set; } = null!;
    public bool OffsetReached { get; set; }
    public string StartTime { get; set; } = null!;
}
