using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Switch;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Switch
{
    public class SwitchEntityDefinitionBuilder
        : BaseCoreSwitchEntityDefinitionBuilder<SwitchEntityDefinitionBuilder, ISwitchEntityDefinition, SwitchEntityDefinition>,
            ISwitchEntityDefinitionBuilder<SwitchEntityDefinitionBuilder>
    {
        public SwitchEntityDefinitionBuilder WithIcon(string icon)
        {
            Target.Icon = icon;
            return this;
        }

        public SwitchEntityDefinitionBuilder WithOnOffPayloads(string onPayload = "ON", string offPayload = "OFF")
        {
            Target.PayloadOn = onPayload;
            Target.PayloadOff = offPayload;
            return this;
        }

        public SwitchEntityDefinitionBuilder WithOnOffStates(string onState = "ON", string offState = "OFF")
        {
            Target.StateOn = onState;
            Target.StateOff = offState;
            return this;
        }
    }
}
