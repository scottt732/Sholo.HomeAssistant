using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.Group
{
    public class GroupEntityStateDeserializer : BaseStateDeserializer<GroupEntityState>
    {
        public override string TargetDomain { get; } = "group";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}