using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.DeviceClasses;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

[PublicAPI]
public interface ICoverEntityDefinitionBuilder<out TSelf> : ICoreSwitchEntityDefinitionBuilder<TSelf, ICoverEntityDefinition>
    where TSelf : ICoverEntityDefinitionBuilder<TSelf>
{
    TSelf WithDeviceClass(CoverDeviceClass deviceClass);
    TSelf WithStatePayloads(string openPayload = "OPEN", string closePayload = "CLOSE", string stopPayload = "STOP");
    TSelf WithOpenClosePositions(int openPosition = 0, int closePosition = 100);
    TSelf WithGetPositionTopic(string positionTopic);
    TSelf WithSetPositionTopic(string setPositionTopic, string setPositionTemplate);
    TSelf WithGetTiltStatusTopic(string tiltStatusTopic, string tiltStatusTemplate);
}
