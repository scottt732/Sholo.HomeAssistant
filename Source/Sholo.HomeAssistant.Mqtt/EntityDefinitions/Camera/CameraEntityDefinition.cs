namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.Camera
{
    public class CameraEntityDefinition : BaseEntityDefinition, ICameraEntityDefinition
    {
        public string Topic { get; internal set; }
    }
}