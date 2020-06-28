using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.Climate
{
    [PublicAPI]
    public interface IClimateEntityDefinition : IStatefulEntityDefinition
    {
        /// <summary>
        /// A template to render the value received on the action_topic with.
        /// </summary>
        string ActionTemplate { get; }

        /// <summary>
        /// The MQTT topic to subscribe for changes of the current action. If this is set, the
        /// climate graph uses the value received as data source. Valid values: off, heating,
        /// cooling, drying, idle, fan.
        /// </summary>
        string ActionTopic { get; }

        /// <summary>
        /// The MQTT topic to publish commands to switch auxiliary heat.
        /// </summary>
        string AuxCommandTopic { get; }

        /// <summary>
        /// A template to render the value received on the aux_state_topic with.
        /// </summary>
        string AuxStateTemplate { get; }

        /// <summary>
        /// The MQTT topic to subscribe for changes of the auxiliary heat mode. If this is not
        /// set, the auxiliary heat mode works in optimistic mode (see below).
        /// </summary>
        string AuxStateTopic { get; }

        /// <summary>
        /// The MQTT topic to publish commands to change the away mode.
        /// </summary>
        string AwayModeCommandTopic { get; }

        /// <summary>
        /// A template to render the value received on the away_mode_state_topic with.
        /// </summary>
        string AwayModeStateTemplate { get; }

        /// <summary>
        /// The MQTT topic to subscribe for changes of the HVAC away mode. If this is not set,
        /// the away mode works in optimistic mode (see below).
        /// </summary>
        string AwayModeStateTopic { get; }

        /// <summary>
        /// A template with which the value received on current_temperature_topic will be
        /// rendered.
        /// </summary>
        string CurrentTemperatureTemplate { get; }

        /// <summary>
        /// The MQTT topic on which to listen for the current temperature.
        /// </summary>
        string CurrentTemperatureTopic { get; }

        /// <summary>
        /// The MQTT topic to publish commands to change the fan mode.
        /// </summary>
        string FanModeCommandTopic { get; }

        /// <summary>
        /// A template to render the value received on the fan_mode_state_topic with.
        /// </summary>
        string FanModeStateTemplate { get; }

        /// <summary>
        /// The MQTT topic to subscribe for changes of the HVAC fan mode. If this is not set,
        /// the fan mode works in optimistic mode (see below).
        /// </summary>
        string FanModeStateTopic { get; }

        /// <summary>
        /// A list of supported fan modes.
        /// </summary>
        string[] FanModes { get; }

        /// <summary>
        /// The MQTT topic to publish commands to change the hold mode.
        /// </summary>
        string HoldCommandTopic { get; }

        /// <summary>
        /// A template to render the value received on the hold_state_topic with.
        /// </summary>
        string HoldStateTemplate { get; }

        /// <summary>
        /// The MQTT topic to subscribe for changes of the HVAC hold mode. If this is not set,
        /// the hold mode works in optimistic mode (see below).
        /// </summary>
        string HoldStateTopic { get; }

        /// <summary>
        /// A list of available hold modes.
        /// </summary>
        string[] HoldModes { get; }

        /// <summary>
        /// Set the initial target temperature.
        /// </summary>
        int? Initial { get; }

        /// <summary>
        /// Maximum set point available.
        /// </summary>
        float? MaxTemp { get; }

        /// <summary>
        /// Minimum set point available.
        /// </summary>
        float? MinTemp { get; }

        /// <summary>
        /// The MQTT topic to publish commands to change the HVAC operation mode.
        /// </summary>
        string ModeCommandTopic { get; }

        /// <summary>
        /// A template to render the value received on the mode_state_topic with.
        /// </summary>
        string ModeStateTemplate { get; }

        /// <summary>
        /// The MQTT topic to subscribe for changes of the HVAC operation mode. If this is not
        /// set, the operation mode works in optimistic mode (see below).
        /// </summary>
        string ModeStateTopic { get; }

        /// <summary>
        /// A list of supported modes. Needs to be a subset of the default values.
        /// </summary>
        string[] Modes { get; }

        /// <summary>
        /// The payload that represents disabled state.
        /// </summary>
        string PayloadOff { get; }

        /// <summary>
        /// The payload that represents enabled state.
        /// </summary>
        string PayloadOn { get; }

        /// <summary>
        /// The MQTT topic to publish commands to change the power state. This is useful if your
        /// device has a separate power toggle in addition to mode.
        /// </summary>
        string PowerCommandTopic { get; }

        /// <summary>
        /// The desired precision for this device. Can be used to match your actual thermostat's
        /// precision. Supported values are 0.1, 0.5 and 1.0.
        /// </summary>
        float? Precision { get; }

        /// <summary>
        /// Set to false to suppress sending of all MQTT messages when the current mode is Off.
        /// </summary>
        bool? SendIfOff { get; }

        /// <summary>
        /// The MQTT topic to publish commands to change the swing mode.
        /// </summary>
        string SwingModeCommandTopic { get; }

        /// <summary>
        /// A template to render the value received on the swing_mode_state_topic with.
        /// </summary>
        string SwingModeStateTemplate { get; }

        /// <summary>
        /// The MQTT topic to subscribe for changes of the HVAC swing mode. If this is not set,
        /// the swing mode works in optimistic mode (see below).
        /// </summary>
        string SwingModeStateTopic { get; }

        /// <summary>
        /// A list of supported swing modes.
        /// </summary>
        string[] SwingModes { get; }

        /// <summary>
        /// The MQTT topic to publish commands to change the target temperature.
        /// </summary>
        string TemperatureCommandTopic { get; }

        /// <summary>
        /// The MQTT topic to publish commands to change the high target temperature.
        /// </summary>
        string TemperatureHighCommandTopic { get; }

        /// <summary>
        /// A template to render the value received on the temperature_high_state_topic with.
        /// </summary>
        string TemperatureHighStateTemplate { get; }

        /// <summary>
        /// The MQTT topic to subscribe for changes in the target high temperature. If this is not
        /// set, the target high temperature works in optimistic mode (see below).
        /// </summary>
        string TemperatureHighStateTopic { get; }

        /// <summary>
        /// The MQTT topic to publish commands to change the target low temperature.
        /// </summary>
        string TemperatureLowCommandTopic { get; }

        /// <summary>
        /// A template to render the value received on the temperature_low_state_topic with.
        /// </summary>
        string TemperatureLowStateTemplate { get; }

        /// <summary>
        /// The MQTT topic to subscribe for changes in the target low temperature. If this is not
        /// set, the target low temperature works in optimistic mode (see below).
        /// </summary>
        string TemperatureLowStateTopic { get; }

        /// <summary>
        /// A template to render the value received on the temperature_state_topic with.
        /// </summary>
        string TemperatureStateTemplate { get; }

        /// <summary>
        /// The MQTT topic to subscribe for changes in the target temperature. If this is not set,
        /// the target temperature works in optimistic mode (see below).
        /// </summary>
        string TemperatureStateTopic { get; }

        /// <summary>
        /// Step size for temperature set point.
        /// </summary>
        float? TempStep { get; }
    }
}
