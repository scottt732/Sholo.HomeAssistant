using System;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.AlarmControlPanel;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.BinarySensor;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Camera;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Cover;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.DeviceTrigger;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Fan;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Light;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Lock;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Sensor;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Switch;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Vacuum;

namespace Sholo.HomeAssistant.Mqtt
{
    [PublicAPI]
    public static class HomeAssistantMqttConfigurationBuilderExtensions
    {
        public static IHomeAssistantMqttConfigurationBuilder AddAlarmControlPanel(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<IAlarmControlPanelMqttEntityConfigurationBuilder, IAlarmControlPanelMqttEntityConfigurationBuilder> configurator)
        {
            IAlarmControlPanelMqttEntityConfigurationBuilder builder = new AlarmControlPanelMqttEntityConfigurationBuilder();
            builder = configurator(builder);

            configurationBuilder.ServiceCollection.AddSingleton(sp =>
            {
                var entityConfiguration = builder.Build();
                return entityConfiguration;
            });

            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddBinarySensor(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<IBinarySensorMqttEntityConfigurationBuilder, IBinarySensorMqttEntityConfigurationBuilder> configurator)
        {
            IBinarySensorMqttEntityConfigurationBuilder builder = new BinarySensorMqttEntityConfigurationBuilder();
            builder = configurator(builder);

            configurationBuilder.ServiceCollection.AddSingleton(sp =>
            {
                var entityConfiguration = builder.Build();
                return entityConfiguration;
            });

            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddCamera(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<ICameraMqttEntityConfigurationBuilder, ICameraMqttEntityConfigurationBuilder> configurator)
        {
            ICameraMqttEntityConfigurationBuilder builder = new CameraMqttEntityConfigurationBuilder();
            builder = configurator(builder);

            configurationBuilder.ServiceCollection.AddSingleton(sp =>
            {
                var entityConfiguration = builder.Build();
                return entityConfiguration;
            });

            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddCover(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<ICoverMqttEntityConfigurationBuilder, ICoverMqttEntityConfigurationBuilder> configurator)
        {
            ICoverMqttEntityConfigurationBuilder builder = new CoverMqttEntityConfigurationBuilder();
            builder = configurator(builder);

            configurationBuilder.ServiceCollection.AddSingleton(sp =>
            {
                var entityConfiguration = builder.Build();
                return entityConfiguration;
            });

            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddDeviceTrigger(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<IDeviceTriggerMqttEntityConfigurationBuilder, IDeviceTriggerMqttEntityConfigurationBuilder> configurator)
        {
            IDeviceTriggerMqttEntityConfigurationBuilder builder = new DeviceTriggerMqttEntityConfigurationBuilder();
            builder = configurator(builder);

            configurationBuilder.ServiceCollection.AddSingleton(sp =>
            {
                var entityConfiguration = builder.Build();
                return entityConfiguration;
            });

            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddFan(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<IFanMqttEntityConfigurationBuilder, IFanMqttEntityConfigurationBuilder> configurator)
        {
            IFanMqttEntityConfigurationBuilder builder = new FanMqttEntityConfigurationBuilder();
            builder = configurator(builder);

            configurationBuilder.ServiceCollection.AddSingleton(sp =>
            {
                var entityConfiguration = builder.Build();
                return entityConfiguration;
            });

            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddLight(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<ILightMqttEntityConfigurationBuilder, ILightMqttEntityConfigurationBuilder> configurator)
        {
            ILightMqttEntityConfigurationBuilder builder = new LightMqttEntityConfigurationBuilder();
            builder = configurator(builder);

            configurationBuilder.ServiceCollection.AddSingleton(sp =>
            {
                var entityConfiguration = builder.Build();
                return entityConfiguration;
            });

            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddLock(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<ILockMqttEntityConfigurationBuilder, ILockMqttEntityConfigurationBuilder> configurator)
        {
            ILockMqttEntityConfigurationBuilder builder = new LockMqttEntityConfigurationBuilder();
            builder = configurator(builder);

            configurationBuilder.ServiceCollection.AddSingleton(sp =>
            {
                var entityConfiguration = builder.Build();
                return entityConfiguration;
            });

            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddSensor(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<ISensorMqttEntityConfigurationBuilder, ISensorMqttEntityConfigurationBuilder> configurator)
        {
            ISensorMqttEntityConfigurationBuilder builder = new SensorMqttEntityConfigurationBuilder();
            builder = configurator(builder);

            configurationBuilder.ServiceCollection.AddSingleton(sp =>
            {
                var entityConfiguration = builder.Build();
                return entityConfiguration;
            });

            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddSwitch(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<ISwitchMqttEntityConfigurationBuilder, ISwitchMqttEntityConfigurationBuilder> configurator)
        {
            ISwitchMqttEntityConfigurationBuilder builder = new SwitchMqttEntityConfigurationBuilder();
            builder = configurator(builder);

            configurationBuilder.ServiceCollection.AddSingleton(sp =>
            {
                var entityConfiguration = builder.Build();
                return entityConfiguration;
            });

            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddVacuum(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<IVacuumMqttEntityConfigurationBuilder, IVacuumMqttEntityConfigurationBuilder> configurator)
        {
            IVacuumMqttEntityConfigurationBuilder builder = new VacuumMqttEntityConfigurationBuilder();
            builder = configurator(builder);

            configurationBuilder.ServiceCollection.AddSingleton(sp =>
            {
                var entityConfiguration = builder.Build();
                return entityConfiguration;
            });

            return configurationBuilder;
        }
    }
}
