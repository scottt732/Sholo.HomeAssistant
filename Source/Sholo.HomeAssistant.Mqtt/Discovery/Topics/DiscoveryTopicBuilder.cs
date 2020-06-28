using System;
using JetBrains.Annotations;
using Sholo.HomeAssistant.Utilities;

namespace Sholo.HomeAssistant.Mqtt.Discovery.Topics
{
    [PublicAPI]
    public class DiscoveryTopicBuilder : IDiscoveryTopicBuilder
    {
        private ComponentType ComponentType { get; set; }
        private string DiscoveryPrefix { get; set; }
        private string NodeId { get; set; }
        private string ObjectId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscoveryTopicBuilder"/> class.
        /// </summary>
        /// <param name="componentType">The type of component being built</param>
        /// <param name="discoveryPrefix">(Optional) The prefix for the discovery topic. Default value: homeassistant</param>
        public DiscoveryTopicBuilder(ComponentType componentType, string discoveryPrefix = "homeassistant")
        {
            IdentifierValidator.ValidateDiscoveryPrefix(discoveryPrefix);
            ComponentType = componentType;
            DiscoveryPrefix = discoveryPrefix;
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

            var discoveryTopicComponentType = ComponentType.GetHomeAssistantDiscoveryMqttValue()
                                              ?? ComponentType.GetHomeAssistantMqttValue();

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
}
