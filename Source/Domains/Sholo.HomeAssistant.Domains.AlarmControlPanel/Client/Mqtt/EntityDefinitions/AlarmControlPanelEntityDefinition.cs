namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

public class AlarmControlPanelEntityDefinition : BaseStatefulEntityDefinition, IAlarmControlPanelEntityDefinition
{
    public string Code { get; internal set; } = null!;
    public bool? CodeArmRequired { get; internal set; }
    public bool? CodeDisarmRequired { get; internal set; }
    public string CommandTemplate { get; internal set; } = null!;
    public string CommandTopic { get; internal set; } = null!;
    public string PayloadArmAway { get; internal set; } = null!;
    public string PayloadArmHome { get; internal set; } = null!;
    public string PayloadArmNight { get; internal set; } = null!;
    public string PayloadDisarm { get; internal set; } = null!;
}
