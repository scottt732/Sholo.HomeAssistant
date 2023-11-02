using System.Reactive;
using Sholo.HomeAssistant.Client.Mqtt.EntityDefinitions;

namespace Sholo.HomeAssistant.Client.Mqtt.StateChangeHandlers;

public class ButtonStateChangeHandler : BaseStateChangeHandler<IButton, IButtonEntityDefinition>
{
    public override string GetStateMessagePayload(IButtonEntityDefinition entityDefinition, IButton entity)
    {
        throw new NotImplementedException();
    }

    public override IObservable<Unit> GetStateChangeDetector(IButton entity)
    {
        throw new NotImplementedException();
    }
}
