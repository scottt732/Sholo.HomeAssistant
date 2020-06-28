using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.Lock
{
    public class LockEntityStateDeserializer : BaseStateDeserializer<LockEntityState>
    {
        public override string TargetDomain { get; } = "lock";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}