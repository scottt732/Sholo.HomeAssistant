using Microsoft.Extensions.DependencyInjection;
using Sholo.HomeAssistant.Client.Mqtt.Entities;
using Sholo.HomeAssistant.Client.Mqtt.EntityConfigurations;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.StateDeserializers;

namespace Sholo.HomeAssistant;

public interface IMqttEntityBindingManagerFactory
{
}

public class MqttEntityBindingManagerFactory<TMqttEntityConfiguration, TEntity, TEntityDefinition> : IMqttEntityBindingManagerFactory
    where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IEntity
    where TEntityDefinition : IEntityDefinition
{
    public MqttEntityBindingManagerFactory()
    {
    }
}

public class MqttStatefulEntityBindingManagerFactory<TMqttEntityConfiguration, TEntity, TEntityDefinition> : IMqttEntityBindingManagerFactory
    where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
    where TEntity : IStatefulEntity
    where TEntityDefinition : IStatefulEntityDefinition
{
    public MqttStatefulEntityBindingManagerFactory(DomainRegistry.Instance)
    {
    }
}

public class HomeAssistantDomainsConfigurationBuilder : IHomeAssistantDomainsConfigurationBuilder
{
    public IServiceCollection ServiceCollection => ConfigurationBuilder.ServiceCollection;

    private IHomeAssistantClientConfigurationBuilder ConfigurationBuilder { get; }

    public HomeAssistantDomainsConfigurationBuilder(IHomeAssistantClientConfigurationBuilder configurationBuilder)
    {
        ConfigurationBuilder = configurationBuilder;
    }

    public IHomeAssistantDomainsConfigurationBuilder AddDomain<TStateDeserializer>()
        where TStateDeserializer : class, IStateDeserializer
    {
        ConfigurationBuilder.ServiceCollection.AddSingleton<IStateDeserializer, TStateDeserializer>();
        return this;
    }

    public virtual IHomeAssistantDomainsConfigurationBuilder TryRegisterEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>()
        where TMqttEntityConfiguration : IMqttEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IEntity
        where TEntityDefinition : IEntityDefinition
    {
        return this;
    }

    public virtual IHomeAssistantDomainsConfigurationBuilder TryRegisterStatefulEntityBindingManager<TMqttEntityConfiguration, TEntity, TEntityDefinition>()
        where TMqttEntityConfiguration : IMqttStatefulEntityConfiguration<TEntity, TEntityDefinition>
        where TEntity : IStatefulEntity
        where TEntityDefinition : IStatefulEntityDefinition
    {
        return this;
    }
}
