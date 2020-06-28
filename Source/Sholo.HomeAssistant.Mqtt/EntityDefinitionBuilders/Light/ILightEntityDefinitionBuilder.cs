using JetBrains.Annotations;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Light;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Light
{
    [PublicAPI]
    public interface ILightEntityDefinitionBuilder<out TSelf> : ICoreSwitchEntityDefinitionBuilder<TSelf, ILightEntityDefinition>
        where TSelf : ILightEntityDefinitionBuilder<TSelf>
    {
        TSelf WithBrightnessCommandTopic(string brightnessCommandTopic);
        TSelf WithBrightnessScale(int brightnessScale);
        TSelf WithBrightnessStateTopic(string brightnessStateTopic, string brightnessValueTemplate);
        TSelf WithColorTempCommandTopic(string colorTempCommandTopic, string colorTempCommandTemplate);
        TSelf WithColorTempStateTopic(string colorTempStateTopic, string colorTempValueTemplate);
        TSelf WithEffectCommandTopic(string effectCommandTopic);
        TSelf WithEffectList(params string[] effects);
        TSelf WithEffectStateTopic(string effectStateTopic, string effectValueTemplate);
        TSelf WithHsCommandTopic(string hsCommandTopic);
        TSelf WithHsStateTopic(string hsStateTopic, string hsValueTemplate);
        TSelf WithOnCommandType(string onCommandType);
        TSelf WithOnOffPayloads(string onPayload, string offPayload);
        TSelf WithRgbCommandTemplate(string rgbCommandTopic, string rgbValueTemplate);
        TSelf WithRgbStateTopic(string rgbStateTopic, string rgbValueTemplate);
        TSelf WithWhiteValueCommandTopic(string whiteValueCommandTopic);
        TSelf WithWhiteValueScale(int whiteValueScale);
        TSelf WithWhiteValueStateTopic(string whiteValueStateTopic, string whiteValueTemplate);
        TSelf WithXyCommandTopic(string xyCommandTopic);
        TSelf WithXyStateTopic(string xyStateTopic, string xyValueTemplate);
    }
}
