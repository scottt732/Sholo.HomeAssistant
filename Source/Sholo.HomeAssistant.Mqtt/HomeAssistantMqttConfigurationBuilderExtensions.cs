using System;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sholo.HomeAssistant.Mqtt.Dispatchers;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.Entities.AlarmControlPanel;
using Sholo.HomeAssistant.Mqtt.Entities.BinarySensor;
using Sholo.HomeAssistant.Mqtt.Entities.Camera;
using Sholo.HomeAssistant.Mqtt.Entities.Cover;
using Sholo.HomeAssistant.Mqtt.Entities.DeviceTrigger;
using Sholo.HomeAssistant.Mqtt.Entities.Fan;
using Sholo.HomeAssistant.Mqtt.Entities.Light;
using Sholo.HomeAssistant.Mqtt.Entities.Lock;
using Sholo.HomeAssistant.Mqtt.Entities.Sensor;
using Sholo.HomeAssistant.Mqtt.Entities.Switch;
using Sholo.HomeAssistant.Mqtt.Entities.Vacuum;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.AlarmControlPanel;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.BinarySensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Camera;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Cover;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.DeviceTrigger;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Fan;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Light;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Lock;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Sensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Switch;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Vacuum;
using Sholo.HomeAssistant.Mqtt.MqttEntityBindingManagers;
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
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.AlarmControlPanel;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.BinarySensor;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Camera;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Cover;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.DeviceTrigger;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Fan;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Light;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Lock;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Sensor;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Switch;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Vacuum;

namespace Sholo.HomeAssistant.Mqtt
{
    [PublicAPI]
    public static class HomeAssistantMqttConfigurationBuilderExtensions
    {
        public static IHomeAssistantMqttConfigurationBuilder AddAlarmControlPanel(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<IAlarmControlPanelMqttEntityConfigurationBuilder, IAlarmControlPanelMqttEntityConfigurationBuilder> configurator)
        {
            configurationBuilder.TryRegisterStatefulEntityBindingManager<IAlarmControlPanelMqttEntityConfiguration, IAlarmControlPanel, IAlarmControlPanelEntityDefinition>();

            IAlarmControlPanelMqttEntityConfigurationBuilder builder = new AlarmControlPanelMqttEntityConfigurationBuilder();
            builder = configurator(builder);

            configurationBuilder.ServiceCollection.AddSingleton(sp =>
            {
                IAlarmControlPanelMqttEntityConfiguration entityConfiguration = builder.Build();
                return entityConfiguration;
            });

            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddAlarmControlPanel(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            IAlarmControlPanelMqttEntityConfiguration mqttEntityConfiguration)
        {
            configurationBuilder.TryRegisterStatefulEntityBindingManager<IAlarmControlPanelMqttEntityConfiguration, IAlarmControlPanel, IAlarmControlPanelEntityDefinition>();

            configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddBinarySensor(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<IBinarySensorMqttEntityConfigurationBuilder, IBinarySensorMqttEntityConfigurationBuilder> configurator)
        {
            configurationBuilder.TryRegisterStatefulEntityBindingManager<IBinarySensorMqttEntityConfiguration, IBinarySensor, IBinarySensorEntityDefinition>();

            IBinarySensorMqttEntityConfigurationBuilder builder = new BinarySensorMqttEntityConfigurationBuilder();
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
            IBinarySensorMqttEntityConfiguration mqttEntityConfiguration)
        {
            configurationBuilder.TryRegisterStatefulEntityBindingManager<IBinarySensorMqttEntityConfiguration, IBinarySensor, IBinarySensorEntityDefinition>();

            configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddCamera(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<ICameraMqttEntityConfigurationBuilder, ICameraMqttEntityConfigurationBuilder> configurator)
        {
            configurationBuilder.TryRegisterEntityBindingManager<ICameraMqttEntityConfiguration, ICamera, ICameraEntityDefinition>();

            ICameraMqttEntityConfigurationBuilder builder = new CameraMqttEntityConfigurationBuilder();
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
            ICameraMqttEntityConfiguration mqttEntityConfiguration)
        {
            configurationBuilder.TryRegisterEntityBindingManager<ICameraMqttEntityConfiguration, ICamera, ICameraEntityDefinition>();

            configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
            return configurationBuilder;
        }

        // TODO: Climate?

        public static IHomeAssistantMqttConfigurationBuilder AddCover(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<ICoverMqttEntityConfigurationBuilder, ICoverMqttEntityConfigurationBuilder> configurator)
        {
            configurationBuilder.TryRegisterStatefulEntityBindingManager<ICoverMqttEntityConfiguration, ICover, ICoverEntityDefinition>();

            ICoverMqttEntityConfigurationBuilder builder = new CoverMqttEntityConfigurationBuilder();
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
            ICoverMqttEntityConfiguration mqttEntityConfiguration)
        {
            configurationBuilder.TryRegisterStatefulEntityBindingManager<ICoverMqttEntityConfiguration, ICover, ICoverEntityDefinition>();

            configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddDeviceTrigger(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<IDeviceTriggerMqttEntityConfigurationBuilder, IDeviceTriggerMqttEntityConfigurationBuilder> configurator)
        {
            configurationBuilder.TryRegisterEntityBindingManager<IDeviceTriggerMqttEntityConfiguration, IDeviceTrigger, IDeviceTriggerEntityDefinition>();

            IDeviceTriggerMqttEntityConfigurationBuilder builder = new DeviceTriggerMqttEntityConfigurationBuilder();
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
            IDeviceTriggerMqttEntityConfiguration mqttEntityConfigurationBuilder)
        {
            configurationBuilder.TryRegisterEntityBindingManager<IDeviceTriggerMqttEntityConfiguration, IDeviceTrigger, IDeviceTriggerEntityDefinition>();

            configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfigurationBuilder);
            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddFan(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<IFanMqttEntityConfigurationBuilder, IFanMqttEntityConfigurationBuilder> configurator)
        {
            configurationBuilder.TryRegisterEntityBindingManager<IFanMqttEntityConfiguration, IFan, IFanEntityDefinition>();

            IFanMqttEntityConfigurationBuilder builder = new FanMqttEntityConfigurationBuilder();
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
            IFanMqttEntityConfiguration mqttEntityConfigurationBuilder)
        {
            configurationBuilder.TryRegisterEntityBindingManager<IFanMqttEntityConfiguration, IFan, IFanEntityDefinition>();

            configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfigurationBuilder);
            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddLight(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<ILightMqttEntityConfigurationBuilder, ILightMqttEntityConfigurationBuilder> configurator)
        {
            configurationBuilder.TryRegisterEntityBindingManager<ILightMqttEntityConfiguration, ILight, ILightEntityDefinition>();

            ILightMqttEntityConfigurationBuilder builder = new LightMqttEntityConfigurationBuilder();
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
            ILightMqttEntityConfiguration mqttEntityConfiguration)
        {
            configurationBuilder.TryRegisterEntityBindingManager<ILightMqttEntityConfiguration, ILight, ILightEntityDefinition>();

            configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddLock(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<ILockMqttEntityConfigurationBuilder, ILockMqttEntityConfigurationBuilder> configurator)
        {
            configurationBuilder.TryRegisterEntityBindingManager<ILockMqttEntityConfiguration, ILock, ILockEntityDefinition>();

            ILockMqttEntityConfigurationBuilder builder = new LockMqttEntityConfigurationBuilder();
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
            ILockMqttEntityConfiguration mqttEntityConfiguration)
        {
            configurationBuilder.TryRegisterEntityBindingManager<ILockMqttEntityConfiguration, ILock, ILockEntityDefinition>();

            configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddSensor(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<ISensorMqttEntityConfigurationBuilder, ISensorMqttEntityConfigurationBuilder> configurator)
        {
            configurationBuilder.TryRegisterEntityBindingManager<ISensorMqttEntityConfiguration, ISensor, ISensorEntityDefinition>();

            ISensorMqttEntityConfigurationBuilder builder = new SensorMqttEntityConfigurationBuilder();
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
            ISensorMqttEntityConfiguration mqttEntityConfigurationBuilder)
        {
            configurationBuilder.TryRegisterEntityBindingManager<ISensorMqttEntityConfiguration, ISensor, ISensorEntityDefinition>();

            configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfigurationBuilder);
            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddSwitch(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<ISwitchMqttEntityConfigurationBuilder, ISwitchMqttEntityConfigurationBuilder> configurator)
        {
            configurationBuilder.TryRegisterEntityBindingManager<ISwitchMqttEntityConfiguration, ISwitch, ISwitchEntityDefinition>();

            ISwitchMqttEntityConfigurationBuilder builder = new SwitchMqttEntityConfigurationBuilder();
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
            ISwitchMqttEntityConfigurationBuilder mqttEntityConfiguration)
        {
            configurationBuilder.TryRegisterEntityBindingManager<ISwitchMqttEntityConfiguration, ISwitch, ISwitchEntityDefinition>();

            configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
            return configurationBuilder;
        }

        public static IHomeAssistantMqttConfigurationBuilder AddVacuum(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder,
            Func<IVacuumMqttEntityConfigurationBuilder, IVacuumMqttEntityConfigurationBuilder> configurator)
        {
            configurationBuilder.TryRegisterEntityBindingManager<IVacuumMqttEntityConfiguration, IVacuum, IVacuumEntityDefinition>();

            IVacuumMqttEntityConfigurationBuilder builder = new VacuumMqttEntityConfigurationBuilder();
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
            IVacuumMqttEntityConfiguration mqttEntityConfiguration)
        {
            configurationBuilder.TryRegisterEntityBindingManager<IVacuumMqttEntityConfiguration, IVacuum, IVacuumEntityDefinition>();

            configurationBuilder.ServiceCollection.AddSingleton(mqttEntityConfiguration);
            return configurationBuilder;
        }

        private static void TryRegisterEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder
        )
            where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
            where TEntity : IEntity
            where TEntityDefinition : IEntityDefinition
        {
            configurationBuilder.ServiceCollection
                .TryAddSingleton<
                    IMqttEntityBindingManager,
                    MqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>>();
        }

        private static void TryRegisterStatefulEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>(
            this IHomeAssistantMqttConfigurationBuilder configurationBuilder
        )
            where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
            where TEntity : IStatefulEntity
            where TEntityDefinition : IStatefulEntityDefinition
        {
            configurationBuilder.ServiceCollection
                .TryAddSingleton<
                    IMqttEntityBindingManager,
                    MqttStatefulEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>>();
        }
    }
}
