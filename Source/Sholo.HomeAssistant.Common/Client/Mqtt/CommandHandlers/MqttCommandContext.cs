using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Sholo.HomeAssistant.Client.Mqtt.ApplicationMessage;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;

[PublicAPI]
public interface ICommandContext
{
    string Topic { get; }
    ArraySegment<byte> Payload { get; }
    QualityOfServiceLevel QualityOfServiceLevel { get; }
    bool Retain { get; }
    IReadOnlyDictionary<string, StringValues> UserProperties { get; }
    string? ContentType { get; }
    string? ResponseTopic { get; }
    PayloadFormatIndicator? PayloadFormatIndicator { get; }
    uint? MessageExpiryInterval { get; }
    ushort? TopicAlias { get; }
    byte[]? CorrelationData { get; }
    uint[]? SubscriptionIdentifiers { get; }
    string ClientId { get; }

    Task PublishAsync(IApplicationMessage message, CancellationToken cancellationToken = default);
}

[PublicAPI]
public interface ICommandContext<TEntity, TEntityDefinition> : ICommandContext
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
    TEntity Entity { get; set; }
    TEntityDefinition EntityDefinition { get; set; }
}
