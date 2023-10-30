using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

[PublicAPI]
public interface ISwitchEntityDefinitionBuilder<out TSelf> : ICoreSwitchEntityDefinitionBuilder<TSelf, ISwitchEntityDefinition>
    where TSelf : ISwitchEntityDefinitionBuilder<TSelf>
{
    TSelf WithIcon(string icon);
    TSelf WithOnOffPayloads(string onPayload = "ON", string offPayload = "OFF");
    TSelf WithOnOffStates(string onState = "ON", string offState = "OFF");
}
