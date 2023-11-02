namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public class ButtonEntityDefinition : BaseStatefulEntityDefinition, IButtonEntityDefinition
{
    public string? CommandTemplate { get; internal set; } = null!;
    public string CommandTopic { get; internal set; } = null!;
    public ButtonDeviceClass? DeviceClass { get; internal set; }
    public bool? EnabledByDefault { get; internal set; } = true;
    public string? Encoding { get; internal set; } = "utf-8";
    public string? EntityCategory { get; internal set; }
    public string? Icon { get; internal set; }
    public string? PayloadPress { get; internal set; } = "PRESS";
}
