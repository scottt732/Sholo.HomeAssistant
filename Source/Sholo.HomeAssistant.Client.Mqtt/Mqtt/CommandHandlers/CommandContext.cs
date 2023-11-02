using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.MqttNet;
using Sholo.Mqtt;

namespace Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;

public class CommandContext<TEntity, TEntityDefinition> : ICommandContext<TEntity, TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
    public TEntity Entity { get; set; }
    public TEntityDefinition EntityDefinition { get; set; }
    public string Topic => Context.Topic;
    public ArraySegment<byte> Payload => Context.Payload;
    public QualityOfServiceLevel QualityOfServiceLevel { get; }
    public bool Retain => Context.Retain;
    public KeyValuePair<string, string>[] UserProperties { get; }
    public string ContentType => Context.ContentType;
    public string ResponseTopic => Context.ResponseTopic;
    public PayloadFormatIndicator? PayloadFormatIndicator { get; }
    public uint? MessageExpiryInterval => Context.MessageExpiryInterval;
    public ushort? TopicAlias => Context.TopicAlias;
    public byte[] CorrelationData => Context.CorrelationData;
    public uint[] SubscriptionIdentifiers => Context.SubscriptionIdentifiers;
    public string ClientId => Context.ClientId;

    public async Task PublishAsync(IApplicationMessage message, CancellationToken cancellationToken = default)
    {
        await Context.PublishAsync(message.ToMqttNetApplicationMessage(), cancellationToken);
    }

    internal MqttRequestContext Context { get; }

    public CommandContext(MqttRequestContext context, TEntity entity, TEntityDefinition entityDefinition)
    {
        Context = context;
        Entity = entity;
        EntityDefinition = entityDefinition;

        PayloadFormatIndicator = context.PayloadFormatIndicator switch
        {
            MqttPayloadFormatIndicator.Unspecified => Mqtt.PayloadFormatIndicator.Unspecified,
            MqttPayloadFormatIndicator.CharacterData => Mqtt.PayloadFormatIndicator.CharacterData,
            _ => throw new ArgumentOutOfRangeException(nameof(context.PayloadFormatIndicator), $"The {nameof(context.PayloadFormatIndicator)} value is invalid")
        };

        QualityOfServiceLevel = context.QualityOfServiceLevel switch
        {
            MqttQualityOfServiceLevel.AtMostOnce => QualityOfServiceLevel.AtMostOnce,
            MqttQualityOfServiceLevel.AtLeastOnce => QualityOfServiceLevel.AtLeastOnce,
            MqttQualityOfServiceLevel.ExactlyOnce => QualityOfServiceLevel.ExactlyOnce,
            _ => throw new ArgumentOutOfRangeException(nameof(context.QualityOfServiceLevel), $"The {nameof(context.QualityOfServiceLevel)} value is invalid")
        };

        UserProperties = context.MqttUserProperties
            .Select(x => new KeyValuePair<string, string>(x.Name, x.Value))
            .ToArray();
    }
}
