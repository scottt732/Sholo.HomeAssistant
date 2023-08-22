using System.Collections.Generic;
using System.Threading.Tasks;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.MqttEntityBindings;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;
using Sholo.Mqtt;
using Sholo.Mqtt.Application.Builder;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityBindingManagers;

public class EntityCommandMiddleware<TMqttEntityConfiguration, TEntity, TEntityDefinition> : IMqttMiddleware
    where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
    private IDictionary<(string topicPattern, MqttQualityOfServiceLevel? qualityOfServiceLevel), (IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition> configuration, ICommandHandler<TEntity, TEntityDefinition> commandHandler)[]> TopicHandlers { get; }

    public EntityCommandMiddleware(IDictionary<(string topicPattern, MQTTnet.Protocol.MqttQualityOfServiceLevel? qualityOfServiceLevel), (IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition> configuration, ICommandHandler<TEntity, TEntityDefinition> commandHandler)[]> topicHandlers)
    {
        TopicHandlers = topicHandlers;
    }

    public async Task<bool> InvokeAsync(MqttRequestContext context, MqttRequestDelegate next)
    {
        foreach (var topicHandler in TopicHandlers)
        {
            var topicPattern = topicHandler.Key.topicPattern;
            var qualityOfServiceLevel = topicHandler.Key.qualityOfServiceLevel;

            var payload = System.Text.Encoding.UTF8.GetString(context.Payload);

            foreach (var (cfg, handler) in topicHandler.Value)
            {
                var commandContext = new MqttCommandContext<TEntity, TEntityDefinition>(context, cfg.EntityConfiguration.Entity, cfg.EntityConfiguration.EntityDefinition);
                var result = await handler.ProcessCommand(commandContext, payload);

                if (result)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
