using System;
using JetBrains.Annotations;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders
{
    [PublicAPI]
    public interface ICoreSensorEntityDefinitionBuilder<out TSelf, out TResult, in TDeviceClass> : IStatefulEntityDefinitionBuilder<TSelf, TResult>
        where TSelf : ICoreSensorEntityDefinitionBuilder<TSelf, TResult, TDeviceClass>
        where TDeviceClass : Enum
        where TResult : IStatefulEntityDefinition
    {
        TSelf WithDeviceClass(TDeviceClass deviceClass);
        TSelf WithExpireAfter(int expireAfterSeconds);
        TSelf WithForceUpdate(bool forceUpdate = false);
    }
}
