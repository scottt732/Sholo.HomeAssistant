using JetBrains.Annotations;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders
{
    [PublicAPI]
    public interface ICoreSwitchEntityDefinitionBuilder<out TSelf, out TResult> : IStatefulEntityDefinitionBuilder<TSelf, TResult>
        where TSelf : ICoreSwitchEntityDefinitionBuilder<TSelf, TResult>
        where TResult : IStatefulEntityDefinition
    {
        TSelf WithCommandTopic(string commandTopic);
        TSelf WithOptimisticMode(bool optimisticMode);
    }
}
