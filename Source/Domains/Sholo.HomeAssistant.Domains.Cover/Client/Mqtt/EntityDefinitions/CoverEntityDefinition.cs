using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public class CoverEntityDefinition : BaseCoreSwitchEntityDefinition, ICoverEntityDefinition
{
    public CoverDeviceClass? DeviceClass { get; internal set; }
    public string PayloadClose { get; internal set; } = null!;
    public string PayloadOpen { get; internal set; } = null!;
    public string PayloadStop { get; internal set; } = null!;
    public int? PositionClosed { get; internal set; }
    public int? PositionOpen { get; internal set; }
    public string PositionTopic { get; internal set; } = null!;
    public string SetPositionTemplate { get; internal set; } = null!;
    public string SetPositionTopic { get; internal set; } = null!;
    public string StateClosed { get; internal set; } = null!;
    public string StateClosing { get; internal set; } = null!;
    public string StateOpen { get; internal set; } = null!;
    public string StateOpening { get; internal set; } = null!;
    public int? TiltClosedValue { get; internal set; }
    public string TiltCommandTopic { get; internal set; } = null!;
    public bool? TiltInvertState { get; internal set; }
    public int? TiltMax { get; internal set; }
    public int? TiltMin { get; internal set; }
    public int? TiltOpenedValue { get; internal set; }
    public bool? TiltOptimistic { get; internal set; }
    public string TiltStatusTemplate { get; internal set; } = null!;
    public string TiltStatusTopic { get; internal set; } = null!;
}
