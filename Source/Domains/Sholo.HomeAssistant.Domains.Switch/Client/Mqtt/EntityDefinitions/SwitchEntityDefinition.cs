namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

public class SwitchEntityDefinition : BaseCoreSwitchEntityDefinition, ISwitchEntityDefinition
{
    public string Icon { get; internal set; } = null!;
    public string PayloadOff { get; internal set; } = null!;
    public string PayloadOn { get; internal set; } = null!;
    public string StateOff { get; internal set; } = null!;
    public string StateOn { get; internal set; } = null!;
}
