namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class AlarmControlPanelStateAttributes
{
    public string /* Ambiguous */ ChangedBy { get; set; } = null!;
    public bool CodeArmRequired { get; set; }
    public string CodeFormat { get; set; } = null!;
    public string FriendlyName { get; set; } = null!;
    public int SupportedFeatures { get; set; }
}
