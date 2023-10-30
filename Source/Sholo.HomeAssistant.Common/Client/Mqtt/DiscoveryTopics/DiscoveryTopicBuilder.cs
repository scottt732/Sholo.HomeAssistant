using System;
using Sholo.HomeAssistant.Utilities;

namespace Sholo.HomeAssistant.Client.Mqtt.DiscoveryTopics;

[PublicAPI]
public class DiscoveryTopicBuilder : IDiscoveryTopicBuilder
{
    private string ComponentType { get; set; }
    private string? DiscoveryComponentType { get; set; }
    private string DiscoveryPrefix { get; set; }
    private string? NodeId { get; set; }
    private string ObjectId { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="DiscoveryTopicBuilder"/> class.
    /// </summary>
    /// <param name="componentType">The type of component being built</param>
    /// <param name="discoveryPrefix">(Optional) The prefix for the discovery topic. Default value: homeassistant</param>
    /// <param name="discoveryComponentType">The component type used for discovery (if different than <paramref name="componentType" />). See <a href="https://www.home-assistant.io/integrations/device_trigger.mqtt/">device_trigger for an example</a></param>
    public DiscoveryTopicBuilder(string componentType, string discoveryPrefix = "homeassistant", string? discoveryComponentType = null)
    {
        IdentifierValidator.ValidateDiscoveryPrefix(discoveryPrefix);
        ComponentType = componentType;
        DiscoveryPrefix = discoveryPrefix;
        DiscoveryComponentType = discoveryComponentType;
    }

    public IDiscoveryTopicBuilder WithNodeId(string nodeId)
    {
        IdentifierValidator.ValidateNodeId(nodeId);
        NodeId = nodeId;
        return this;
    }

    public IDiscoveryTopicBuilder WithObjectId(string objectId)
    {
        IdentifierValidator.ValidateObjectId(objectId);
        ObjectId = objectId;
        return this;
    }

    public string Build()
    {
        if (ObjectId == null) throw new InvalidOperationException($"You must call {nameof(WithObjectId)} before building");

        var discoveryTopicComponentType = DiscoveryComponentType ?? ComponentType;

        if (NodeId != null)
        {
            return $"{DiscoveryPrefix}/{discoveryTopicComponentType}/{NodeId}/{ObjectId}/config";
        }
        else
        {
            return $"{DiscoveryPrefix}/{discoveryTopicComponentType}/{ObjectId}/config";
        }
    }
}
