using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.AlarmControlPanel;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.BinarySensor;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Climate;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Cover;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Fan;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Light;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Lock;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Sensor;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Switch;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Vacuum;

namespace Sholo.HomeAssistant.Mqtt.Dispatchers
{
    // This interface/concept is likely going to go away in favor of a more modular approach

    [PublicAPI]
    public interface IMqttEntityControlPanel : IDisposable
    {
        IList<IAlarmControlPanelMqttEntityConfiguration> AlarmControlPanels { get; }
        IList<IBinarySensorMqttEntityConfiguration> BinarySensors { get; }
        IList<IClimateMqttEntityConfiguration> Climate { get; }
        IList<ICoverMqttEntityConfiguration> Covers { get; }
        IList<IFanMqttEntityConfiguration> Fans { get; }
        IList<ILightMqttEntityConfiguration> Lights { get; }
        IList<ILockMqttEntityConfiguration> Locks { get; }
        IList<ISensorMqttEntityConfiguration> Sensors { get; }
        IList<ISwitchMqttEntityConfiguration> Switches { get; }
        IList<IVacuumMqttEntityConfiguration> Vacuums { get; }

        void ResendDiscovery();
        void DeleteAll();
    }
}
