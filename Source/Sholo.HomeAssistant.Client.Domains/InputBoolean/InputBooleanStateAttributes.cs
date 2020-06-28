using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.InputBoolean
{
    [PublicAPI]
    public class InputBooleanStateAttributes
    {
        public bool Editable { get; set; }
        public string FriendlyName { get; set; }
        public string Icon { get; set; }
    }
}
