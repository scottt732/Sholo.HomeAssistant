using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Light;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Light
{
    public class LightEntityDefinitionBuilder
        : BaseCoreSwitchEntityDefinitionBuilder<LightEntityDefinitionBuilder, ILightEntityDefinition, LightEntityDefinition>,
            ILightEntityDefinitionBuilder<LightEntityDefinitionBuilder>
    {
        public LightEntityDefinitionBuilder WithBrightnessCommandTopic(string brightnessCommandTopic)
        {
            Target.BrightnessCommandTopic = brightnessCommandTopic;
            return this;
        }

        public LightEntityDefinitionBuilder WithBrightnessScale(int brightnessScale)
        {
            Target.BrightnessScale = brightnessScale;
            return this;
        }

        public LightEntityDefinitionBuilder WithBrightnessStateTopic(string brightnessStateTopic, string brightnessValueTemplate)
        {
            Target.BrightnessStateTopic = brightnessStateTopic;
            Target.BrightnessValueTemplate = brightnessValueTemplate;
            return this;
        }

        public LightEntityDefinitionBuilder WithColorTempCommandTopic(string colorTempCommandTopic, string colorTempCommandTemplate)
        {
            Target.ColorTempCommandTopic = colorTempCommandTopic;
            Target.ColorTempCommandTemplate = colorTempCommandTemplate;
            return this;
        }

        public LightEntityDefinitionBuilder WithColorTempStateTopic(string colorTempStateTopic, string colorTempValueTemplate)
        {
            Target.ColorTempStateTopic = colorTempStateTopic;
            Target.ColorTempValueTemplate = colorTempValueTemplate;
            return this;
        }

        public LightEntityDefinitionBuilder WithEffectCommandTopic(string effectCommandTopic)
        {
            Target.EffectCommandTopic = effectCommandTopic;
            return this;
        }

        public LightEntityDefinitionBuilder WithEffectList(params string[] effects)
        {
            Target.EffectList = effects;
            return this;
        }

        public LightEntityDefinitionBuilder WithEffectStateTopic(string effectStateTopic, string effectValueTemplate)
        {
            Target.EffectStateTopic = effectStateTopic;
            Target.EffectValueTemplate = effectValueTemplate;
            return this;
        }

        public LightEntityDefinitionBuilder WithHsCommandTopic(string hsCommandTopic)
        {
            Target.HsCommandTopic = hsCommandTopic;
            return this;
        }

        public LightEntityDefinitionBuilder WithHsStateTopic(string hsStateTopic, string hsValueTemplate)
        {
            Target.HsStateTopic = hsStateTopic;
            Target.HsValueTemplate = hsValueTemplate;
            return this;
        }

        public LightEntityDefinitionBuilder WithOnCommandType(string onCommandType)
        {
            Target.OnCommandType = onCommandType;
            return this;
        }

        public LightEntityDefinitionBuilder WithOnOffPayloads(string onPayload, string offPayload)
        {
            Target.PayloadOn = onPayload;
            Target.PayloadOff = offPayload;
            return this;
        }

        public LightEntityDefinitionBuilder WithRgbCommandTemplate(string rgbCommandTopic, string rgbValueTemplate)
        {
            Target.RgbCommandTopic = rgbCommandTopic;
            Target.RgbValueTemplate = rgbValueTemplate;
            return this;
        }

        public LightEntityDefinitionBuilder WithRgbStateTopic(string rgbStateTopic, string rgbValueTemplate)
        {
            Target.RgbStateTopic = rgbStateTopic;
            Target.RgbValueTemplate = rgbValueTemplate;
            return this;
        }

        public LightEntityDefinitionBuilder WithWhiteValueCommandTopic(string whiteValueCommandTopic)
        {
            Target.WhiteValueCommandTopic = whiteValueCommandTopic;
            return this;
        }

        public LightEntityDefinitionBuilder WithWhiteValueScale(int whiteValueScale)
        {
            Target.WhiteValueScale = whiteValueScale;
            return this;
        }

        public LightEntityDefinitionBuilder WithWhiteValueStateTopic(string whiteValueStateTopic, string whiteValueTemplate)
        {
            Target.WhiteValueStateTopic = whiteValueStateTopic;
            Target.WhiteValueTemplate = whiteValueTemplate;
            return this;
        }

        public LightEntityDefinitionBuilder WithXyCommandTopic(string xyCommandTopic)
        {
            Target.XyCommandTopic = xyCommandTopic;
            return this;
        }

        public LightEntityDefinitionBuilder WithXyStateTopic(string xyStateTopic, string xyValueTemplate)
        {
            Target.XyStateTopic = xyStateTopic;
            Target.XyValueTemplate = xyValueTemplate;
            return this;
        }
    }
}