using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Sholo.HomeAssistant.Client.Events.StateChanged;

namespace Sholo.HomeAssistant.Client.StateDeserializers
{
    [PublicAPI]
    public abstract class BaseDeviceClassStateDeserializer<TState> : BaseStateDeserializer<TState>
        where TState : EntityState
    {
        public abstract string TargetDeviceClass { get; }

        public override bool CanDeserialize(IDictionary<string, object> attributes) =>
            attributes.TryGetValue("device_class", out var deviceClassObj)
            && deviceClassObj is string deviceClass
            && deviceClass.Equals(TargetDeviceClass, StringComparison.Ordinal);
    }
}
