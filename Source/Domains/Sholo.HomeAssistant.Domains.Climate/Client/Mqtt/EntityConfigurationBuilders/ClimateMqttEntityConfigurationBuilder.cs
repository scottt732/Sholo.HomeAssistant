/*
TODO: Make a ClimateEntityDefinitionBuilder
public class ClimateMqttEntityConfigurationBuilder :
    BaseMqttEntityConfigurationBuilder<ClimateMqttEntityConfigurationBuilder, IClimateMqttEntityConfigurationBuilder, IClimate, IClimateEntityDefinition, ClimateEntityDefinitionBuilder, IClimateMqttEntityConfiguration>,
    IClimateMqttEntityConfigurationBuilder
{
    public override IClimateMqttEntityConfigurationBuilder WithDefaultStateChangeHandlers()
        => this;

    public override IClimateMqttEntityConfigurationBuilder WithDefaultCommandHandlers()
        => this;

    protected override IClimateMqttEntityConfiguration Build(
        IServiceProvider serviceProvider,
        IClimate entity,
        IClimateEntityDefinition entityDefinition,
        string discoveryTopic,
        MqttApplicationMessage discoveryMessage,
        MqttApplicationMessage deleteMessage,
        MqttQualityOfServiceLevel? qualityOfServiceLevel,
        ICommandHandler<IClimate, IClimateEntityDefinition>[] commandHandlers,
        IStateChangeHandler<IClimate, IClimateEntityDefinition>[] stateChangeHandlers)
        => new ClimateMqttEntityConfiguration(
            entity,
            entityDefinition,
            discoveryTopic,
            discoveryMessage,
            deleteMessage,
            qualityOfServiceLevel,
            commandHandlers,
            stateChangeHandlers);

    public ClimateMqttEntityConfigurationBuilder(IServiceCollection services) : base(ComponentType.Climate, services)
    {
    }
}
*/
