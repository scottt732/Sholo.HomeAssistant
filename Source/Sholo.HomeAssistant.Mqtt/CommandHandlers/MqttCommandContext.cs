using Sholo.Mqtt.Consumer;

namespace Sholo.HomeAssistant.Mqtt.CommandHandlers
{
    public class MqttCommandContext<TEntity, TEntityDefinition> : MqttRequestContext
    {
        public TEntity Entity { get; set; }
        public TEntityDefinition EntityDefinition { get; set; }

        public MqttCommandContext(MqttRequestContext context, TEntity entity, TEntityDefinition entityDefinition)
        {
            Entity = entity;
            EntityDefinition = entityDefinition;
            ContentType = context.ContentType;
            CorrelationData = context.CorrelationData;
            MessageExpiryInterval = context.MessageExpiryInterval;
            Payload = context.Payload;
            PayloadFormatIndicator = context.PayloadFormatIndicator;
            QualityOfServiceLevel = context.QualityOfServiceLevel;
            ResponseTopic = context.ResponseTopic;
            Retain = context.Retain;
            SubscriptionIdentifiers = context.SubscriptionIdentifiers;
            Topic = context.Topic;
            TopicAlias = context.TopicAlias;
            UserProperties = context.UserProperties;
            ClientId = context.ClientId;
        }
    }
}
