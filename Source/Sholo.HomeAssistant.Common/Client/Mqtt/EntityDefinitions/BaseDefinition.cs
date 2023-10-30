using System.IO;
using System.Text;
using Newtonsoft.Json;
using Sholo.HomeAssistant.Serialization;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

[PublicAPI]
public abstract class BaseDefinition : IDefinition
{
    protected static JsonSerializer JsonSerializer { get; }
    protected static JsonSerializer IndentedJsonSerializer { get; }

    static BaseDefinition()
    {
        JsonSerializer = JsonSerializer.Create(HomeAssistantSerializerSettings.JsonSerializerSettings);
        IndentedJsonSerializer = JsonSerializer.Create(HomeAssistantSerializerSettings.IndentedJsonSerializerSettings);
    }

    public override string ToString() => ToJsonString(true);

    public string ToJsonString(bool indent)
    {
        var sb = new StringBuilder();
        using (var sw = new StringWriter(sb))
        {
            if (indent)
            {
                IndentedJsonSerializer.Serialize(sw, this);
            }
            else
            {
                JsonSerializer.Serialize(sw, this);
            }
        }

        return sb.ToString();
    }
}
