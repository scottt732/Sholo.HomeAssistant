using System;
using System.Collections.Generic;
using Sholo.HomeAssistant.Client.Shared.EntityStates;

namespace Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

[PublicAPI]
public abstract class BaseDeviceClassStateDeserializer<TState> : BaseStateDeserializer<TState>
    where TState : class, IEntityState
{
    public abstract string TargetDeviceClass { get; }

    public override bool CanDeserialize(IDictionary<string, object> attributes) =>
        attributes.TryGetValue("device_class", out var deviceClassObj)
        && deviceClassObj is string deviceClass
        && deviceClass.Equals(TargetDeviceClass, StringComparison.Ordinal);
}
