using System.Threading.Tasks;
using Sholo.Mqtt;
using Sholo.Mqtt.Middleware;

namespace Sholo.HomeAssistant.Client.Mqtt.EntityBindingManagers;

[PublicAPI]
public class EntityCommandMiddleware : IMqttMiddleware
{
    private IMqttEntityBindingManager EntityBindingManager { get; }

    public EntityCommandMiddleware(IMqttEntityBindingManager entityBindingManager)
    {
        EntityBindingManager = entityBindingManager;
    }

    public async Task<bool> InvokeAsync(IMqttRequestContext context, MqttRequestDelegate next)
    {
        foreach (var messageHandler in EntityBindingManager.GetTopicMessageHandlers())
        {
            var result = await messageHandler.Invoke(context);
            if (result)
            {
                return true;
            }
        }

        return false;
    }
}
