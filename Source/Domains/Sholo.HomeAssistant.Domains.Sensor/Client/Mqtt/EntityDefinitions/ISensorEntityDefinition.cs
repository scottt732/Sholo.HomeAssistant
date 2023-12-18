using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public interface ISensorEntityDefinition : ICoreSensorEntityDefinition
{
    /// <summary>
    /// The type/class of the sensor to set the icon in the frontend.
    /// </summary>
    SensorDeviceClass? DeviceClass { get; }

    /// <summary>
    /// The icon for the entity.
    /// </summary>
    string Icon { get; }

    /// <summary>
    /// Defines the units of measurement of the sensor, if any.
    /// </summary>
    string UnitOfMeasurement { get; }

    /// <summary>
    /// Type of state. If defined, the sensor is assumed to be numerical and will be displayed as
    /// a line-chart in the frontend instead of as discrete values.
    /// </summary>
    /// <remarks>
    /// See https://developers.home-assistant.io/docs/core/entity/sensor/#available-state-classes,
    /// particularly the section on Long-Term statistics for details about the relationship between
    /// StateClass, LastReset, and the impact on Home Assistant's long-term statistics tracking.
    /// </remarks>
    SensorStateClass? StateClass { get; }

    /// <summary>
    /// The time when an accumulating sensor such as an electricity usage meter, gas meter, water
    /// meter etc. was initialized. If the time of initialization is unknown, set it to None.
    /// Note that the datetime.datetime returned by the last_reset property will be converted to
    /// an ISO 8601-formatted string when the entity's state attributes are updated. When changing
    /// last_reset, the state must be a valid number.
    /// </summary>
    DateTime? LastReset { get; }

    /// <summary>
    /// Defines a template to extract the <see cref="LastReset" />. Available variables: entity_id.
    /// The entity_id can be used to reference the entity's attributes.
    /// </summary>
    string? LastResetValueTemplate { get; }
}
