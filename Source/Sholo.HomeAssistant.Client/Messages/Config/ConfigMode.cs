using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Messages.Config
{
    [PublicAPI]
    public enum ConfigMode
    {
        Yaml,
        Storage
    }
}
