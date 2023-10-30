using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

[PublicAPI]
public abstract class BaseCoreSwitchEntityDefinitionBuilder<TBuilder, TResultInterface, TResult>
    : BaseStatefulEntityDefinitionBuilder<TBuilder, TResultInterface, TResult>
    where TBuilder : BaseCoreSwitchEntityDefinitionBuilder<TBuilder, TResultInterface, TResult>
    where TResultInterface : ICoreSwitchEntityDefinition
    where TResult : BaseCoreSwitchEntityDefinition, TResultInterface, new()
{
    public TBuilder WithCommandTopic(string commandTopic)
    {
        Target.CommandTopic = commandTopic;
        return (TBuilder)this;
    }

    public TBuilder WithOptimisticMode(bool optimisticMode)
    {
        Target.Optimistic = optimisticMode;
        return (TBuilder)this;
    }
}
