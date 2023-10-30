namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

public class CameraEntityDefinition : BaseEntityDefinition, ICameraEntityDefinition
{
    public string Topic { get; internal set; } = null!;
}
