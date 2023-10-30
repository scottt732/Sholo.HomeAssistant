using Newtonsoft.Json.Linq;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Services;

[PublicAPI]
public class ServiceDefinitionField
{
    public string Description { get; set; } = null!;
    public JToken Example { get; set; } = null!;
}
