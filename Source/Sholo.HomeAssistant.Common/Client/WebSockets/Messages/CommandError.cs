using System.Collections.Generic;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages;

[PublicAPI]
public class CommandError
{
    public string Code { get; init; } = null!;
    public string Message { get; init; } = null!;
    public string? TranslationKey { get; init; }
    public string? TranslationDomain { get; init; }
    public IDictionary<string, object?>? TranslationPlaceholders { get; init; }
}
