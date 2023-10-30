namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public interface ILightEntityDefinition : ICoreSwitchEntityDefinition
{
    /// <summary>
    /// The MQTT topic to publish commands to change the light's brightness.
    /// </summary>
    string BrightnessCommandTopic { get; }

    /// <summary>
    /// Defines the maximum brightness value (i.e., 100%) of the MQTT device.
    /// </summary>
    int? BrightnessScale { get; }

    /// <summary>
    /// The MQTT topic subscribed to receive brightness state updates.
    /// </summary>
    string BrightnessStateTopic { get; }

    /// <summary>
    /// Defines a template to extract the brightness value.
    /// </summary>
    string BrightnessValueTemplate { get; }

    /// <summary>
    /// Defines a template to compose message which will be sent to color_temp_command_topic.
    /// Available variables: value.
    /// </summary>
    string ColorTempCommandTemplate { get; }

    /// <summary>
    /// The MQTT topic to publish commands to change the light's color temperature state. The
    /// color temperature command slider has a range of 153 to 500 mireds (micro reciprocal
    /// degrees).
    /// </summary>
    string ColorTempCommandTopic { get; }

    /// <summary>
    /// The MQTT topic subscribed to receive color temperature state updates.
    /// </summary>
    string ColorTempStateTopic { get; }

    /// <summary>
    /// Defines a template to extract the color temperature value.
    /// </summary>
    string ColorTempValueTemplate { get; }

    /// <summary>
    /// The MQTT topic to publish commands to change the light's effect state.
    /// </summary>
    string EffectCommandTopic { get; }

    /// <summary>
    /// The list of effects the light supports.
    /// </summary>
    string[] EffectList { get; }

    /// <summary>
    /// The MQTT topic subscribed to receive effect state updates.
    /// </summary>
    string EffectStateTopic { get; }

    /// <summary>
    /// Defines a template to extract the effect value.
    /// </summary>
    string EffectValueTemplate { get; }

    /// <summary>
    /// The MQTT topic to publish commands to change the light's color state in HS format
    /// (Hue Saturation). Range for Hue: 0° .. 360°, Range of Saturation: 0..100. Note:
    /// Brightness is sent separately in the brightness_command_topic.
    /// </summary>
    string HsCommandTopic { get; }

    /// <summary>
    /// The MQTT topic subscribed to receive color state updates in HS format. Note: Brightness
    /// is received separately in the brightness_state_topic.
    /// </summary>
    string HsStateTopic { get; }

    /// <summary>
    /// Defines a template to extract the HS value.
    /// </summary>
    string HsValueTemplate { get; }

    /// <summary>
    /// Defines when on the payload_on is sent. Using last (the default) will send any style
    /// (brightness, color, etc) topics first and then a payload_on to the command_topic. Using
    /// first will send the payload_on and then any style topics. Using brightness will only
    /// send brightness commands instead of the payload_on to turn the light on.
    /// </summary>
    string OnCommandType { get; }

    /// <summary>
    /// The payload that represents disabled state.
    /// </summary>
    string PayloadOff { get; }

    /// <summary>
    /// The payload that represents enabled state.
    /// </summary>
    string PayloadOn { get; }

    /// <summary>
    /// Defines a template to compose message which will be sent to rgb_command_topic. Available
    /// variables: red, green and blue.
    /// </summary>
    string RgbCommandTemplate { get; }

    /// <summary>
    /// The MQTT topic to publish commands to change the light's RGB state. Please note that the
    /// color value sent by Home Assistant is normalized to full brightness if brightness_command_topic
    /// is set. Brightness information is in this case sent separately in the brightness_command_topic.
    /// This will cause a light that expects an absolute color value (including brightness) to flicker.
    /// </summary>
    string RgbCommandTopic { get; }

    /// <summary>
    /// The MQTT topic subscribed to receive RGB state updates. The expected payload is the RGB values
    /// separated by commas, for example, 255,0,127. Please note that the color value received by Home
    /// Assistant is normalized to full brightness. Brightness information is received separately in
    /// the brightness_state_topic.
    /// </summary>
    string RgbStateTopic { get; }

    /// <summary>
    /// Defines a template to extract the RGB value.
    /// </summary>
    string RgbValueTemplate { get; }

    /// <summary>
    /// The MQTT topic to publish commands to change the light's white value.
    /// </summary>
    string WhiteValueCommandTopic { get; }

    /// <summary>
    /// Defines the maximum white value (i.e., 100%) of the MQTT device.
    /// </summary>
    int? WhiteValueScale { get; }

    /// <summary>
    /// The MQTT topic subscribed to receive white value updates.
    /// </summary>
    string WhiteValueStateTopic { get; }

    /// <summary>
    /// Defines a template to extract the white value.
    /// </summary>
    string WhiteValueTemplate { get; }

    /// <summary>
    /// The MQTT topic to publish commands to change the light's XY state.
    /// </summary>
    string XyCommandTopic { get; }

    /// <summary>
    /// The MQTT topic subscribed to receive XY state updates.
    /// </summary>
    string XyStateTopic { get; }

    /// <summary>
    /// Defines a template to extract the XY value.
    /// </summary>
    string XyValueTemplate { get; }
}
