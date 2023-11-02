using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

[PublicAPI]
public interface IButtonEntityDefinitionBuilder<out TSelf> : IStatefulEntityDefinitionBuilder<TSelf, IButtonEntityDefinition>
    where TSelf : IButtonEntityDefinitionBuilder<TSelf>
{
    TSelf CommandTemplate(string? commandTemplate);
    TSelf CommandTopic(string? commandTopic);
    TSelf DeviceClass(ButtonDeviceClass? deviceClass);
    TSelf EnabledByDefault(bool? enabledByDefault);
    TSelf Encoding(string? encoding);
    TSelf EntityCategory(string? entityCategory);
    TSelf Icon(string? icon);
    TSelf WithPayloadPress(string? payloadPress);
}
