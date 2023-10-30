namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

public interface ICameraEntityDefinition : IEntityDefinition
{
    /// <summary>
    /// The MQTT topic to subscribe to.
    /// </summary>
    string Topic { get; }
}
