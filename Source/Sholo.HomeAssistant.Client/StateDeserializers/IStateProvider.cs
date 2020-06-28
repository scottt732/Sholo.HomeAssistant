using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.StateDeserializers
{
    [PublicAPI]
    public interface IStateProvider
    {
        ISet<Type> RegisteredTypes { get; }

        Type GetEntityStateType(string entityId, IDictionary<string, object> attributes);
        Type GetStateChangeEventMessageType(string entityId, IDictionary<string, object> attributes);
    }
}
