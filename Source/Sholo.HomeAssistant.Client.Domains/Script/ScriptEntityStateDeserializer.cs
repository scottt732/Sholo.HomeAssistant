using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.Script
{
    public class ScriptEntityStateDeserializer : BaseStateDeserializer<ScriptEntityState>
    {
        public override string TargetDomain { get; } = "script";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}
