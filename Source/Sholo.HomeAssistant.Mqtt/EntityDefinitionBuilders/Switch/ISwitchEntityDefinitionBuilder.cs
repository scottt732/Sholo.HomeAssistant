using JetBrains.Annotations;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Switch;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Switch
{
    [PublicAPI]
    public interface ISwitchEntityDefinitionBuilder<out TSelf> : ICoreSwitchEntityDefinitionBuilder<TSelf, ISwitchEntityDefinition>
        where TSelf : ISwitchEntityDefinitionBuilder<TSelf>
    {
        TSelf WithIcon(string icon);
        TSelf WithOnOffPayloads(string onPayload = "ON", string offPayload = "OFF");
        TSelf WithOnOffStates(string onState = "ON", string offState = "OFF");
    }
}
