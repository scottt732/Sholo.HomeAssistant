using System.Collections.Generic;

namespace Sholo.HomeAssistant.Client.StateDeserializers
{
    public class NoOpStateCodeGenerator : IStateCodeGenerator
    {
        public void Observe(string entityId, object state, IDictionary<string, object> attributes)
        {
        }

        public string GenerateCode() => "/* Disabled */";
    }
}
