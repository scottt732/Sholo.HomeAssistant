using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using MQTTnet;
using Sholo.HomeAssistant.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.DeviceTrigger;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Lock;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Switch;
using Sholo.Mqtt.Consumer;

namespace Sholo.HomeAssistant.Mqtt.Dispatchers
{
    internal class HomeAssistantIncomingMqttDispatcher : IConfigureMqttApplicationBuilder
    {
        private List<IDeviceTriggerMqttEntityConfiguration> DeviceTriggerConfigurations { get; }
        private List<ISwitchMqttEntityConfiguration> SwitchConfigurations { get; }
        private List<ILockMqttEntityConfiguration> LockConfigurations { get; }
        private ILogger Logger { get; }

        public HomeAssistantIncomingMqttDispatcher(
            IEnumerable<IDeviceTriggerMqttEntityConfiguration> deviceTriggerConfigurations,
            IEnumerable<ILockMqttEntityConfiguration> lockConfigurations,
            IEnumerable<ISwitchMqttEntityConfiguration> switchConfigurations,
            ILogger<HomeAssistantIncomingMqttDispatcher> logger)
        {
            DeviceTriggerConfigurations = deviceTriggerConfigurations.ToList();
            SwitchConfigurations = switchConfigurations.ToList();
            LockConfigurations = lockConfigurations.ToList();
            Logger = logger;
        }

        public void Configure(IMqttApplicationBuilder mqttApplicationBuilder)
        {
            ConfigureCommands(DeviceTriggerConfigurations, mqttApplicationBuilder);
            ConfigureCommands(LockConfigurations, mqttApplicationBuilder);
            ConfigureCommands(SwitchConfigurations, mqttApplicationBuilder);
        }

        private void ConfigureCommands<TEntity, TEntityDefinition>(
            IEnumerable<IMqttEntityConfiguration<TEntity, TEntityDefinition>> configurations,
            IMqttApplicationBuilder mqttApplicationBuilder
        )
                where TEntity : IEntity
                where TEntityDefinition : IEntityDefinition
        {
            var topicHandlers = configurations
                .SelectMany(x => x.CommandHandlers.Select(y => (configuration: x, commandHandler: y)))
                .GroupBy(x => (topicPattern: x.commandHandler.GetTopicPattern(x.configuration.EntityDefinition), qualityOfServiceLevel: x.configuration.DiscoveryMessageQualityOfServiceLevel))
                .ToDictionary(x => x.Key, x => x.ToArray());

            foreach (var topicHandler in topicHandlers)
            {
                var topicPattern = topicHandler.Key.topicPattern;
                var qualityOfServiceLevel = topicHandler.Key.qualityOfServiceLevel;

                mqttApplicationBuilder.Map(
                    topicPattern,
                    async ctx =>
                    {
                        var payload = ctx.ConvertPayloadToString();
                        Logger.LogInformation("> [{topic}] {payload}", ctx.Topic, payload);

                        foreach (var (cfg, handler) in topicHandler.Value)
                        {
                            var commandContext = new MqttCommandContext<TEntity, TEntityDefinition>(ctx, cfg.Entity, cfg.EntityDefinition);
                            var result = await handler.ProcessCommand(commandContext, payload);
                            if (result)
                            {
                                return true;
                            }
                        }

                        return false;
                    },
                    qualityOfServiceLevel);
            }
        }
    }
}
