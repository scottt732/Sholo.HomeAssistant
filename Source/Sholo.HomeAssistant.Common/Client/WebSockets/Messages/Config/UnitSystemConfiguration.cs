namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Config;

[PublicAPI]
public class UnitSystemConfiguration
{
    public string Length { get; set; } = null!;
    public string Mass { get; set; } = null!;
    public string Pressure { get; set; } = null!;
    public string Temperature { get; set; } = null!;
    public string Volume { get; set; } = null!;
}
