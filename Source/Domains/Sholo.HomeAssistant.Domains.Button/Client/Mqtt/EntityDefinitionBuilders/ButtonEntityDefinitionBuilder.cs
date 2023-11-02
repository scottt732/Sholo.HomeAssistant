using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

[PublicAPI]
public class ButtonEntityDefinitionBuilder
    : BaseStatefulEntityDefinitionBuilder<ButtonEntityDefinitionBuilder, IButtonEntityDefinition, ButtonEntityDefinition>,
        IButtonEntityDefinitionBuilder<ButtonEntityDefinitionBuilder>
{
    public ButtonEntityDefinitionBuilder CommandTemplate(string? commandTemplate)
    {
        Target.CommandTemplate = commandTemplate;
        return this;
    }

    public ButtonEntityDefinitionBuilder CommandTopic(string? commandTopic)
    {
        Target.CommandTopic = commandTopic;
        return this;
    }

    public ButtonEntityDefinitionBuilder DeviceClass(ButtonDeviceClass? deviceClass)
    {
        Target.DeviceClass = deviceClass;
        return this;
    }

    public ButtonEntityDefinitionBuilder EnabledByDefault(bool? enabledByDefault)
    {
        Target.EnabledByDefault = enabledByDefault;
        return this;
    }

    public ButtonEntityDefinitionBuilder Encoding(string? encoding)
    {
        Target.Encoding = encoding;
        return this;
    }

    public ButtonEntityDefinitionBuilder EntityCategory(string? entityCategory)
    {
        Target.EntityCategory = entityCategory;
        return this;
    }

    public ButtonEntityDefinitionBuilder Icon(string? icon)
    {
        Target.Icon = icon;
        return this;
    }

    public ButtonEntityDefinitionBuilder WithPayloadPress(string? payloadPress)
    {
        Target.PayloadPress = payloadPress;
        return this;
    }
}
