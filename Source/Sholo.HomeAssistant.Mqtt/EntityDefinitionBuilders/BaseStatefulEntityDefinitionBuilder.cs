using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders
{
    public abstract class BaseStatefulEntityDefinitionBuilder<TBuilder, TResultInterface, TResult>
        : BaseEntityDefinitionBuilder<TBuilder, TResultInterface, TResult>,
            IStatefulEntityDefinitionBuilder<TBuilder, TResultInterface>
                where TBuilder : BaseStatefulEntityDefinitionBuilder<TBuilder, TResultInterface, TResult>
                where TResultInterface : IStatefulEntityDefinition
                where TResult : BaseStatefulEntityDefinition, TResultInterface, new()
    {
        public TBuilder WithAvailabilityPayloads(string payloadAvailable = "online", string payloadNotAvailable = "offline")
        {
            Target.PayloadAvailable = payloadAvailable;
            Target.PayloadNotAvailable = payloadNotAvailable;
            return (TBuilder)this;
        }

        public TBuilder WithAvailabilityTopic(string availabilityTopic)
        {
            Target.AvailabilityTopic = availabilityTopic;
            return (TBuilder)this;
        }

        public TBuilder WithJsonAttributes(string jsonAttributesTopic, string jsonAttributesTemplate)
        {
            Target.JsonAttributesTopic = jsonAttributesTopic;
            Target.JsonAttributesTemplate = jsonAttributesTemplate;
            return (TBuilder)this;
        }

        public TBuilder WithQos(MqttQualityOfServiceLevel qos = MqttQualityOfServiceLevel.AtMostOnce, bool retain = false)
        {
            Target.Qos = qos;
            Target.Retain = retain;
            return (TBuilder)this;
        }

        public TBuilder WithState(string stateTopic, string valueTemplate = null)
        {
            Target.StateTopic = stateTopic;
            Target.ValueTemplate = valueTemplate;
            return (TBuilder)this;
        }
    }
}
