using JetBrains.Annotations;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.AlarmControlPanel;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.AlarmControlPanel
{
    [PublicAPI]
    public interface IAlarmControlPanelEntityDefinitionBuilder<out TSelf> : IStatefulEntityDefinitionBuilder<TSelf, IAlarmControlPanelEntityDefinition>
        where TSelf : IAlarmControlPanelEntityDefinitionBuilder<TSelf>
    {
        TSelf WithCode(string code, bool requiredToArm = true, bool requiredToDisarm = true);
        TSelf WithCommandTopic(string commandTopic, string commandTemplate);
        TSelf WithArmDisarmPayloads(string armHomePayload = "ARM_HOME", string armAwayPayload = "ARM_AWAY", string armNightPayload = "ARM_NIGHT", string disarmPayload = "DISARM");
    }
}
