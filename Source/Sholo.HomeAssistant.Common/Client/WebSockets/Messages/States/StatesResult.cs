using Newtonsoft.Json.Linq;

namespace Sholo.HomeAssistant.Client.WebSockets.Messages.States;

public class StatesResult
{
    public JToken[] Results { get; }

    public StatesResult(JToken[] results)
    {
        Results = results;
    }
}
