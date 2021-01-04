using Sholo.HomeAssistant.Mqtt.Entities.AlarmControlPanel;
using Sholo.HomeAssistant.Mqtt.Entities.BinarySensor;
using Sholo.HomeAssistant.Mqtt.Entities.Climate;
using Sholo.HomeAssistant.Mqtt.Entities.Cover;
using Sholo.HomeAssistant.Mqtt.Entities.Fan;
using Sholo.HomeAssistant.Mqtt.Entities.Light;
using Sholo.HomeAssistant.Mqtt.Entities.Lock;
using Sholo.HomeAssistant.Mqtt.Entities.Sensor;
using Sholo.HomeAssistant.Mqtt.Entities.Switch;
using Sholo.HomeAssistant.Mqtt.Entities.Vacuum;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.AlarmControlPanel;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.BinarySensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Climate;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Cover;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Fan;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Light;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Lock;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Sensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Switch;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Vacuum;
using Sholo.HomeAssistant.Mqtt.MqttEntityBindingManagers;
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

namespace Sholo.HomeAssistant.Mqtt.ControlPanel
{
    public static class MqttEntityControlPanelExtensions
    {
        public static IMqttEntityBindingManager<IAlarmControlPanelMqttEntityConfiguration, IAlarmControlPanel, IAlarmControlPanelEntityDefinition> AlarmControlPanels(this IMqttEntityControlPanel controlPanel) => controlPanel.StatefulEntitiesOfType<IAlarmControlPanelMqttEntityConfiguration, IAlarmControlPanel, IAlarmControlPanelEntityDefinition>();
        public static IMqttEntityBindingManager<IBinarySensorMqttEntityConfiguration, IBinarySensor, IBinarySensorEntityDefinition> BinarySensors(this IMqttEntityControlPanel controlPanel) => controlPanel.StatefulEntitiesOfType<IBinarySensorMqttEntityConfiguration, IBinarySensor, IBinarySensorEntityDefinition>();

        // TODO: Camera?

        public static IMqttEntityBindingManager<IClimateMqttEntityConfiguration, IClimate, IClimateEntityDefinition> Climate(this IMqttEntityControlPanel controlPanel) => controlPanel.EntitiesOfType<IClimateMqttEntityConfiguration, IClimate, IClimateEntityDefinition>(); // TODO: Not stateful?!
        public static IMqttEntityBindingManager<ICoverMqttEntityConfiguration, ICover, ICoverEntityDefinition> Covers(this IMqttEntityControlPanel controlPanel) => controlPanel.StatefulEntitiesOfType<ICoverMqttEntityConfiguration, ICover, ICoverEntityDefinition>();

        // TODO: Device Trigger?
        public static IMqttEntityBindingManager<IFanMqttEntityConfiguration, IFan, IFanEntityDefinition> Fans(this IMqttEntityControlPanel controlPanel) => controlPanel.StatefulEntitiesOfType<IFanMqttEntityConfiguration, IFan, IFanEntityDefinition>();
        public static IMqttEntityBindingManager<ILightMqttEntityConfiguration, ILight, ILightEntityDefinition> Lights(this IMqttEntityControlPanel controlPanel) => controlPanel.StatefulEntitiesOfType<ILightMqttEntityConfiguration, ILight, ILightEntityDefinition>();
        public static IMqttEntityBindingManager<ILockMqttEntityConfiguration, ILock, ILockEntityDefinition> Locks(this IMqttEntityControlPanel controlPanel) => controlPanel.StatefulEntitiesOfType<ILockMqttEntityConfiguration, ILock, ILockEntityDefinition>();
        public static IMqttEntityBindingManager<ISensorMqttEntityConfiguration, ISensor, ISensorEntityDefinition> Sensors(this IMqttEntityControlPanel controlPanel) => controlPanel.StatefulEntitiesOfType<ISensorMqttEntityConfiguration, ISensor, ISensorEntityDefinition>();
        public static IMqttEntityBindingManager<ISwitchMqttEntityConfiguration, ISwitch, ISwitchEntityDefinition> Switches(this IMqttEntityControlPanel controlPanel) => controlPanel.StatefulEntitiesOfType<ISwitchMqttEntityConfiguration, ISwitch, ISwitchEntityDefinition>();
        public static IMqttEntityBindingManager<IVacuumMqttEntityConfiguration, IVacuum, IVacuumEntityDefinition> Vacuums(this IMqttEntityControlPanel controlPanel) => controlPanel.StatefulEntitiesOfType<IVacuumMqttEntityConfiguration, IVacuum, IVacuumEntityDefinition>();

        public static IMqttEntityControlPanel AddAlarmControlPanel(this IMqttEntityControlPanel controlPanel, IAlarmControlPanelMqttEntityConfiguration configuration)
        {
            controlPanel.AddStatefulEntity<IAlarmControlPanelMqttEntityConfiguration, IAlarmControlPanel, IAlarmControlPanelEntityDefinition>(configuration);
            return controlPanel;
        }

        public static IMqttEntityControlPanel AddBinarySensor(this IMqttEntityControlPanel controlPanel, IBinarySensorMqttEntityConfiguration configuration)
        {
            controlPanel.AddStatefulEntity<IBinarySensorMqttEntityConfiguration, IBinarySensor, IBinarySensorEntityDefinition>(configuration);
            return controlPanel;
        }

        // TODO: Camera?

        public static IMqttEntityControlPanel AddClimate(this IMqttEntityControlPanel controlPanel, IClimateMqttEntityConfiguration configuration)
        {
            controlPanel.AddEntity<IClimateMqttEntityConfiguration, IClimate, IClimateEntityDefinition>(configuration); // TODO: Not stateful?!
            return controlPanel;
        }

        public static IMqttEntityControlPanel AddCover(this IMqttEntityControlPanel controlPanel, ICoverMqttEntityConfiguration configuration)
        {
            controlPanel.AddStatefulEntity<ICoverMqttEntityConfiguration, ICover, ICoverEntityDefinition>(configuration);
            return controlPanel;
        }

        public static IMqttEntityControlPanel AddFan(this IMqttEntityControlPanel controlPanel, IFanMqttEntityConfiguration configuration)
        {
            controlPanel.AddStatefulEntity<IFanMqttEntityConfiguration, IFan, IFanEntityDefinition>(configuration);
            return controlPanel;
        }

        public static IMqttEntityControlPanel AddLight(this IMqttEntityControlPanel controlPanel, ILightMqttEntityConfiguration configuration)
        {
            controlPanel.AddStatefulEntity<ILightMqttEntityConfiguration, ILight, ILightEntityDefinition>(configuration);
            return controlPanel;
        }

        public static IMqttEntityControlPanel AddLock(this IMqttEntityControlPanel controlPanel, ILockMqttEntityConfiguration configuration)
        {
            controlPanel.AddStatefulEntity<ILockMqttEntityConfiguration, ILock, ILockEntityDefinition>(configuration);
            return controlPanel;
        }

        public static IMqttEntityControlPanel AddSensor(this IMqttEntityControlPanel controlPanel, ISensorMqttEntityConfiguration configuration)
        {
            controlPanel.AddStatefulEntity<ISensorMqttEntityConfiguration, ISensor, ISensorEntityDefinition>(configuration);
            return controlPanel;
        }

        public static IMqttEntityControlPanel AddSwitch(this IMqttEntityControlPanel controlPanel, ISwitchMqttEntityConfiguration configuration)
        {
            controlPanel.AddStatefulEntity<ISwitchMqttEntityConfiguration, ISwitch, ISwitchEntityDefinition>(configuration);
            return controlPanel;
        }

        public static IMqttEntityControlPanel AddVacuum(this IMqttEntityControlPanel controlPanel, IVacuumMqttEntityConfiguration configuration)
        {
            controlPanel.AddStatefulEntity<IVacuumMqttEntityConfiguration, IVacuum, IVacuumEntityDefinition>(configuration);
            return controlPanel;
        }
    }
}
