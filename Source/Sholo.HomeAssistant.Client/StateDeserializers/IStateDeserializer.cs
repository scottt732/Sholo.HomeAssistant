using System;
using System.Collections.Generic;

namespace Sholo.HomeAssistant.Client.StateDeserializers
{
    public interface IStateDeserializer
    {
        string TargetDomain { get; }
        bool CanDeserialize(IDictionary<string, object> attributes);
        Type TargetStateChangeEventMessageType { get; }
        Type EntityStateType { get; }
    }
}