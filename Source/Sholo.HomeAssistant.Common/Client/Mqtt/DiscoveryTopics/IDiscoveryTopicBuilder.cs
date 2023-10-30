namespace Sholo.HomeAssistant.Client.Mqtt.DiscoveryTopics;

[PublicAPI]
public interface IDiscoveryTopicBuilder
{
    /// <summary>
    /// (Optional): ID of the node providing the topic, this is not used by Home Assistant but may be used
    /// to structure the MQTT topic. The ID of the node must only consist of characters from the character
    /// class [a-zA-Z0-9_-] (alphanumerics, underscore and hyphen).
    /// </summary>
    /// <param name="nodeId">The Node ID</param>
    /// <returns>The <see cref="IDiscoveryTopicBuilder" /></returns>
    IDiscoveryTopicBuilder WithNodeId(string nodeId);

    /// <summary>
    /// The ID of the device. This is only to allow for separate topics for each device and is not used for
    /// the entity_id. The ID of the device must only consist of characters from the character class
    /// [a-zA-Z0-9_-] (alphanumerics, underscore and hyphen).
    /// </summary>
    /// <param name="objectId">The Object ID</param>
    /// <returns>The <see cref="IDiscoveryTopicBuilder" /></returns>
    IDiscoveryTopicBuilder WithObjectId(string objectId);

    string Build();
}
