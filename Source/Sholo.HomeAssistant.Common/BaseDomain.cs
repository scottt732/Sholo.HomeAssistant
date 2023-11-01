using System;

namespace Sholo.HomeAssistant;

[PublicAPI]
public abstract class BaseDomain : IDomain
{
    public abstract string Name { get; }
    public abstract string ManifestJsonPath { get; }
    public virtual Uri? DocumentationUri { get; }
    public virtual Uri? MqttDocumentationUri { get; }
    public virtual string? ServicesYamlPath { get; }
    public virtual string? StringsJsonPath { get; }
    public virtual string? MqttValue { get; }
    public virtual string? MqttDiscoveryValue { get; }
}
