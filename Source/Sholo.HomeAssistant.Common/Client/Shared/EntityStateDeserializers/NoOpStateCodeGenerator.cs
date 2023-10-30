using System.Collections.Generic;
using Sholo.HomeAssistant.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;

public class NoOpStateCodeGenerator : IStateCodeGenerator
{
    public void Observe(string entityId, object state, IDictionary<string, object> attributes)
    {
    }

    public string GenerateCode() => "/* Disabled */";
}
