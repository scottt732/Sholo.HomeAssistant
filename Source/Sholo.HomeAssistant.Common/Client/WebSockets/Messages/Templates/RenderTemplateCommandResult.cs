namespace Sholo.HomeAssistant.Client.WebSockets.Messages.Templates;

public class RenderTemplateCommandResult : BaseCommandResult
{
    public RenderTemplateCommandResult()
        : base(HomeAssistantWsMessageTypes.Result)
    {
    }
}
