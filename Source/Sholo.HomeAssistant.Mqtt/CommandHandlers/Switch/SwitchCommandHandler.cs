using System;
using System.Threading.Tasks;
using Sholo.HomeAssistant.Mqtt.Entities.Switch;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Switch;

namespace Sholo.HomeAssistant.Mqtt.CommandHandlers.Switch
{
    public class SwitchCommandHandler : ICommandHandler<ISwitch, ISwitchEntityDefinition>
    {
        public string GetTopicPattern(ISwitchEntityDefinition entityDefinition) => entityDefinition.CommandTopic;

        public Task<bool> ProcessCommand(MqttCommandContext<ISwitch, ISwitchEntityDefinition> context, string payload)
        {
            if (payload.Equals(context.EntityDefinition.PayloadOn, StringComparison.Ordinal))
            {
                context.Entity.Value = SwitchState.On;
                return Task.FromResult(true);
            }
            else if (payload.Equals(context.EntityDefinition.PayloadOff, StringComparison.Ordinal))
            {
                context.Entity.Value = SwitchState.Off;
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
