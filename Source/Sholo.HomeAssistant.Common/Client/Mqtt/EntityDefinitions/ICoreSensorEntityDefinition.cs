namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public interface ICoreSensorEntityDefinition : IStatefulEntityDefinition
{
    /// <summary>
    /// Defines the number of seconds after the value expires if it's not updated.
    /// </summary>
    int? ExpireAfter { get; }

    /// <summary>
    /// Sends update events even if the value hasn't changed. Useful if you want to have
    /// meaningful value graphs in history.
    /// </summary>
    bool? ForceUpdate { get; }
}
