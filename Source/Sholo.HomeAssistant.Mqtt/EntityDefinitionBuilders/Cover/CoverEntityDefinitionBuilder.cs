using Sholo.HomeAssistant.DeviceClasses;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Cover;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Cover
{
    public class CoverEntityDefinitionBuilder
        : BaseCoreSwitchEntityDefinitionBuilder<CoverEntityDefinitionBuilder, ICoverEntityDefinition, CoverEntityDefinition>,
            ICoverEntityDefinitionBuilder<CoverEntityDefinitionBuilder>
    {
        public CoverEntityDefinitionBuilder WithDeviceClass(CoverDeviceClass deviceClass)
        {
            Target.DeviceClass = deviceClass;
            return this;
        }

        public CoverEntityDefinitionBuilder WithStatePayloads(string openPayload = "OPEN", string closePayload = "CLOSE", string stopPayload = "STOP")
        {
            Target.PayloadOpen = openPayload;
            Target.PayloadClose = closePayload;
            Target.PayloadStop = stopPayload;
            return this;
        }

        public CoverEntityDefinitionBuilder WithOpenClosePositions(int openPosition = 0, int closePosition = 100)
        {
            Target.PositionOpen = openPosition;
            Target.PositionClosed = closePosition;
            return this;
        }

        public CoverEntityDefinitionBuilder WithGetPositionTopic(string positionTopic)
        {
            Target.PositionTopic = positionTopic;
            return this;
        }

        public CoverEntityDefinitionBuilder WithSetPositionTopic(string setPositionTopic, string setPositionTemplate)
        {
            Target.SetPositionTopic = setPositionTopic;
            Target.SetPositionTemplate = setPositionTemplate;
            return this;
        }

        public CoverEntityDefinitionBuilder WithGetTiltStatusTopic(string tiltStatusTopic, string tiltStatusTemplate)
        {
            Target.TiltStatusTopic = tiltStatusTopic;
            Target.TiltStatusTemplate = tiltStatusTemplate;
            return this;
        }
    }
}
