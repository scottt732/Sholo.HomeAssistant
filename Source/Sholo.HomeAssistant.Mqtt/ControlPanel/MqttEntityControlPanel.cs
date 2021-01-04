using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Linq;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.MessageBus;
using Sholo.HomeAssistant.Mqtt.MqttEntityBindingManagers;
using Sholo.HomeAssistant.Mqtt.MqttEntityBindings;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;
using Sholo.Mqtt.ApplicationBuilder;
using Sholo.Mqtt.ApplicationProvider;

namespace Sholo.HomeAssistant.Mqtt.ControlPanel
{
    public class MqttEntityControlPanel : IMqttEntityControlPanel
    {
        private IList<IMqttEntityBindingManager> EntityBindingManagers => _entityBindingManagers;

        private readonly ObservableCollection<IMqttEntityBindingManager> _entityBindingManagers = new ObservableCollection<IMqttEntityBindingManager>();

        private IDisposable CollectionChangeSubscription { get; }
        private IMqttApplicationProvider MqttApplicationProvider { get; set; }
        private IMqttMessageBus MqttMessageBus { get; set; }

        public MqttEntityControlPanel(IEnumerable<IMqttEntityBindingManager> entityBindingManagers = null)
        {
            CollectionChangeSubscription = ObserveCollectionChanges();

            if (entityBindingManagers != null)
            {
                foreach (var entityBindingManager in entityBindingManagers)
                {
                    _entityBindingManagers.Add(entityBindingManager);
                }
            }
        }

        public void BindAll(IMqttApplicationProvider mqttApplicationProvider, IMqttMessageBus mqttMessageBus, bool sendDiscovery = true)
        {
            MqttApplicationProvider = mqttApplicationProvider ?? throw new ArgumentNullException(nameof(mqttApplicationProvider));
            MqttMessageBus = mqttMessageBus ?? throw new ArgumentNullException(nameof(mqttMessageBus));

            foreach (var entityBindingManager in _entityBindingManagers)
            {
                entityBindingManager.BindAll(mqttApplicationProvider, mqttMessageBus, sendDiscovery);
            }

            MqttApplicationProvider.Rebuild();
        }

        public void SendDiscoveryAll()
        {
            foreach (var entityBindingManager in _entityBindingManagers)
            {
                entityBindingManager.SendDiscoveryAll();
            }
        }

        public void DeleteAll()
        {
            foreach (var entityBindingManager in _entityBindingManagers)
            {
                entityBindingManager.DeleteAll();
            }
        }

        public IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> StatefulEntitiesOfType<TMqttEntityConfiguration, TEntity, TEntityDefinition>()
            where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
            where TEntity : IStatefulEntity
            where TEntityDefinition : IStatefulEntityDefinition
        {
            var match = EntityBindingManagers.OfType<IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>>().SingleOrDefault();

            if (match == null)
            {
                match = new MqttStatefulEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>(Enumerable.Empty<TMqttEntityConfiguration>());

                _entityBindingManagers.Add(match);
            }

            return match;
        }

        public IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> EntitiesOfType<TMqttEntityConfiguration, TEntity, TEntityDefinition>()
            where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
            where TEntity : IEntity
            where TEntityDefinition : IEntityDefinition
        {
            var match = EntityBindingManagers.OfType<IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>>().SingleOrDefault();

            if (match == null)
            {
                match = new MqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>(Enumerable.Empty<TMqttEntityConfiguration>());

                _entityBindingManagers.Add(match);
            }

            return match;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000", Justification = "Lifetime is managed elsewhere")]
        public void AddEntity<TMqttEntityConfiguration, TEntity, TEntityDefinition>(TMqttEntityConfiguration entityConfiguration)
            where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
            where TEntity : IEntity
            where TEntityDefinition : IEntityDefinition
        {
            var mqttEntityBinding = new MqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>(entityConfiguration);
            var entityBindingManager = EntitiesOfType<TMqttEntityConfiguration, TEntity, TEntityDefinition>();
            entityBindingManager.EntityConfigurations.Add(mqttEntityBinding);

            if (MqttMessageBus != null)
            {
                mqttEntityBinding.Bind(MqttMessageBus, true);
            }
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000", Justification = "Lifetime is managed elsewhere")]
        public void AddStatefulEntity<TMqttEntityConfiguration, TEntity, TEntityDefinition>(TMqttEntityConfiguration entityConfiguration)
            where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
            where TEntity : IStatefulEntity
            where TEntityDefinition : IStatefulEntityDefinition
        {
            var mqttStatefulEntityBinding = new MqttStatefulEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>(entityConfiguration);
            var entityBindingManager = StatefulEntitiesOfType<TMqttEntityConfiguration, TEntity, TEntityDefinition>();
            entityBindingManager.EntityConfigurations.Add(mqttStatefulEntityBinding);

            if (MqttMessageBus != null)
            {
                mqttStatefulEntityBinding.Bind(MqttMessageBus, true);
            }
        }

        public void ConfigureMqttApplication(IMqttApplicationBuilder mqttApplicationBuilder)
        {
            foreach (var ebm in this.EntityBindingManagers)
            {
                ebm.ConfigureCommands(mqttApplicationBuilder);
            }
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
                CollectionChangeSubscription.Dispose();

                foreach (var bindingManager in EntityBindingManagers)
                {
                    bindingManager.Dispose();
                }
            }
        }

        private IDisposable ObserveCollectionChanges()
            => Observable.FromEvent<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                    handler => (sender, args) => handler(args),
                    handler => _entityBindingManagers.CollectionChanged += handler,
                    handler => _entityBindingManagers.CollectionChanged -= handler)
                .Where(args => args.Action != NotifyCollectionChangedAction.Move)
                .Select(args =>
                (
                    Removed: args.OldItems?.Cast<IMqttEntityBindingManager>().ToArray() ?? Array.Empty<IMqttEntityBindingManager>(),
                    Added: args.NewItems?.Cast<IMqttEntityBindingManager>().ToArray() ?? Array.Empty<IMqttEntityBindingManager>()
                ))
                .Subscribe(x =>
                {
                    foreach (var removed in x.Removed)
                    {
                        removed.Dispose();
                    }

                    if (MqttApplicationProvider != null && MqttMessageBus != null)
                    {
                        foreach (var added in x.Added)
                        {
                            added.BindAll(MqttApplicationProvider, MqttMessageBus, true);
                        }
                    }
                });
    }
}
