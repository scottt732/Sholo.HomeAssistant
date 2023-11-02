using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Linq;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;
using Sholo.HomeAssistant.Client.Mqtt.EntityBindings;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Client.Mqtt.MessageBus;
using Sholo.Mqtt.Application.Builder;
using Sholo.Mqtt.Application.BuilderConfiguration;
using Sholo.Mqtt.Application.Provider;

namespace Sholo.HomeAssistant.Client.Mqtt.ControlPanel;

[PublicAPI]
public class MqttEntityControlPanel : IMqttEntityControlPanelHost, IConfigureMqttApplicationBuilder
{
    private IList<IEntityBindingManager> EntityBindingManagers => _entityBindingManagers;

    private readonly ObservableCollection<IEntityBindingManager> _entityBindingManagers = new();
    private IMqttMessageBus _mqttMessageBus;

    private IDisposable CollectionChangeSubscription { get; }
    private IMqttApplicationProvider MqttApplicationProvider { get; set; }

    private IMqttMessageBus MqttMessageBus
    {
        get => _mqttMessageBus;
        set
        {
            var initializing = _mqttMessageBus == null && value != null;

            _mqttMessageBus = value;

            if (initializing)
            {
                foreach (var entityBindingManager in EntityBindingManagers)
                {
                    foreach (var mqttEntityBinding in entityBindingManager.UntypedEntityConfigurations.Where(b => !b.IsBound))
                    {
                        mqttEntityBinding.Bind(_mqttMessageBus, true);
                    }
                }
            }
        }
    }

    private Dictionary<string, IMqttMiddleware> MiddlewareByDomain { get; } = new();

    public MqttEntityControlPanel(IEnumerable<IEntityBindingManager> entityBindingManagers)
    {
        CollectionChangeSubscription = ObserveCollectionChanges();

        /*
        TODO: Can't handle constructor time injection due to lack of type info w/o using reflection
        TODO: May be able to use IMqttEntityBindingManagerConfiguration and extension methods to instantiate

        Had constructor param IEnumerable<IEntityBindingManager> entityBindingManagers = null but need TMqttEntityConfiguration, TEntity, TEntityDefinition
        */
        if (entityBindingManagers != null)
        {
            foreach (var entityBindingManager in entityBindingManagers)
            {
                // var middleware = new EntityCommandMiddleware<TMqttEntityConfiguration, TEntity, TEntityDefinition>(entityBindingManager);
                // entityBindingManager.RebuildRequired += RebuildRequired;
                // _entityBindingManagers.Add(entityBindingManager);
            }
        }
    }

    public void BindAll(IMqttApplicationProvider mqttApplicationProvider, IMqttMessageBus mqttMessageBus, bool sendDiscovery = true)
    {
        MqttApplicationProvider = mqttApplicationProvider ?? throw new ArgumentNullException(nameof(mqttApplicationProvider));
        MqttMessageBus = mqttMessageBus ?? throw new ArgumentNullException(nameof(mqttMessageBus));

        foreach (var entityBindingManager in _entityBindingManagers)
        {
            entityBindingManager.BindAll(mqttMessageBus, sendDiscovery);
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

    public IEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> StatefulEntitiesOfType<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>()
        where TDomain : class, IDomain, new()
        where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IStatefulEntity
        where TEntityDefinition : IStatefulEntityDefinition
    {
        var entityBindingManager = EntityBindingManagers
            .OfType<IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>>()
            .SingleOrDefault();

        if (entityBindingManager == null)
        {
            entityBindingManager = new MqttStatefulEntityBindingManager<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>(Enumerable.Empty<TMqttEntityConfiguration>());
            RegisterMiddleware(entityBindingManager);
            entityBindingManager.RebuildRequired += RebuildRequired;

            _entityBindingManagers.Add(entityBindingManager);
        }

        return entityBindingManager;
    }

    public IEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> EntitiesOfType<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>()
        where TDomain : class, IDomain, new()
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        var entityBindingManager = EntityBindingManagers
            .OfType<IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>>()
            .SingleOrDefault();

        if (entityBindingManager == null)
        {
            entityBindingManager = new MqttEntityBindingManager<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>(Enumerable.Empty<TMqttEntityConfiguration>());
            RegisterMiddleware(entityBindingManager);
            entityBindingManager.RebuildRequired += RebuildRequired;

            _entityBindingManagers.Add(entityBindingManager);
        }

        return entityBindingManager;
    }

    [SuppressMessage("Microsoft.Reliability", "CA2000", Justification = "Lifetime is managed elsewhere")]
    public void AddEntity<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>(TMqttEntityConfiguration entityConfiguration)
        where TDomain : class, IDomain, new()
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        var mqttEntityBinding = new MqttEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>(entityConfiguration);
        var entityBindingManager = EntitiesOfType<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>();
        entityBindingManager.EntityConfigurations.Add(mqttEntityBinding);

        if (MqttMessageBus != null)
        {
            mqttEntityBinding.Bind(MqttMessageBus, true);
        }
    }

    [SuppressMessage("Microsoft.Reliability", "CA2000", Justification = "Lifetime is managed elsewhere")]
    public void AddStatefulEntity<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>(TMqttEntityConfiguration entityConfiguration)
        where TDomain : class, IDomain, new()
        where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IStatefulEntity
        where TEntityDefinition : IStatefulEntityDefinition
    {
        var mqttStatefulEntityBinding = new MqttStatefulEntityBinding<TMqttEntityConfiguration, TEntity, TEntityDefinition>(entityConfiguration);
        var entityBindingManager = StatefulEntitiesOfType<TDomain, TMqttEntityConfiguration, TEntity, TEntityDefinition>();
        entityBindingManager.EntityConfigurations.Add(mqttStatefulEntityBinding);

        if (MqttMessageBus != null)
        {
            mqttStatefulEntityBinding.Bind(MqttMessageBus, true);
        }
    }

    public void ConfigureMqttApplication(IMqttApplicationBuilder mqttApplicationBuilder)
    {
        foreach (var ebm in EntityBindingManagers)
        {
            var middleware = MiddlewareByDomain[ebm.Domain.Name];
            mqttApplicationBuilder.UseMiddleware(middleware);
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
                bindingManager.RebuildRequired -= RebuildRequired;
                bindingManager.Dispose();
            }
        }
    }

    private void RebuildRequired(object sender, EventArgs e)
    {
        MqttApplicationProvider.Rebuild();
    }

    private IDisposable ObserveCollectionChanges()
        => Observable.FromEvent<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                handler => (_, args) => handler(args),
                handler => _entityBindingManagers.CollectionChanged += handler,
                handler => _entityBindingManagers.CollectionChanged -= handler)
            .Where(args => args.Action != NotifyCollectionChangedAction.Move)
            .Select(args =>
            (
                Removed: args.OldItems?.Cast<IEntityBindingManager>().ToArray() ?? Array.Empty<IEntityBindingManager>(),
                Added: args.NewItems?.Cast<IEntityBindingManager>().ToArray() ?? Array.Empty<IEntityBindingManager>()
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
                        added.BindAll(MqttMessageBus, true);
                    }
                }
            });

    private void RegisterMiddleware<TMqttEntityConfiguration, TEntity, TEntityDefinition>(IMqttEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition> entityBindingManager)
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        if (!MiddlewareByDomain.TryGetValue(entityBindingManager.Domain.Name, out var middleware))
        {
            middleware = new EntityCommandMiddleware<TMqttEntityConfiguration, TEntity, TEntityDefinition>(entityBindingManager);
            MiddlewareByDomain[entityBindingManager.Domain.Name] = middleware;
        }
    }
}
