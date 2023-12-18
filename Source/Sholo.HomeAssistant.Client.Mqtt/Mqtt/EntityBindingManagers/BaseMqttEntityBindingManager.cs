using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Sholo.HomeAssistant.Client.Mqtt.CommandHandlers;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindings;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.MessageBus;
using Sholo.Mqtt;
using Sholo.Mqtt.Middleware;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;

[PublicAPI]
public abstract class BaseMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> : IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>
    where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
    public IDomain Domain { get; }
    public IList<IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>> EntityConfigurations => _entityConfigurations;
    public IMqttMiddleware CreateMiddleware() => new EntityCommandMiddleware(this);

    public IEnumerable<IMqttEntityBinding> UntypedEntityConfigurations => EntityConfigurations.Cast<IMqttEntityBinding>().ToList();

    public event EventHandler RebuildRequired;

    protected void OnRebuildRequired(object sender)
    {
        RebuildRequired?.Invoke(this, EventArgs.Empty);
    }

    private Func<IMqttRequestContext, IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>, ICommandContext<TEntity, TEntityDefinition>> CommandContextFactory { get; }

    private readonly ObservableCollection<IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>> _entityConfigurations = new();

    private IMqttMessageBus MqttMessageBus { get; set; }
    private IDisposable CollectionChangeSubscription { get; }

    protected BaseMqttEntityBindingManager(
        IDomain domain,
        IEnumerable<TMqttEntityConfiguration> entityConfigurations,
        Func<TMqttEntityConfiguration, IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>> entityBindingFactory,
        Func<IMqttRequestContext, IMqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>, ICommandContext<TEntity, TEntityDefinition>> commandContextFactory)
    {
        Domain = domain;
        CommandContextFactory = commandContextFactory;
        CollectionChangeSubscription = ObserveCollectionChanges();

        foreach (var entityConfiguration in entityConfigurations)
        {
            var entityBinding = entityBindingFactory.Invoke(entityConfiguration);
            _entityConfigurations.Add(entityBinding);
        }
    }

    public void BindAll(IMqttMessageBus mqttMessageBus, bool sendDiscovery = true)
    {
        MqttMessageBus = mqttMessageBus ?? throw new ArgumentNullException(nameof(mqttMessageBus));

        foreach (var entityConfiguration in _entityConfigurations.Where(x => !x.IsBound))
        {
            entityConfiguration.Bind(mqttMessageBus, sendDiscovery);
        }
    }

    public void SendDiscoveryAll()
    {
        foreach (var entityConfiguration in _entityConfigurations.ToArray()) { entityConfiguration.SendDiscovery(); }
    }

    public void DeleteAll()
    {
        foreach (var entityConfiguration in _entityConfigurations) { entityConfiguration.Delete(); }
    }

    public IEnumerable<Func<IMqttRequestContext, Task<bool>>> GetTopicMessageHandlers()
    {
        var topicCommandHandlers = EntityConfigurations
            .SelectMany(x => x.EntityConfiguration.CommandHandlers.Select(y => (configuration: x, commandHandler: y)))
            .GroupBy(x => (topicPattern: x.commandHandler.GetTopicPattern(x.configuration.EntityConfiguration.EntityDefinition), qualityOfServiceLevel: x.configuration.EntityConfiguration.DiscoveryMessageQualityOfServiceLevel))
            .ToDictionary(x => x.Key, x => x.ToArray());

        foreach (var (_, topicHandlers) in topicCommandHandlers)
        {
            foreach (var (mqttEntityBinding, commandHandler) in topicHandlers)
            {
                yield return mqttRequestContext =>
                {
                    var payload = Encoding.UTF8.GetString(mqttRequestContext.Payload);
                    var commandContext = CommandContextFactory.Invoke(mqttRequestContext, mqttEntityBinding);

                    return commandHandler.ProcessCommandAsync(commandContext, payload);
                };
            }
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

            foreach (var binding in EntityConfigurations)
            {
                binding.Dispose();
            }
        }
    }

    private IDisposable ObserveCollectionChanges()
        => Observable.FromEvent<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                handler => (_, args) => handler(args),
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
                    OnRebuildRequired(this);
                }
            });
}
