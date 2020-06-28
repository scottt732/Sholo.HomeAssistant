using System.Collections.Generic;
using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.StateDeserializers
{
    [PublicAPI]
    public interface IStateCodeGenerator
    {
        void Observe(string entityId, object state, IDictionary<string, object> attributes);
        string GenerateCode();
    }
}
