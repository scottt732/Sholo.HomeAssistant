using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt;

[PublicAPI]
public interface IButton : IStatefulEntity
{
    Task<bool> Invoke(ICommandContext<IButton, IButtonEntityDefinition> context, string payload);
}
