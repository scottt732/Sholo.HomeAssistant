using System;

namespace Sholo.HomeAssistant.Client.StateDeserializers
{
    public interface IEntityStateDeserializer
    {
        string TargetEntityId { get; }
        Type TargetStateChangeEventMessageType { get; }
        Type EntityStateType { get; }
    }
}