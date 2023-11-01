using System;

namespace Sholo.HomeAssistant;

public interface IMqttEntityBindingManagerConfiguration
{
    Type DomainType { get; }
    Type MqttEntityConfigurationType { get; }
    Type EntityType { get; }
    Type EntityDefinitionType { get; }
}
