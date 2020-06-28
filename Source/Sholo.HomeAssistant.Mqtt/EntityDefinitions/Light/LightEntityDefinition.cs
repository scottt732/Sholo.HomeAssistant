namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.Light
{
    public class LightEntityDefinition : BaseCoreSwitchEntityDefinition, ILightEntityDefinition
    {
        public string BrightnessCommandTopic { get; internal set; }
        public int? BrightnessScale { get; internal set; }
        public string BrightnessStateTopic { get; internal set; }
        public string BrightnessValueTemplate { get; internal set; }
        public string ColorTempCommandTemplate { get; internal set; }
        public string ColorTempCommandTopic { get; internal set; }
        public string ColorTempStateTopic { get; internal set; }
        public string ColorTempValueTemplate { get; internal set; }
        public string EffectCommandTopic { get; internal set; }
        public string[] EffectList { get; internal set; }
        public string EffectStateTopic { get; internal set; }
        public string EffectValueTemplate { get; internal set; }
        public string HsCommandTopic { get; internal set; }
        public string HsStateTopic { get; internal set; }
        public string HsValueTemplate { get; internal set; }
        public string OnCommandType { get; internal set; }
        public string PayloadOff { get; internal set; }
        public string PayloadOn { get; internal set; }
        public string RgbCommandTemplate { get; internal set; }
        public string RgbCommandTopic { get; internal set; }
        public string RgbStateTopic { get; internal set; }
        public string RgbValueTemplate { get; internal set; }
        public string WhiteValueCommandTopic { get; internal set; }
        public int? WhiteValueScale { get; internal set; }
        public string WhiteValueStateTopic { get; internal set; }
        public string WhiteValueTemplate { get; internal set; }
        public string XyCommandTopic { get; internal set; }
        public string XyStateTopic { get; internal set; }
        public string XyValueTemplate { get; internal set; }
    }
}