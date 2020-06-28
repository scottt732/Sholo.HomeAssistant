using Sholo.HomeAssistant.Mqtt.EntityDefinitions.AlarmControlPanel;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.AlarmControlPanel
{
    public class AlarmControlPanelEntityDefinitionBuilder
        : BaseStatefulEntityDefinitionBuilder<AlarmControlPanelEntityDefinitionBuilder, IAlarmControlPanelEntityDefinition, AlarmControlPanelEntityDefinition>,
            IAlarmControlPanelEntityDefinitionBuilder<AlarmControlPanelEntityDefinitionBuilder>
    {
        public AlarmControlPanelEntityDefinitionBuilder WithCode(string code, bool requiredToArm = true, bool requiredToDisarm = true)
        {
            Target.Code = code;
            Target.CodeArmRequired = requiredToArm;
            Target.CodeDisarmRequired = requiredToDisarm;
            return this;
        }

        public AlarmControlPanelEntityDefinitionBuilder WithCommandTopic(string commandTopic, string commandTemplate)
        {
            Target.CommandTopic = commandTopic;
            Target.CommandTemplate = commandTemplate;
            return this;
        }

        public AlarmControlPanelEntityDefinitionBuilder WithArmDisarmPayloads(string armHomePayload = "ARM_HOME", string armAwayPayload = "ARM_AWAY", string armNightPayload = "ARM_NIGHT", string disarmPayload = "DISARM")
        {
            Target.PayloadArmHome = armHomePayload;
            Target.PayloadArmAway = armAwayPayload;
            Target.PayloadArmNight = armNightPayload;
            Target.PayloadDisarm = disarmPayload;
            return this;
        }
    }
}