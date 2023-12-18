using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitionBuilders;

public class SensorEntityDefinitionBuilder
    : BaseCoreSensorEntityDefinitionBuilder<SensorEntityDefinitionBuilder, ISensorEntityDefinition, SensorEntityDefinition>,
        ISensorEntityDefinitionBuilder<SensorEntityDefinitionBuilder>
{
    public SensorEntityDefinitionBuilder WithDeviceClass(SensorDeviceClass deviceClass)
    {
        Target.DeviceClass = deviceClass != SensorDeviceClass.None ? deviceClass : null;
        return this;
    }

    public SensorEntityDefinitionBuilder WithExpireAfter(int expireAfterSeconds)
    {
        Target.ExpireAfter = expireAfterSeconds;
        return this;
    }

    public SensorEntityDefinitionBuilder WithForceUpdate(bool forceUpdate = false)
    {
        Target.ForceUpdate = forceUpdate;
        return this;
    }

    public SensorEntityDefinitionBuilder WithIcon(string icon)
    {
        Target.Icon = icon;
        return this;
    }

    public SensorEntityDefinitionBuilder WithUnitOfMeasurement(string unitOfMeasurement)
    {
        Target.UnitOfMeasurement = unitOfMeasurement;
        return this;
    }

    public SensorEntityDefinitionBuilder WithSuggestedDisplayPrecision(ushort? numberOfDecimalsAfterRounding)
    {
        Target.SuggestedDisplayPrecision = numberOfDecimalsAfterRounding;
        return this;
    }

    public SensorEntityDefinitionBuilder WithStateClass(SensorStateClass? stateClass)
    {
        Target.StateClass = stateClass;
        return this;
    }

    public SensorEntityDefinitionBuilder WithLastReset(DateTime? lastReset)
    {
        Target.LastReset = lastReset;
        return this;
    }

    public SensorEntityDefinitionBuilder WithLastResetValueTemplate(string? lastResetValueTemplate)
    {
        Target.LastResetValueTemplate = lastResetValueTemplate;
        return this;
    }
}
