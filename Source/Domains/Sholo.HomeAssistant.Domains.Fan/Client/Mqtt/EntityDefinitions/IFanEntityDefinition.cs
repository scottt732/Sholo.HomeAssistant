namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public interface IFanEntityDefinition : ICoreSwitchEntityDefinition
{
    /// <summary>
    /// The MQTT topic to publish commands to change the oscillation state.
    /// </summary>
    string OscillationCommandTopic { get; }

    /// <summary>
    /// The MQTT topic subscribed to receive oscillation state updates.
    /// </summary>
    string OscillationStateTopic { get; }

    /// <summary>
    /// Defines a template to extract a value from the oscillation.
    /// </summary>
    string? OscillationValueTemplate { get; }

    /// <summary>
    /// The payload that represents the fan's high speed.
    /// </summary>
    string PayloadHighSpeed { get; }

    /// <summary>
    /// The payload that represents the fan's low speed.
    /// </summary>
    string PayloadLowSpeed { get; }

    /// <summary>
    /// The payload that represents the fan's medium speed.
    /// </summary>
    string PayloadMediumSpeed { get; }

    /// <summary>
    /// The payload that represents the stop state.
    /// </summary>
    string PayloadOff { get; }

    /// <summary>
    /// The payload that represents the running state.
    /// </summary>
    string PayloadOn { get; }

    /// <summary>
    /// The payload that represents the oscillation off state.
    /// </summary>
    string PayloadOscillationOff { get; }

    /// <summary>
    /// The payload that represents the oscillation on state.
    /// </summary>
    string PayloadOscillationOn { get; }

    /// <summary>
    /// The MQTT topic to publish commands to change speed state.
    /// </summary>
    string SpeedCommandTopic { get; }

    /// <summary>
    /// The MQTT topic subscribed to receive speed state updates.
    /// </summary>
    string SpeedStateTopic { get; }

    /// <summary>
    /// Defines a template to extract a value from the speed payload.
    /// </summary>
    string? SpeedValueTemplate { get; }

    /// <summary>
    /// List of speeds this fan is capable of running at.
    /// high.
    /// </summary>
    FanSpeed[] Speeds { get; }
}
