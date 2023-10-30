namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public class LightEntityDefinition : BaseCoreSwitchEntityDefinition, ILightEntityDefinition
{
    public string BrightnessCommandTopic { get; internal set; } = null!;
    public int? BrightnessScale { get; internal set; }
    public string BrightnessStateTopic { get; internal set; } = null!;
    public string BrightnessValueTemplate { get; internal set; } = null!;
    public string ColorTempCommandTemplate { get; internal set; } = null!;
    public string ColorTempCommandTopic { get; internal set; } = null!;
    public string ColorTempStateTopic { get; internal set; } = null!;
    public string ColorTempValueTemplate { get; internal set; } = null!;
    public string EffectCommandTopic { get; internal set; } = null!;
    public string[] EffectList { get; internal set; } = null!;
    public string EffectStateTopic { get; internal set; } = null!;
    public string EffectValueTemplate { get; internal set; } = null!;
    public string HsCommandTopic { get; internal set; } = null!;
    public string HsStateTopic { get; internal set; } = null!;
    public string HsValueTemplate { get; internal set; } = null!;
    public string OnCommandType { get; internal set; } = null!;
    public string PayloadOff { get; internal set; } = null!;
    public string PayloadOn { get; internal set; } = null!;
    public string RgbCommandTemplate { get; internal set; } = null!;
    public string RgbCommandTopic { get; internal set; } = null!;
    public string RgbStateTopic { get; internal set; } = null!;
    public string RgbValueTemplate { get; internal set; } = null!;
    public string WhiteValueCommandTopic { get; internal set; } = null!;
    public int? WhiteValueScale { get; internal set; }
    public string WhiteValueStateTopic { get; internal set; } = null!;
    public string WhiteValueTemplate { get; internal set; } = null!;
    public string XyCommandTopic { get; internal set; } = null!;
    public string XyStateTopic { get; internal set; } = null!;
    public string XyValueTemplate { get; internal set; } = null!;
}
