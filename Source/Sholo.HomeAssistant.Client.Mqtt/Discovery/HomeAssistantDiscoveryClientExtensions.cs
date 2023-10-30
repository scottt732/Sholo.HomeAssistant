namespace Sholo.HomeAssistant.Client.Mqtt.Discovery;

public static class HomeAssistantDiscoveryClientExtensions
{
    /*
    public static Task<MqttClientPublishResult> SendConfigureDeviceAsync<TConfigureDevicePayload>(
        this IHomeAssistantDiscoveryClient discoveryClient,
        Action<IDiscoveryTopicBuilder> discoveryTopicConfigurator,
        TConfigureDevicePayload payload,
        CancellationToken cancellationToken = default)
    {
        var discoveryTopicBuilder = new DiscoveryTopicBuilder(discoveryClient.Settings.Value.DiscoveryPrefix);
        discoveryTopicConfigurator.Invoke(discoveryTopicBuilder);
        var configTopic = discoveryTopicBuilder.BuildConfigTopic();

        return discoveryClient.SendDiscoveryAsync(configTopic, discoveryTopicConfigurator, cancellationToken);
    }
    */
}
