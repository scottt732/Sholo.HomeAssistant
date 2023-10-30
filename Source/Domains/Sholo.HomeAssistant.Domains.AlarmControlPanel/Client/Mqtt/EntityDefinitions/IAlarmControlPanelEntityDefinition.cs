namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public interface IAlarmControlPanelEntityDefinition : IStatefulEntityDefinition
{
    /// <summary>
    /// If defined, specifies a code to enable or disable the alarm in the frontend.
    /// </summary>
    string Code { get; }

    /// <summary>
    /// If true the code is required to arm the alarm. If false the code is not validated.
    /// </summary>
    bool? CodeArmRequired { get; }

    /// <summary>
    /// If true the code is required to disarm the alarm. If false the code is not validated.
    /// </summary>
    bool? CodeDisarmRequired { get; }

    /// <summary>
    /// The template used for the command payload. Available variables: action and code.
    /// </summary>
    string CommandTemplate { get; }

    /// <summary>
    /// The MQTT topic to publish commands to change the alarm state.
    /// </summary>
    string CommandTopic { get; }

    /// <summary>
    /// The payload to set armed-away mode on your Alarm Panel.
    /// </summary>
    string PayloadArmAway { get; }

    /// <summary>
    /// The payload to set armed-home mode on your Alarm Panel.
    /// </summary>
    string PayloadArmHome { get; }

    /// <summary>
    /// The payload to set armed-night mode on your Alarm Panel.
    /// </summary>
    string PayloadArmNight { get; }

    /// <summary>
    /// The payload to disarm your Alarm Panel.
    /// </summary>
    string PayloadDisarm { get; }
}
