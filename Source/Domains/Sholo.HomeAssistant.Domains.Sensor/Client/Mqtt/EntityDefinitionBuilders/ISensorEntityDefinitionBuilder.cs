using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

[PublicAPI]
public interface ISensorEntityDefinitionBuilder<out TSelf> : ICoreSensorEntityDefinitionBuilder<TSelf, ISensorEntityDefinition, SensorDeviceClass>
    where TSelf : ISensorEntityDefinitionBuilder<TSelf>
{
    TSelf WithIcon(string icon);
    TSelf WithUnitOfMeasurement(string unitOfMeasurement);
    TSelf WithSuggestedDisplayPrecision(ushort? numberOfDecimalsAfterRounding);
    TSelf WithStateClass(SensorStateClass? stateClass);
    TSelf WithLastReset(DateTime? lastReset);
    TSelf WithLastResetValueTemplate(string? lastResetValueTemplate);
}
