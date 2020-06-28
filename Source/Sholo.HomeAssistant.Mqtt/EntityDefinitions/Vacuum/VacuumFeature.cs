using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.Vacuum
{
    [PublicAPI]
    public enum VacuumFeature
    {
        Start,
        Stop,
        Pause,
        ReturnHome,
        Battery,
        Status,
        Locate,
        CleanSpot,
        FanSpeed,
        SendCommand
    }
}
