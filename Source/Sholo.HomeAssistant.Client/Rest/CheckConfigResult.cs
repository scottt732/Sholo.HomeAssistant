using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Rest
{
    [PublicAPI]
    public class CheckConfigResult
    {
        public string Errors { get; set; }
        public CheckConfigResultValue Result { get; set; }
    }
}
