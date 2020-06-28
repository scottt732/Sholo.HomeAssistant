using JetBrains.Annotations;
using Sholo.HomeAssistant.Client.Domains.AlarmControlPanel;
using Sholo.HomeAssistant.Client.Domains.Automation;
using Sholo.HomeAssistant.Client.Domains.BinarySensor;
using Sholo.HomeAssistant.Client.Domains.Calendar;
using Sholo.HomeAssistant.Client.Domains.Camera;
using Sholo.HomeAssistant.Client.Domains.Climate;
using Sholo.HomeAssistant.Client.Domains.DeviceTracker;
using Sholo.HomeAssistant.Client.Domains.Display;
using Sholo.HomeAssistant.Client.Domains.Fan;
using Sholo.HomeAssistant.Client.Domains.Group;
using Sholo.HomeAssistant.Client.Domains.InputBoolean;
using Sholo.HomeAssistant.Client.Domains.Light;
using Sholo.HomeAssistant.Client.Domains.Lock;
using Sholo.HomeAssistant.Client.Domains.MediaPlayer;
using Sholo.HomeAssistant.Client.Domains.Person;
using Sholo.HomeAssistant.Client.Domains.Script;
using Sholo.HomeAssistant.Client.Domains.Sensor;
using Sholo.HomeAssistant.Client.Domains.Sun;
using Sholo.HomeAssistant.Client.Domains.Switch;
using Sholo.HomeAssistant.Client.Domains.Weather;
using Sholo.HomeAssistant.Client.Domains.Zone;

namespace Sholo.HomeAssistant.Client.Domains
{
    [PublicAPI]
    public static class HomeAssistantServiceCollectionExtensions
    {
        public static IHomeAssistantClientConfigurationBuilder WithDomainEntityStateDeserializers(this IHomeAssistantClientConfigurationBuilder configurationBuilder)
        {
            return configurationBuilder
                .WithStateDeserializer<SunEntityStateDeserializer>()
                .WithStateDeserializer<ScriptEntityStateDeserializer>()
                .WithStateDeserializer<ZoneEntityStateDeserializer>()
                .WithStateDeserializer<GroupEntityStateDeserializer>()
                .WithStateDeserializer<DisplayEntityStateDeserializer>()
                .WithStateDeserializer<InputBooleanEntityStateDeserializer>()
                .WithStateDeserializer<AutomationEntityStateDeserializer>()
                .WithStateDeserializer<AlarmControlPanelEntityStateDeserializer>()
                .WithStateDeserializer<PersonEntityStateDeserializer>()
                .WithStateDeserializer<BinarySensorEntityStateDeserializer>()
                .WithStateDeserializer<SwitchEntityStateDeserializer>()
                .WithStateDeserializer<LightEntityStateDeserializer>()
                .WithStateDeserializer<MediaPlayerEntityStateDeserializer>()
                .WithStateDeserializer<CameraEntityStateDeserializer>()
                .WithStateDeserializer<CalendarEntityStateDeserializer>()
                .WithStateDeserializer<SensorEntityStateDeserializer>()
                .WithStateDeserializer<DeviceTrackerEntityStateDeserializer>()
                .WithStateDeserializer<LockEntityStateDeserializer>()
                .WithStateDeserializer<FanEntityStateDeserializer>()
                .WithStateDeserializer<ClimateEntityStateDeserializer>()
                .WithStateDeserializer<WeatherEntityStateDeserializer>();
        }
    }
}
