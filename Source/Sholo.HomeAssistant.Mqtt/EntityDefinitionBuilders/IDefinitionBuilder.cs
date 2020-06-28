namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders
{
    public interface IDefinitionBuilder<TBuilder, out TResult>
        where TBuilder : IDefinitionBuilder<TBuilder, TResult>
    {
        TResult Build();
    }
}