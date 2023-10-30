using Sholo.HomeAssistant.Client.WebSockets.Events.StateChanged;
using Sholo.HomeAssistant.Domains;

namespace Sholo.HomeAssistant.Client.Http.EntityStates;

[PublicAPI]
public class DeviceTriggerEntityState : EntityState<DeviceTriggerStateValue, DeviceTriggerStateAttributes>
{
}
