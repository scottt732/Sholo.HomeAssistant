using System;
using Sholo.HomeAssistant.Mqtt.Discovery.Payloads;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders
{
    public abstract class BaseEntityDefinitionBuilder<TBuilder, TResultInterface, TResult> :
        BaseDefinitionBuilder<TBuilder, TResultInterface, TResult>,
        IEntityDefinitionBuilder<TBuilder, TResultInterface>
            where TBuilder : BaseEntityDefinitionBuilder<TBuilder, TResultInterface, TResult>
            where TResultInterface : IEntityDefinition
            where TResult : BaseEntityDefinition, TResultInterface, new()
    {
        public TBuilder WithDevice(Action<IDeviceBuilder> deviceConfigurator)
        {
            var deviceBuilder = new DeviceBuilder();
            deviceConfigurator.Invoke(deviceBuilder);
            return WithDevice(deviceBuilder.Build());
        }

        public TBuilder WithDevice(IDevice device)
        {
            Target.Device = device;
            return (TBuilder)this;
        }

        public TBuilder WithName(string name)
        {
            Target.Name = name;
            return (TBuilder)this;
        }

        public TBuilder WithUniqueId(string uniqueId)
        {
            Target.UniqueId = uniqueId;
            return (TBuilder)this;
        }
    }
}
