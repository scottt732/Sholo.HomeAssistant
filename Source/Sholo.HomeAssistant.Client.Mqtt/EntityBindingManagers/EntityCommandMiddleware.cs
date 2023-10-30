using System.Threading.Tasks;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.Mqtt;
using Sholo.Mqtt.Application.Builder;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;

public class EntityCommandMiddleware<TMqttEntityConfiguration, TEntity, TEntityDefinition> : IMqttMiddleware
    where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
    private IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> EntityBindingManager { get; }

    public EntityCommandMiddleware(IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> entityBindingManager)
    {
        EntityBindingManager = entityBindingManager;
    }

    public async Task<bool> InvokeAsync(MqttRequestContext context, MqttRequestDelegate next)
    {
        foreach (var messageHandler in EntityBindingManager.GetTopicMessageHandlers())
        {
            var result = await messageHandler.Invoke(context);
            if (result)
            {
                return true;
            }
        }

        return false;
    }
}
