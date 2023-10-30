using System.Collections.Generic;

namespace Sholo.HomeAssistant.StateDeserializers;

[PublicAPI]
public interface IStateCodeGenerator
{
    void Observe(string entityId, object state, IDictionary<string, object> attributes);
    string GenerateCode();
}
