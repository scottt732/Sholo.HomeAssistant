namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders
{
    public abstract class BaseDefinitionBuilder<TBuilder, TResultInterface, TResult> : IDefinitionBuilder<TBuilder, TResultInterface>
        where TBuilder : BaseDefinitionBuilder<TBuilder, TResultInterface, TResult>
        where TResult : class, TResultInterface, new()
    {
        protected TResult Target { get; } = new TResult();

        public TResultInterface Build()
        {
            Validate();
            return Target;
        }

        protected virtual void Validate()
        {
            // TODO: Data annotations validator
        }
    }
}