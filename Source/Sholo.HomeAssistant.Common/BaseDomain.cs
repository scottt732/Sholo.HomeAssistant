using System;

namespace Sholo.HomeAssistant;

public abstract class BaseDomain : IDomain
{
    public abstract string Name { get; }
    public abstract string ManifestJsonPath { get; }
    public virtual Uri? DocumentationUri { get; } = null!;
    public virtual Uri? MqttDocumentationUri { get; } = null!;
    public virtual string? ServicesYamlPath { get; } = null!;
    public virtual string? StringsJsonPath { get; } = null!;
    public virtual string? MqttValue { get; } = null!;
    public virtual string? MqttDiscoveryValue { get; } = null!;
}
