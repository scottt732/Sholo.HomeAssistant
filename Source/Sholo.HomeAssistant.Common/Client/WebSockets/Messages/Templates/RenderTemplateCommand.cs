using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Templates;

public class RenderTemplateCommand : BaseCommand
{
    public string Template { get; }
    public string[]? EntityIds { get; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, object?>? Variables { get; }

    public float? Timeout { get; }
    public bool? Strict { get; }
    public bool? ReportErrors { get; }

    public RenderTemplateCommand(
        string template,
        string[]? entityIds = null,
        IDictionary<string, object?>? variables = null,
        float? timeout = null,
        bool? strict = null,
        bool? reportErrors = null
    )
    {
        Template = template;
        EntityIds = entityIds;
        Variables = variables;
        Timeout = timeout;
        Strict = strict;
        ReportErrors = reportErrors;
        MessageType = HomeAssistantWsMessageTypes.RenderTemplate;
    }
}
