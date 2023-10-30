using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

[PublicAPI]
public interface ICameraEntityDefinitionBuilder<out TSelf> : IEntityDefinitionBuilder<TSelf, ICameraEntityDefinition>
    where TSelf : ICameraEntityDefinitionBuilder<TSelf>
{
    TSelf WithTopic(string topic);
}
