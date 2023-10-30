using System;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

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
