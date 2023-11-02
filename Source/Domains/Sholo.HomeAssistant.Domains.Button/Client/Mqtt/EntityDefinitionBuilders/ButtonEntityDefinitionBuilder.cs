using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

[PublicAPI]
public class ButtonEntityDefinitionBuilder
    : BaseStatefulEntityDefinitionBuilder<ButtonEntityDefinitionBuilder, IButtonEntityDefinition, ButtonEntityDefinition>,
        IButtonEntityDefinitionBuilder<ButtonEntityDefinitionBuilder>
{
    public ButtonEntityDefinitionBuilder WithCommandTemplate(string? commandTemplate)
    {
        Target.CommandTemplate = commandTemplate;
        return this;
    }

    public ButtonEntityDefinitionBuilder WithCommandTopic(string? commandTopic)
    {
        if (commandTopic != null)
        {
            Target.CommandTopic = commandTopic;
        }

        return this;
    }

    public ButtonEntityDefinitionBuilder WithDeviceClass(ButtonDeviceClass? deviceClass)
    {
        Target.DeviceClass = deviceClass;
        return this;
    }

    public ButtonEntityDefinitionBuilder WithEnabledByDefault(bool? enabledByDefault)
    {
        Target.EnabledByDefault = enabledByDefault;
        return this;
    }

    public ButtonEntityDefinitionBuilder WithEncoding(string? encoding)
    {
        Target.Encoding = encoding;
        return this;
    }

    public ButtonEntityDefinitionBuilder WithEntityCategory(string? entityCategory)
    {
        Target.EntityCategory = entityCategory;
        return this;
    }

    public ButtonEntityDefinitionBuilder WithIcon(string? icon)
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
