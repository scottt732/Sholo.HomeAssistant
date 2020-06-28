using System.Collections.Generic;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Messages.Services
{
    [PublicAPI]
    public class ServiceDefinition
    {
        public string Description { get; set; }

#pragma warning disable CA2227
        public IDictionary<string, ServiceDefinitionField> Fields { get; set; } = new Dictionary<string, ServiceDefinitionField>();
#pragma warning restore CA2227
    }
}
