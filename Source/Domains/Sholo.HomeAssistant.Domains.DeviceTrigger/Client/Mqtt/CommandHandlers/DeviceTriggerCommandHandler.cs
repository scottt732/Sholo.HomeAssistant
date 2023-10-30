using System.Reactive;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;

public class DeviceTriggerCommandHandler : ICommandHandler<IDeviceTrigger, IDeviceTriggerEntityDefinition>
{
    public string GetTopicPattern(IDeviceTriggerEntityDefinition entityDefinition) => entityDefinition.Topic;

    public Task<bool> ProcessCommandAsync(ICommandContext<IDeviceTrigger, IDeviceTriggerEntityDefinition> context, string payload)
    {
        if (payload.Equals(context.EntityDefinition.Payload, StringComparison.Ordinal))
        {
            context.Entity.TriggerSubject.OnNext(Unit.Default);
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }
}
