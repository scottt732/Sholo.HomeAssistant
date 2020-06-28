using System;
using System.Reactive;
using System.Threading.Tasks;
using Sholo.HomeAssistant.Mqtt.Entities.DeviceTrigger;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.DeviceTrigger;

namespace Sholo.HomeAssistant.Mqtt.CommandHandlers.DeviceTrigger
{
    public class DeviceTriggerCommandHandler : ICommandHandler<IDeviceTrigger, IDeviceTriggerEntityDefinition>
    {
        public string GetTopicPattern(IDeviceTriggerEntityDefinition entityDefinition) => entityDefinition.Topic;

        public Task<bool> ProcessCommand(MqttCommandContext<IDeviceTrigger, IDeviceTriggerEntityDefinition> context, string payload)
        {
            if (payload.Equals(context.EntityDefinition.Payload, StringComparison.Ordinal))
            {
                context.Entity.TriggerSubject.OnNext(Unit.Default);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
