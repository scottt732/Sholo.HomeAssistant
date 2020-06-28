using JetBrains.Annotations;
using Newtonsoft.Json.Linq;

namespace Sholo.HomeAssistant.Client.Messages.Services
{
    [PublicAPI]
    public class ServiceDefinitionField
    {
        public string Description { get; set; }
        public JToken Example { get; set; }
    }
}
