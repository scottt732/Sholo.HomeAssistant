using Sholo.HomeAssistant.Mqtt.Entities.Fan;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Fan;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Fan
{
    public class FanEntityDefinitionBuilder
        : BaseCoreSwitchEntityDefinitionBuilder<FanEntityDefinitionBuilder, IFanEntityDefinition, FanEntityDefinition>,
            IFanEntityDefinitionBuilder<FanEntityDefinitionBuilder>
    {
        public FanEntityDefinitionBuilder WithOscillationCommandTopic(string oscillationCommandTopic)
        {
            Target.OscillationCommandTopic = oscillationCommandTopic;
            return this;
        }

        public FanEntityDefinitionBuilder WithOscillationStateTopic(string oscillationStateTopic, string oscillationValueTemplate = null)
        {
            Target.OscillationStateTopic = oscillationStateTopic;
            Target.OscillationValueTemplate = oscillationValueTemplate;
            return this;
        }

        public FanEntityDefinitionBuilder WithSpeedPayloads(string lowSpeedPayload = "low", string mediumSpeedPayload = "medium", string highSpeedPayload = "high")
        {
            Target.PayloadLowSpeed = lowSpeedPayload;
            Target.PayloadMediumSpeed = mediumSpeedPayload;
            Target.PayloadHighSpeed = highSpeedPayload;
            return this;
        }

        public FanEntityDefinitionBuilder WithOscillationPayloads(string oscillationOnPayload = "oscillate_on", string oscillationOffPayload = "oscillate_off")
        {
            Target.PayloadOscillationOn = oscillationOnPayload;
            Target.PayloadOscillationOff = oscillationOffPayload;
            return this;
        }

        public FanEntityDefinitionBuilder WithSpeedCommandTopic(string speedCommandTopic)
        {
            Target.SpeedCommandTopic = speedCommandTopic;
            return this;
        }

        public FanEntityDefinitionBuilder WithSpeedStateTopic(string speedStateTopic, string speedValueTemplate = null)
        {
            Target.SpeedStateTopic = speedStateTopic;
            Target.SpeedValueTemplate = speedValueTemplate;
            return this;
        }

        public FanEntityDefinitionBuilder WithSpeeds(params FanSpeed[] speeds)
        {
            Target.Speeds = speeds;
            return this;
        }
    }
}