using System;

namespace Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

public interface IEntityStateDeserializer
{
    string TargetEntityId { get; }
    Type TargetStateChangeEventMessageType { get; }
    Type EntityStateType { get; }
}
