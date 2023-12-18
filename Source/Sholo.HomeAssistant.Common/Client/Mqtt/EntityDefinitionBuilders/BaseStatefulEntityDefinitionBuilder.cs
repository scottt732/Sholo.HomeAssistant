using System;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

public abstract class BaseStatefulEntityDefinitionBuilder<TBuilder, TResultInterface, TResult>
    : BaseEntityDefinitionBuilder<TBuilder, TResultInterface, TResult>,
        IStatefulEntityDefinitionBuilder<TBuilder, TResultInterface>
    where TBuilder : BaseStatefulEntityDefinitionBuilder<TBuilder, TResultInterface, TResult>
    where TResultInterface : IStatefulEntityDefinition
    where TResult : BaseStatefulEntityDefinition, TResultInterface, new()
{
    public TBuilder WithAvailability(Action<IAvailabilitiesBuilder> config)
    {
        var availabilitiesBuilder = new AvailabilitiesBuilder();
        config.Invoke(availabilitiesBuilder);
        var availabilities = availabilitiesBuilder.Build();
        foreach (var availability in availabilities)
        {
            Target.Availability.Add(availability);
        }

        return (TBuilder)this;
    }

    public TBuilder WithAvailability(params Availability[] availabilities)
    {
        foreach (var availability in availabilities)
        {
            Target.Availability.Add(availability);
        }

        return (TBuilder)this;
    }

    public TBuilder WithAvailability(string availabilityTopic, string payloadAvailable = "online", string payloadNotAvailable = "offline", string? valueTemplate = null)
    {
        Target.Availability.Add(
            new Availability
            {
                Topic = availabilityTopic,
                PayloadAvailable = payloadAvailable,
                PayloadNotAvailable = payloadNotAvailable,
                ValueTemplate = valueTemplate
            });
        return (TBuilder)this;
    }

    public TBuilder WithAvailabilityMode(AvailabilityMode? availabilityMode)
    {
        Target.AvailabilityMode = availabilityMode ?? AvailabilityMode.Latest;
        return (TBuilder)this;
    }

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

    public TBuilder WithJsonAttributes(string jsonAttributesTopic, string? jsonAttributesTemplate)
    {
        Target.JsonAttributesTopic = jsonAttributesTopic;
        Target.JsonAttributesTemplate = jsonAttributesTemplate;
        return (TBuilder)this;
    }

    public TBuilder WithQos(QualityOfServiceLevel qos = QualityOfServiceLevel.AtMostOnce, bool retain = false)
    {
        Target.Qos = qos;
        Target.Retain = retain;
        return (TBuilder)this;
    }

    public TBuilder WithState(string stateTopic, string? valueTemplate = null)
    {
        Target.StateTopic = stateTopic;
        Target.ValueTemplate = valueTemplate;
        return (TBuilder)this;
    }
}
