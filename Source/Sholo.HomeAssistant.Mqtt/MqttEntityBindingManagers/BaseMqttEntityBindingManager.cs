using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Linq;
using Sholo.HomeAssistant.Mqtt.Entities;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Mqtt.MessageBus;
using Sholo.HomeAssistant.Mqtt.MqttEntityBindings;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations;
using Sholo.Mqtt.Application.Builder;
using Sholo.Mqtt.Application.Provider;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityBindingManagers
{
    public abstract class BaseMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> : IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        public IList<IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>> EntityConfigurations => _entityConfigurations;

        private readonly ObservableCollection<IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>> _entityConfigurations = new ObservableCollection<IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>>();

        private IMqttApplicationProvider MqttApplicationProvider { get; set; }
        private IMqttMessageBus MqttMessageBus { get; set; }
        private IDisposable CollectionChangeSubscription { get; }

        protected BaseMqttEntityBindingManager(
            IEnumerable<TMqttEntityConfiguration> entityConfigurations,
            Func<TMqttEntityConfiguration, IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>> bindingFactory)
        {
            CollectionChangeSubscription = ObserveCollectionChanges();

            foreach (var entityConfiguration in entityConfigurations)
            {
                _entityConfigurations.Add(bindingFactory(entityConfiguration));
            }
        }

        public void BindAll(IMqttApplicationProvider mqttApplicationProvider, IMqttMessageBus mqttMessageBus, bool sendDiscovery = true)
        {
            MqttApplicationProvider = mqttApplicationProvider ?? throw new ArgumentNullException(nameof(mqttApplicationProvider));
            MqttMessageBus = mqttMessageBus ?? throw new ArgumentNullException(nameof(mqttMessageBus));

            foreach (var entityConfiguration in _entityConfigurations) { entityConfiguration.Bind(mqttMessageBus, sendDiscovery); }
        }

        public void SendDiscoveryAll()
        {
            foreach (var entityConfiguration in _entityConfigurations.ToArray()) { entityConfiguration.SendDiscovery(); }
        }

        public void DeleteAll()
        {
            foreach (var entityConfiguration in _entityConfigurations) { entityConfiguration.Delete(); }
        }

        public void ConfigureCommands(IMqttApplicationBuilder mqttApplicationBuilder)
        {
            var topicHandlers = EntityConfigurations
                .SelectMany(x => x.EntityConfiguration.CommandHandlers.Select(y => (configuration: x, commandHandler: y)))
                .GroupBy(x => (topicPattern: x.commandHandler.GetTopicPattern(x.configuration.EntityConfiguration.EntityDefinition), qualityOfServiceLevel: x.configuration.EntityConfiguration.DiscoveryMessageQualityOfServiceLevel))
                .ToDictionary(x => x.Key, x => x.ToArray());

            mqttApplicationBuilder.UseMiddleware(new EntityCommandMiddleware<TMqttEntityConfiguration, TEntity, TEntityDefinition>(topicHandlers));
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

                foreach (var binding in EntityConfigurations)
                {
                    binding.Dispose();
                }
            }
        }

        private IDisposable ObserveCollectionChanges()
            => Observable.FromEvent<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                    handler => (sender, args) => handler(args),
                    handler => _entityConfigurations.CollectionChanged += handler,
                    handler => _entityConfigurations.CollectionChanged -= handler)
                .Where(args => args.Action != NotifyCollectionChangedAction.Move)
                .Select(args =>
                (
                    Removed: args.OldItems?.Cast<IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>>().ToArray() ?? Array.Empty<IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>>(),
                    Added: args.NewItems?.Cast<IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>>().ToArray() ?? Array.Empty<IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>>()
                ))
                .Subscribe(x =>
                {
                    var anyChanges = false;

                    foreach (var removed in x.Removed)
                    {
                        removed.Dispose();
                        anyChanges = true;
                    }

                    if (MqttMessageBus != null)
                    {
                        foreach (var added in x.Added)
                        {
                            added.Bind(MqttMessageBus, true);
                            anyChanges = true;
                        }
                    }

                    if (anyChanges)
                    {
                        MqttApplicationProvider.Rebuild();
                    }
                });
    }
}
