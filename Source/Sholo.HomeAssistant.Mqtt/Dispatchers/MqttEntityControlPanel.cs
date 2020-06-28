using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Linq;
using Microsoft.Extensions.Logging;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.Entities.AlarmControlPanel;
using Sholo.HomeAssistant.Mqtt.Entities.BinarySensor;
using Sholo.HomeAssistant.Mqtt.Entities.Cover;
using Sholo.HomeAssistant.Mqtt.Entities.Fan;
using Sholo.HomeAssistant.Mqtt.Entities.Light;
using Sholo.HomeAssistant.Mqtt.Entities.Lock;
using Sholo.HomeAssistant.Mqtt.Entities.Sensor;
using Sholo.HomeAssistant.Mqtt.Entities.Switch;
using Sholo.HomeAssistant.Mqtt.Entities.Vacuum;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.AlarmControlPanel;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.BinarySensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Cover;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Fan;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Light;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Lock;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Sensor;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Switch;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Vacuum;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;
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
    public class MqttEntityControlPanel : IMqttEntityControlPanel
    {
        public IList<IAlarmControlPanelMqttEntityConfiguration> AlarmControlPanels => _alarmControlPanels;
        public IList<IBinarySensorMqttEntityConfiguration> BinarySensors => _binarySensors;
        public IList<IClimateMqttEntityConfiguration> Climate => _climate;
        public IList<ICoverMqttEntityConfiguration> Covers => _covers;
        public IList<IFanMqttEntityConfiguration> Fans => _fans;
        public IList<ILightMqttEntityConfiguration> Lights => _lights;
        public IList<ILockMqttEntityConfiguration> Locks => _locks;
        public IList<ISensorMqttEntityConfiguration> Sensors => _sensors;
        public IList<ISwitchMqttEntityConfiguration> Switches => _switches;
        public IList<IVacuumMqttEntityConfiguration> Vacuums => _vacuums;

        private IOutboundMqttMessageBusPublisher MessageBusPublisher { get; }
        private ILogger<MqttEntityControlPanel> Logger { get; }

        private ConcurrentDictionary<string, IDisposable> SubscriptionsByDiscoveryTopic { get; } = new ConcurrentDictionary<string, IDisposable>();
        private IList<IDisposable> EventSubscriptions { get; } = new List<IDisposable>();

        private readonly ObservableCollection<IAlarmControlPanelMqttEntityConfiguration> _alarmControlPanels = new ObservableCollection<IAlarmControlPanelMqttEntityConfiguration>();
        private readonly ObservableCollection<IBinarySensorMqttEntityConfiguration> _binarySensors = new ObservableCollection<IBinarySensorMqttEntityConfiguration>();
        private readonly ObservableCollection<IClimateMqttEntityConfiguration> _climate = new ObservableCollection<IClimateMqttEntityConfiguration>();
        private readonly ObservableCollection<ICoverMqttEntityConfiguration> _covers = new ObservableCollection<ICoverMqttEntityConfiguration>();
        private readonly ObservableCollection<IFanMqttEntityConfiguration> _fans = new ObservableCollection<IFanMqttEntityConfiguration>();
        private readonly ObservableCollection<ILightMqttEntityConfiguration> _lights = new ObservableCollection<ILightMqttEntityConfiguration>();
        private readonly ObservableCollection<ILockMqttEntityConfiguration> _locks = new ObservableCollection<ILockMqttEntityConfiguration>();
        private readonly ObservableCollection<ISensorMqttEntityConfiguration> _sensors = new ObservableCollection<ISensorMqttEntityConfiguration>();
        private readonly ObservableCollection<ISwitchMqttEntityConfiguration> _switches = new ObservableCollection<ISwitchMqttEntityConfiguration>();
        private readonly ObservableCollection<IVacuumMqttEntityConfiguration> _vacuums = new ObservableCollection<IVacuumMqttEntityConfiguration>();

        public void ResendDiscovery()
        {
            ForEach(AlarmControlPanels, cfg => MessageBusPublisher.PublishMessage(cfg.DiscoveryMessage));
            ForEach(BinarySensors, cfg => MessageBusPublisher.PublishMessage(cfg.DiscoveryMessage));
            ForEach(Climate, cfg => MessageBusPublisher.PublishMessage(cfg.DiscoveryMessage));
            ForEach(Covers, cfg => MessageBusPublisher.PublishMessage(cfg.DiscoveryMessage));
            ForEach(Fans, cfg => MessageBusPublisher.PublishMessage(cfg.DiscoveryMessage));
            ForEach(Lights, cfg => MessageBusPublisher.PublishMessage(cfg.DiscoveryMessage));
            ForEach(Locks, cfg => MessageBusPublisher.PublishMessage(cfg.DiscoveryMessage));
            ForEach(Sensors, cfg => MessageBusPublisher.PublishMessage(cfg.DiscoveryMessage));
            ForEach(Switches, cfg => MessageBusPublisher.PublishMessage(cfg.DiscoveryMessage));
            ForEach(Vacuums, cfg => MessageBusPublisher.PublishMessage(cfg.DiscoveryMessage));
        }

        public void DeleteAll()
        {
            ForEach(AlarmControlPanels, cfg => MessageBusPublisher.PublishMessage(cfg.DeleteMessage));
            ForEach(BinarySensors, cfg => MessageBusPublisher.PublishMessage(cfg.DeleteMessage));
            ForEach(Climate, cfg => MessageBusPublisher.PublishMessage(cfg.DeleteMessage));
            ForEach(Covers, cfg => MessageBusPublisher.PublishMessage(cfg.DeleteMessage));
            ForEach(Fans, cfg => MessageBusPublisher.PublishMessage(cfg.DeleteMessage));
            ForEach(Lights, cfg => MessageBusPublisher.PublishMessage(cfg.DeleteMessage));
            ForEach(Locks, cfg => MessageBusPublisher.PublishMessage(cfg.DeleteMessage));
            ForEach(Sensors, cfg => MessageBusPublisher.PublishMessage(cfg.DeleteMessage));
            ForEach(Switches, cfg => MessageBusPublisher.PublishMessage(cfg.DeleteMessage));
            ForEach(Vacuums, cfg => MessageBusPublisher.PublishMessage(cfg.DeleteMessage));
        }

        private void ForEach<TEntity, TEntityDefinition>(
            IEnumerable<IMqttEntityConfiguration<TEntity, TEntityDefinition>> observableCollection,
            Action<IMqttEntityConfiguration<TEntity, TEntityDefinition>> action
        )
            where TEntity : IEntity
            where TEntityDefinition : IEntityDefinition
        {
            foreach (var entityConfiguration in observableCollection.ToArray())
            {
                action.Invoke(entityConfiguration);
            }
        }

        // TODO: IEnumerable<IClimateMqttEntityConfiguration> climateEntityConfigurations,

        public MqttEntityControlPanel(
            IEnumerable<IAlarmControlPanelMqttEntityConfiguration> alarmControlPanelMqttEntityConfigurations,
            IEnumerable<IBinarySensorMqttEntityConfiguration> binarySensorEntityConfigurations,
            IEnumerable<ICoverMqttEntityConfiguration> coverEntityConfigurations,
            IEnumerable<IFanMqttEntityConfiguration> fanEntityConfigurations,
            IEnumerable<ILightMqttEntityConfiguration> lightEntityConfigurations,
            IEnumerable<ILockMqttEntityConfiguration> lockEntityConfigurations,
            IEnumerable<ISensorMqttEntityConfiguration> sensorEntityConfigurations,
            IEnumerable<ISwitchMqttEntityConfiguration> switchEntityConfigurations,
            IEnumerable<IVacuumMqttEntityConfiguration> vacuumEntityConfigurations,
            IOutboundMqttMessageBusPublisher messageBusPublisher,
            ILogger<MqttEntityControlPanel> logger
        )
        {
            MessageBusPublisher = messageBusPublisher;
            Logger = logger;

            EventSubscriptions.Add(ObserveCollectionChanges<IAlarmControlPanelMqttEntityConfiguration, IAlarmControlPanel, IAlarmControlPanelEntityDefinition>(_alarmControlPanels));
            EventSubscriptions.Add(ObserveCollectionChanges<IBinarySensorMqttEntityConfiguration, IBinarySensor, IBinarySensorEntityDefinition>(_binarySensors));

            // TODO: EventSubscriptions.Add(ObserveCollectionChanges<IClimateMqttEntityConfiguration, IClimate, IClimateEntityDefinition>(_climate));
            EventSubscriptions.Add(ObserveCollectionChanges<ICoverMqttEntityConfiguration, ICover, ICoverEntityDefinition>(_covers));
            EventSubscriptions.Add(ObserveCollectionChanges<IFanMqttEntityConfiguration, IFan, IFanEntityDefinition>(_fans));
            EventSubscriptions.Add(ObserveCollectionChanges<ILightMqttEntityConfiguration, ILight, ILightEntityDefinition>(_lights));
            EventSubscriptions.Add(ObserveCollectionChanges<ILockMqttEntityConfiguration, ILock, ILockEntityDefinition>(_locks));
            EventSubscriptions.Add(ObserveCollectionChanges<ISensorMqttEntityConfiguration, ISensor, ISensorEntityDefinition>(_sensors));
            EventSubscriptions.Add(ObserveCollectionChanges<ISwitchMqttEntityConfiguration, ISwitch, ISwitchEntityDefinition>(_switches));
            EventSubscriptions.Add(ObserveCollectionChanges<IVacuumMqttEntityConfiguration, IVacuum, IVacuumEntityDefinition>(_vacuums));

            foreach (var alarmControlPanelMqttEntityConfiguration in alarmControlPanelMqttEntityConfigurations) { _alarmControlPanels.Add(alarmControlPanelMqttEntityConfiguration); }
            foreach (var binarySensorMqttEntityConfiguration in binarySensorEntityConfigurations) { _binarySensors.Add(binarySensorMqttEntityConfiguration); }

            // TODO: foreach (var climateEntityConfiguration in climateEntityConfigurations) { _climate.Add(climateEntityConfiguration); }
            foreach (var coverEntityConfiguration in coverEntityConfigurations) { _covers.Add(coverEntityConfiguration); }
            foreach (var fanEntityConfiguration in fanEntityConfigurations) { _fans.Add(fanEntityConfiguration); }
            foreach (var lightEntityConfiguration in lightEntityConfigurations) { _lights.Add(lightEntityConfiguration); }
            foreach (var lockEntityConfiguration in lockEntityConfigurations) { _locks.Add(lockEntityConfiguration); }
            foreach (var sensorEntityConfiguration in sensorEntityConfigurations) { _sensors.Add(sensorEntityConfiguration); }
            foreach (var switchEntityConfiguration in switchEntityConfigurations) { _switches.Add(switchEntityConfiguration); }
            foreach (var vacuumEntityConfiguration in vacuumEntityConfigurations) { _vacuums.Add(vacuumEntityConfiguration); }
        }

        public void BindAndSendDiscovery<TEntity, TEntityDefinition>(
            IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition> entityConfiguration
        )
            where TEntity : IStatefulEntity
            where TEntityDefinition : IStatefulEntityDefinition
        {
            foreach (var stateChangeHandler in entityConfiguration.StateChangeHandlers)
            {
                SubscriptionsByDiscoveryTopic.TryAdd(
                    entityConfiguration.DiscoveryTopic,
                    stateChangeHandler.Bind(
                        MessageBusPublisher,
                        entityConfiguration.Entity,
                        entityConfiguration.EntityDefinition,
                        entityConfiguration.StateMessageQualityOfServiceLevel,
                        entityConfiguration.RetainStateMessages
                    )
                );
            }

            MessageBusPublisher.PublishMessage(entityConfiguration.DiscoveryMessage);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var eventSubscription in this.EventSubscriptions)
                {
                    eventSubscription.Dispose();
                }

                foreach (var keyValuePair in this.SubscriptionsByDiscoveryTopic.ToArray())
                {
                    keyValuePair.Value.Dispose();
                }
            }
        }

        private IDisposable ObserveCollectionChanges<TEntityConfiguration, TEntity, TEntityDefinition>(
            ObservableCollection<TEntityConfiguration> observableCollection
        )
            where TEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
            where TEntity : IStatefulEntity
            where TEntityDefinition : IStatefulEntityDefinition
            => Observable.FromEvent<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                    handler => (sender, args) => handler(args),
                    handler => observableCollection.CollectionChanged += handler,
                    handler => observableCollection.CollectionChanged -= handler)
                .Where(args => args.Action != NotifyCollectionChangedAction.Move)
                .Select(args =>
                (
                    Removed: args.OldItems?.Cast<IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>>().ToArray() ?? Array.Empty<IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>>(),
                    Added: args.NewItems?.Cast<IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>>().ToArray() ?? Array.Empty<IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>>()
                ))
                .Subscribe(x =>
                {
                    foreach (var removed in x.Removed)
                    {
                        if (SubscriptionsByDiscoveryTopic.TryRemove(removed.DiscoveryTopic, out var subscription))
                        {
                            // Un-discover
                            subscription.Dispose();
                        }
                    }

                    foreach (var added in x.Added)
                    {
                        BindAndSendDiscovery(added);
                    }
                });
    }
}
