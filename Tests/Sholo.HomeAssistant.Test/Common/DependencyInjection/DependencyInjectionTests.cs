using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sholo.HomeAssistant.Client;
using Sholo.HomeAssistant.Client.Http.Rest;
using Sholo.HomeAssistant.Client.Shared.EntityStateDeserializers;
using Sholo.HomeAssistant.Client.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets.ConnectionService;
using Sholo.HomeAssistant.StateDeserializers;
using Sholo.HomeAssistant.Validation;

namespace Sholo.HomeAssistant.Test.Common.DependencyInjection;

public class DependencyInjectionTests
{
    [Fact]
    public void HasValidator()
    {
        var sp = CreateFixture();

        sp.GetRequiredService<IValidator>();
    }

    [Fact]
    public void AddClient_HasExpectedServices()
    {
        var sp = CreateFixture(null, c => c.WithHttpClient(hc => hc.AddWebSocketApiClient()));
        sp.GetRequiredService<IHomeAssistantRestClient>();

        sp.GetRequiredService<IHomeAssistantWebSocketsConnectionService>();
        sp.GetRequiredService<IHomeAssistantWebSocketsClientFactory>();
        sp.GetRequiredService<IHomeAssistantWebSocketsClient>();
        sp.GetRequiredService<IHostedService>();

        sp.GetRequiredService<IStateProvider>();
        sp.GetRequiredService<IStateCodeGenerator>();
    }

#pragma warning disable CA1859
    private static IServiceProvider CreateFixture(
        IDictionary<string, string> configuration = null,
        Func<IHomeAssistantConfigurationBuilder, IHomeAssistantConfigurationBuilder> registrationConfigurator = null
    )
#pragma warning restore CA1859
    {
        var configurationBuilder = new ConfigurationBuilder();

        if (configuration != null)
        {
            configurationBuilder.AddInMemoryCollection(configuration);
        }

        var configurationRoot = configurationBuilder.Build();

        var serviceCollection = new ServiceCollection();

        var homeAssistantServiceCollection = serviceCollection.AddHomeAssistant(configurationRoot);

        registrationConfigurator?.Invoke(homeAssistantServiceCollection);

        return homeAssistantServiceCollection.Services.BuildServiceProvider();
    }
}
