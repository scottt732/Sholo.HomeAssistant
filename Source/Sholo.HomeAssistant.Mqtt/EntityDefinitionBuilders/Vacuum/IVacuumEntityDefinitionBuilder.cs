using JetBrains.Annotations;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Vacuum;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Vacuum
{
    [PublicAPI]
    public interface IVacuumEntityDefinitionBuilder<out TSelf> : IStatefulEntityDefinitionBuilder<TSelf, IVacuumEntityDefinition>
        where TSelf : IVacuumEntityDefinitionBuilder<TSelf>
    {
        TSelf WithCommandTopic(string commandTopic);
        TSelf WithFanSpeeds(params string[] speeds);
        TSelf WithCleanSpotPayload(string cleanSpotPayload = "clean_spot");
        TSelf WithLocatePayload(string locatePayload = "locate");
        TSelf WithPausePayload(string pausePayload = "pause");
        TSelf WithReturnToBasePayload(string returnToBasePayload = "return_to_base");
        TSelf WithStartStopPayload(string startPayload = "start", string stopPayload = "stop");
        TSelf WithSendCommandTopic(string sendCommandTopic);
        TSelf WithSetFanSpeedTopic(string setFanSpeedTopic);
        TSelf WithSupportedFeatures(params VacuumFeature[] features);
    }
}
