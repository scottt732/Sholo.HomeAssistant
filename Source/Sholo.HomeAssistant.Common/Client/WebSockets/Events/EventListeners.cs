using System;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Templates;

[PublicAPI]
public class EventListeners
{
    public bool All { get; init; }
    public string[] Domains { get; init; } = Array.Empty<string>();
    public string[] Entities { get; init; } = Array.Empty<string>();
    public bool Time { get; init; }
}
