using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

[PublicAPI]
public interface IButtonEntityDefinitionBuilder<out TSelf> : IStatefulEntityDefinitionBuilder<TSelf, IButtonEntityDefinition>
    where TSelf : IButtonEntityDefinitionBuilder<TSelf>
{
    TSelf WithCommandTemplate(string? commandTemplate);
    TSelf WithCommandTopic(string? commandTopic);
    TSelf WithDeviceClass(ButtonDeviceClass? deviceClass);
    TSelf WithEnabledByDefault(bool? enabledByDefault);
    TSelf WithEncoding(string? encoding);
    TSelf WithEntityCategory(string? entityCategory);
    TSelf WithIcon(string? icon);
    TSelf WithPayloadPress(string? payloadPress);
}
