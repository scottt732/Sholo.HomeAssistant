using System;
using System.Collections.Generic;

namespace Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

[PublicAPI]
public interface IStateProvider
{
    ISet<Type> RegisteredTypes { get; }

    Type GetEntityStateType(string entityId, IDictionary<string, object> attributes);
    Type GetStateChangeEventMessageType(string entityId, IDictionary<string, object> attributes);
}
