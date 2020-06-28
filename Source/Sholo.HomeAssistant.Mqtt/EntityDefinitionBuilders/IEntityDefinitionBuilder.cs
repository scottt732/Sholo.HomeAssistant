using System;
using JetBrains.Annotations;
using Sholo.HomeAssistant.Mqtt.Discovery.Payloads;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders
{
    [PublicAPI]
    public interface IEntityDefinitionBuilder<out TEntityDefinitionBuilder, out TEntityDefinition>
        where TEntityDefinitionBuilder : IEntityDefinitionBuilder<TEntityDefinitionBuilder, TEntityDefinition>
        where TEntityDefinition : IEntityDefinition
    {
        /// <summary>
        /// Information about the device this binary sensor is a part of to tie it into the
        /// device registry. Only works through MQTT discovery and when unique_id is set.
        /// </summary>
        /// <param name="deviceConfigurator">The device configurator</param>
        /// <returns>A <typeparamref name="TEntityDefinitionBuilder" /></returns>
        TEntityDefinitionBuilder WithDevice(Action<IDeviceBuilder> deviceConfigurator);

        /// <summary>
        /// Information about the device this binary sensor is a part of to tie it into the
        /// device registry. Only works through MQTT discovery and when unique_id is set.
        /// </summary>
        /// <param name="device">An <see cref="IDevice" /></param>
        /// <returns>A <typeparamref name="TEntityDefinitionBuilder" /></returns>
        TEntityDefinitionBuilder WithDevice(IDevice device);

        /// <summary>
        /// The name of the device being built
        /// </summary>
        /// <param name="name">The name of the device</param>
        /// <returns>A <typeparamref name="TEntityDefinitionBuilder" /></returns>
        TEntityDefinitionBuilder WithName(string name);

        /// <summary>
        /// An ID that uniquely identifies this device. If two devices have the same unique ID
        /// Home Assistant will raise an exception.
        /// </summary>
        /// <param name="uniqueId">An ID that uniquely identifies this device.</param>
        /// <returns>A <typeparamref name="TEntityDefinitionBuilder" /></returns>
        TEntityDefinitionBuilder WithUniqueId(string uniqueId);

        TEntityDefinition Build();
    }
}
