using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sholo.HomeAssistant.Client;
using Sholo.HomeAssistant.Client.Rest;
using Sholo.HomeAssistant.Client.StateDeserializers;
using Sholo.HomeAssistant.Client.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets.ConnectionService;
using Sholo.HomeAssistant.DependencyInjection;
using Sholo.HomeAssistant.Validation;
using Xunit;

namespace Sholo.HomeAssistant.Test.Common.DependencyInjection
{
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
            var sp = CreateFixture(null, c => c.AddClient());
            sp.GetRequiredService<IHomeAssistantRestClient>();

            sp.GetRequiredService<IHomeAssistantWebSocketsConnectionService>();
            sp.GetRequiredService<IHomeAssistantWebSocketsClientFactory>();
            sp.GetRequiredService<IHomeAssistantWebSocketsClient>();
            sp.GetRequiredService<IHostedService>();

            sp.GetRequiredService<IStateProvider>();
            sp.GetRequiredService<IStateCodeGenerator>();
        }

        private static IServiceProvider CreateFixture(
            IDictionary<string, string> configuration = null,
            Func<IHomeAssistantServiceCollection, IHomeAssistantServiceCollection> registrationConfigurator = null
        )
        {
            var configurationBuilder = new ConfigurationBuilder();

            if (configuration != null)
            {
                configurationBuilder.AddInMemoryCollection(configuration);
            }

            var configurationRoot = configurationBuilder.Build();

            var serviceCollection = new ServiceCollection();

            var homeAssistantServiceCollection = serviceCollection.AddHomeAssistant(null);

            registrationConfigurator?.Invoke(homeAssistantServiceCollection);

            return homeAssistantServiceCollection.BuildServiceProvider();
        }
    }
}
