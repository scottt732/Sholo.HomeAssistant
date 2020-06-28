using JetBrains.Annotations;
using Sholo.HomeAssistant.Mqtt.Entities.Fan;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Fan;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Fan
{
    [PublicAPI]
    public interface IFanEntityDefinitionBuilder<out TSelf> : ICoreSwitchEntityDefinitionBuilder<TSelf, IFanEntityDefinition>
        where TSelf : IFanEntityDefinitionBuilder<TSelf>
    {
        TSelf WithOscillationCommandTopic(string oscillationCommandTopic);
        TSelf WithOscillationStateTopic(string oscillationStateTopic, string oscillationValueTemplate);
        TSelf WithSpeedPayloads(string lowSpeedPayload = "low", string mediumSpeedPayload = "medium", string highSpeedPayload = "high");
        TSelf WithOscillationPayloads(string oscillationOnPayload = "oscillate_on", string oscillationOffPayload = "oscillate_off");
        TSelf WithSpeedCommandTopic(string speedCommandTopic);
        TSelf WithSpeedStateTopic(string speedStateTopic, string speedValueTemplate);
        TSelf WithSpeeds(params FanSpeed[] speeds);
    }
}
