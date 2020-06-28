using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Messages.Config
{
    [PublicAPI]
    public class UnitSystemConfiguration
    {
        public string Length { get; set; }
        public string Mass { get; set; }
        public string Pressure { get; set; }
        public string Temperature { get; set; }
        public string Volume { get; set; }
    }
}
