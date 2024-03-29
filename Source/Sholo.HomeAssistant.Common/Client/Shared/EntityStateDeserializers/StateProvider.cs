using System;
using System.Collections.Generic;
using System.Linq;
using Sholo.HomeAssistant.Client.WebSockets.Events;
using Sholo.HomeAssistant.Client.WebSockets.Events.StateChanged;
using Sholo.HomeAssistant.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

public class StateProvider : IStateProvider
{
    public ISet<Type> RegisteredTypes { get; }

    private Dictionary<string, IEntityStateDeserializer[]> EntityStateDeserializersByEntityId { get; }
    private Dictionary<string, IStateDeserializer[]> StateDeserializersByDomain { get; }

    public StateProvider(
        IEnumerable<IEntityStateDeserializer> entityStateDeserializers,
        IEnumerable<IStateDeserializer> stateDeserializers
    )
    {
        EntityStateDeserializersByEntityId = entityStateDeserializers
            .GroupBy(x => x.TargetEntityId)
            .ToDictionary(x => x.Key, x => x.Reverse().ToArray());

        StateDeserializersByDomain = stateDeserializers
            .GroupBy(x => x.TargetDomain)
            .ToDictionary(x => x.Key, x => x.Reverse().ToArray());

        RegisteredTypes = new HashSet<Type>(
            EntityStateDeserializersByEntityId.Values.SelectMany(x => x).Select(x => x.TargetStateChangeEventMessageType)
                .Concat(StateDeserializersByDomain.Values.SelectMany(x => x).Select(x => x.TargetStateChangeEventMessageType)));
    }

    public Type GetEntityStateType(string entityId, IDictionary<string, object> attributes)
    {
        if (EntityStateDeserializersByEntityId.TryGetValue(entityId, out var entityStateDeserializers))
        {
            return entityStateDeserializers.Select(x => x.EntityStateType).First();
        }

        var domain = EntityId.GetDomain(entityId);

        if (StateDeserializersByDomain.TryGetValue(domain, out var stateDeserializers))
        {
            foreach (var stateDeserializer in stateDeserializers)
            {
                if (stateDeserializer.CanDeserialize(attributes))
                {
                    return stateDeserializer.EntityStateType;
                }
            }
        }

        return typeof(EntityState);
    }

    public Type GetStateChangeEventMessageType(string entityId, IDictionary<string, object> attributes)
    {
        if (EntityStateDeserializersByEntityId.TryGetValue(entityId, out var entityStateDeserializers))
        {
            return entityStateDeserializers.Select(x => x.TargetStateChangeEventMessageType).First();
        }

        var domain = EntityId.GetDomain(entityId);

        if (StateDeserializersByDomain.TryGetValue(domain, out var stateDeserializers))
        {
            foreach (var stateDeserializer in stateDeserializers)
            {
                if (stateDeserializer.CanDeserialize(attributes))
                {
                    return stateDeserializer.TargetStateChangeEventMessageType;
                }
            }
        }

        return typeof(EventMessage<StateChangePayload>);
    }
}
