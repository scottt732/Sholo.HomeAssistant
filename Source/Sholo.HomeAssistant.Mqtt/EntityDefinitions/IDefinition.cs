using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions
{
    [PublicAPI]
    public interface IDefinition
    {
        string ToJsonString(Formatting formatting = Formatting.None);
        string ToYamlString();
    }
}
