using System;

namespace Sholo.HomeAssistant;

[PublicAPI]
public interface IDomain
{
    string Name { get; }
    string ManifestJsonPath { get; }
    Uri? DocumentationUri { get; }
    Uri? MqttDocumentationUri { get; }
    string? ServicesYamlPath { get; }
    string? StringsJsonPath { get; }
    string? MqttValue { get; }
    string? MqttDiscoveryValue { get; }
}
