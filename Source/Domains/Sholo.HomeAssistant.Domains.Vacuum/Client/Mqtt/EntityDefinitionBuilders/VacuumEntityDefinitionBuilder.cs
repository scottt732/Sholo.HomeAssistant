using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

public class VacuumEntityDefinitionBuilder
    : BaseStatefulEntityDefinitionBuilder<VacuumEntityDefinitionBuilder, IVacuumEntityDefinition, VacuumEntityDefinition>,
        IVacuumEntityDefinitionBuilder<VacuumEntityDefinitionBuilder>
{
    public VacuumEntityDefinitionBuilder WithCommandTopic(string commandTopic)
    {
        Target.CommandTopic = commandTopic;
        return this;
    }

    public VacuumEntityDefinitionBuilder WithFanSpeeds(params string[] speeds)
    {
        Target.FanSpeedList = speeds;
        return this;
    }

    public VacuumEntityDefinitionBuilder WithCleanSpotPayload(string cleanSpotPayload = "clean_spot")
    {
        Target.PayloadCleanSpot = cleanSpotPayload;
        return this;
    }

    public VacuumEntityDefinitionBuilder WithLocatePayload(string locatePayload = "locate")
    {
        Target.PayloadLocate = locatePayload;
        return this;
    }

    public VacuumEntityDefinitionBuilder WithPausePayload(string pausePayload = "pause")
    {
        Target.PayloadPause = pausePayload;
        return this;
    }

    public VacuumEntityDefinitionBuilder WithReturnToBasePayload(string returnToBasePayload = "return_to_base")
    {
        Target.PayloadReturnToBase = returnToBasePayload;
        return this;
    }

    public VacuumEntityDefinitionBuilder WithStartStopPayload(string startPayload = "start", string stopPayload = "stop")
    {
        Target.PayloadStart = startPayload;
        Target.PayloadStop = stopPayload;
        return this;
    }

    public VacuumEntityDefinitionBuilder WithSendCommandTopic(string sendCommandTopic)
    {
        Target.SendCommandTopic = sendCommandTopic;
        return this;
    }

    public VacuumEntityDefinitionBuilder WithSetFanSpeedTopic(string setFanSpeedTopic)
    {
        Target.SetFanSpeedTopic = setFanSpeedTopic;
        return this;
    }

    public VacuumEntityDefinitionBuilder WithSupportedFeatures(params VacuumFeature[] features)
    {
        Target.SupportedFeatures = features;
        return this;
    }
}
