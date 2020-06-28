using Sholo.HomeAssistant.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders
{
    public abstract class BaseCoreSensorEntityDefinitionBuilder<TBuilder, TResultInterface, TResult>
        : BaseStatefulEntityDefinitionBuilder<TBuilder, TResultInterface, TResult>
            where TBuilder : BaseCoreSensorEntityDefinitionBuilder<TBuilder, TResultInterface, TResult>
            where TResultInterface : ICoreSensorEntityDefinition
            where TResult : BaseCoreSensorEntityDefinition, TResultInterface, new()
    {
    }
}
