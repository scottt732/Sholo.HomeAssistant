using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

[PublicAPI]
public interface IClimateEntityDefinitionBuilder<out TSelf> : IStatefulEntityDefinitionBuilder<TSelf, IClimateEntityDefinition>
    where TSelf : IClimateEntityDefinitionBuilder<TSelf>
{
    TSelf WithActionTopic(string actionTopic, string actionTemplate);
    TSelf WithAuxCommandTopic(string auxCommandTopic);
    TSelf WithAuxStateTopic(string auxStateTopic, string auxStateTemplate);
    TSelf WithAwayModeCommandTopic(string awayModeCommandTopic);
    TSelf WithAwayModeStateTopic(string awayModeStateTopic, string awayModeStateTemplate);
    TSelf WithCurrentTemperatureTopic(string currentTemperatureTopic, string currentTemperatureTemplate);
    TSelf WithFanModeCommandTopic(string fanModeCommandTopic);
    TSelf WithFanModeStateTopic(string fanModeStateTopic, string fanModeStateTemplate);
    TSelf WithFanModes(params string[] fanModes);
    TSelf WithHoldCommandTopic(string holdCommandTopic);
    TSelf WithHoldStateTopic(string holdStateTopic, string holdStateTemplate);
    TSelf WithHoldModes(params string[] holdModes);
    TSelf WithInitial(string initial);
    TSelf WithMinTemp(float minTemp);
    TSelf WithMaxTemp(float maxTemp);
    TSelf WithModeCommandTopic(string modeCommandTopic);
    TSelf WithModeStateTopic(string modeStateTopic, string modeStateTemplate);
    TSelf WithModes(params string[] modes);
    TSelf WithOnOffPayloads(string payloadOn, string payloadOff);
    TSelf WithPowerCommandTopic(string powerCommandTopic);
    TSelf WithPrecision(float precision);
    TSelf WithSendIfOff(bool sendIfOff);
    TSelf WithSwingModeCommandTopic(string swingModeCommandTopic);
    TSelf WithSwingModeStateTopic(string swingModeStateTopic, string swingModeStateTemplate);
    TSelf WithSwingModes(params string[] swingModes);
    TSelf WithTemperatureCommandTopic(string temperatureCommandTopic);
    TSelf WithTemperatureHighCommandTopic(string temperatureHighCommandTopic);
    TSelf WithTemperatureHighStateTopic(string temperatureHighStateTopic, string temperatureHighStateTemplate);
    TSelf WithTemperatureLowCommandTopic(string temperatureLowCommandTopic);
    TSelf WithTemperatureLowStateTopic(string temperatureLowStateTopic, string temperatureLowStateTemplate);
    TSelf WithTemperatureStateTopic(string temperatureStateTopic, string temperatureStateTemplate);
    TSelf WithTempStep(float tempStep);
}
