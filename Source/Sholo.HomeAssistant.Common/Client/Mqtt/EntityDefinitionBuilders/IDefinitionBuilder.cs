namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

public interface IDefinitionBuilder<TBuilder, out TResult>
    where TBuilder : IDefinitionBuilder<TBuilder, TResult>
{
    TResult Build();
}
