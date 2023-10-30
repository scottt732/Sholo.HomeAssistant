namespace Sholo.HomeAssistant.Client.Mqtt;

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
