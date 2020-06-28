namespace Sholo.HomeAssistant.Validation
{
    public interface IValidator
    {
        bool Validate<TMessage>(TMessage obj)
            where TMessage : class;
    }
}
