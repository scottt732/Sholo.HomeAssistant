using JetBrains.Annotations;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Camera;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Camera
{
    [PublicAPI]
    public interface ICameraEntityDefinitionBuilder<out TSelf> : IEntityDefinitionBuilder<TSelf, ICameraEntityDefinition>
        where TSelf : ICameraEntityDefinitionBuilder<TSelf>
    {
        TSelf WithTopic(string topic);
    }
}
