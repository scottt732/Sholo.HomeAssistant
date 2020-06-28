namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.Camera
{
    public interface ICameraEntityDefinition : IEntityDefinition
    {
        /// <summary>
        /// The MQTT topic to subscribe to.
        /// </summary>
        string Topic { get; }
    }
}