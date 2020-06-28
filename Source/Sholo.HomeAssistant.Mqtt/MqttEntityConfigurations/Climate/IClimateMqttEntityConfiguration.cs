using Sholo.HomeAssistant.Mqtt.Entities.Climate;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Climate;

namespace Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Climate
{
    public interface IClimateMqttEntityConfiguration : IMqttEntityConfiguration<IClimate, IClimateEntityDefinition>
    {
    }
}
