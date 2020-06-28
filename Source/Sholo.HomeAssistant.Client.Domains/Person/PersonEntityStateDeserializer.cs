using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.Person
{
    public class PersonEntityStateDeserializer : BaseStateDeserializer<PersonEntityState>
    {
        public override string TargetDomain { get; } = "person";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}