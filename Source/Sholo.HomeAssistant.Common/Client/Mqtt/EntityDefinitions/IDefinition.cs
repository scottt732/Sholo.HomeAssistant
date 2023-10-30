namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public interface IDefinition
{
    string ToJsonString(bool indent);
}
