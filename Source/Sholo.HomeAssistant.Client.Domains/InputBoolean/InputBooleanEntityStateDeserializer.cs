using System.Collections.Generic;
using Sholo.HomeAssistant.Client.StateDeserializers;

namespace Sholo.HomeAssistant.Client.Domains.InputBoolean
{
    public class InputBooleanEntityStateDeserializer : BaseStateDeserializer<InputBooleanEntityState>
    {
        public override string TargetDomain { get; } = "input_boolean";
        public override bool CanDeserialize(IDictionary<string, object> attributes) => true;
    }
}