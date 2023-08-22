using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Sholo.HomeAssistant.Client.Messages.Config;
using Sholo.HomeAssistant.Client.Rest;
using Sholo.HomeAssistant.Client.Settings;
using Sholo.HomeAssistant.Client.StateDeserializers;
using Xunit;

namespace Sholo.HomeAssistant.Test.Client.Rest
{
    [PublicAPI]
    public sealed class HomeAssistantRestClientTests : IDisposable
    {
        private Mock<IOptions<HomeAssistantClientOptions>> MockHomeAssistantClientOptions { get; } = new (MockBehavior.Strict);
        private Mock<IStateProvider> MockStateProvider { get; } = new (MockBehavior.Strict);
        private Mock<IStateCodeGenerator> MockStateCodeGenerator { get; } = new (MockBehavior.Strict);
        private Mock<ILogger<HomeAssistantRestClient>> MockLogger { get; } = new (MockBehavior.Loose);

        [Fact]
        public async Task GetApiIsEnabled_WhenReturnsExpectedResponse_ReturnsTrue()
        {
            var restClient = CreateRestClient(h =>
            {
                h.Configure(
                    r => r.RequestUri!.Equals(new Uri("https://sample.ha.com/api/")),
                    m => new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(RestFixtures.IsEnabled.Json, Encoding.UTF8, "application/json")
                    });
            });

            var response = await restClient.GetApiEnabledAsync(null, CancellationToken.None);

            Assert.True(response);
        }

        [Fact]
        public async Task GetApiIsEnabled_WhenRequestTimesOut_ReturnsFalse()
        {
            var restClient = CreateRestClient(h =>
            {
                h.Configure(
                    r => r.RequestUri!.Equals(new Uri("https://sample.ha.com/api/")),
                    m => new TaskCanceledException("Cancelled", new TimeoutException("Timed out")));
            });

            var response = await restClient.GetApiEnabledAsync(null, CancellationToken.None);

            Assert.False(response);
        }

        [Fact]
        public async Task GetApiIsEnabled_WhenTaskIsCancelled_ThrowsTaskCancelledException()
        {
            var restClient = CreateRestClient(h =>
            {
                h.Configure(
                    r => r.RequestUri!.Equals(new Uri("https://sample.ha.com/api/")),
                    m => new TaskCanceledException("Cancelled"));
            });

            var result = await restClient.GetApiEnabledAsync(null, CancellationToken.None);

            Assert.False(result);
        }

        [Fact]
        public async Task GetApiIsEnabled_WhenHttpResponseExceptionOccurs_ReturnsFalse()
        {
            var restClient = CreateRestClient(h =>
            {
                h.Configure(
                    r => r.RequestUri!.Equals(new Uri("https://sample.ha.com/api/")),
                    m => new HttpRequestException("Error"));
            });

            var response = await restClient.GetApiEnabledAsync(null, CancellationToken.None);

            Assert.False(response);
        }

        [Fact]
        public async Task GetEventsAsync()
        {
            var restClient = CreateRestClient(h =>
            {
                h.Configure(
                    r => r.RequestUri!.Equals(new Uri("https://sample.ha.com/api/events")),
                    m => new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(RestFixtures.Events.Json, Encoding.UTF8, "application/json")
                    });
            });

            var events = await restClient.GetEventsAsync(CancellationToken.None);

            Assert.Equal(2, events.Length);

            Assert.Collection(
                events,
                e =>
                {
                    var expectedEvent = RestFixtures.Events.ExpectedEvents[0];
                    Assert.Equal(expectedEvent.Event, e.Event);
                    Assert.Equal(expectedEvent.ListenerCount, e.ListenerCount);
                },
                e =>
                {
                    var expectedEvent = RestFixtures.Events.ExpectedEvents[1];
                    Assert.Equal(expectedEvent.Event, e.Event);
                    Assert.Equal(expectedEvent.ListenerCount, e.ListenerCount);
                });
        }

        [Fact]
        public async Task GetConfigurationAsync()
        {
            var restClient = CreateRestClient(h =>
            {
                h.Configure(
                    r => r.RequestUri!.Equals(new Uri("https://sample.ha.com/api/config")),
                    m => new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(RestFixtures.Config.Json, Encoding.UTF8, "application/json")
                    });
            });

            var response = await restClient.GetConfigurationAsync(CancellationToken.None);

            Assert.Equal(RestFixtures.Config.Latitude, response.Latitude, 5);
            Assert.Equal(RestFixtures.Config.Longitude, response.Longitude, 5);
            Assert.Equal(RestFixtures.Config.Elevation, response.Elevation);
            Assert.Equal(RestFixtures.Config.UnitSystemLength, response.UnitSystem.Length);
            Assert.Equal(RestFixtures.Config.UnitSystemMass, response.UnitSystem.Mass);
            Assert.Equal(RestFixtures.Config.UnitSystemPressure, response.UnitSystem.Pressure);
            Assert.Equal(RestFixtures.Config.UnitSystemTemperature, response.UnitSystem.Temperature);
            Assert.Equal(RestFixtures.Config.UnitSystemVolume, response.UnitSystem.Volume);
            Assert.Equal(RestFixtures.Config.LocationName, response.LocationName);
            Assert.Equal(RestFixtures.Config.TimeZone, response.TimeZone);

            Assert.All(response.Components, c => Assert.Contains(c, RestFixtures.Config.Components));
            Assert.All(RestFixtures.Config.Components, c => Assert.Contains(c, response.Components));

            Assert.Equal(RestFixtures.Config.ConfigDir, response.ConfigDir);

            Assert.All(response.WhitelistExternalDirs, c => Assert.Contains(c, RestFixtures.Config.WhitelistExternalDirs));
            Assert.All(RestFixtures.Config.WhitelistExternalDirs, c => Assert.Contains(c, response.WhitelistExternalDirs));

            Assert.All(response.AllowlistExternalDirs, c => Assert.Contains(c, RestFixtures.Config.AllowlistExternalDirs));
            Assert.All(RestFixtures.Config.AllowlistExternalDirs, c => Assert.Contains(c, response.AllowlistExternalDirs));

            Assert.All(response.AllowlistExternalUrls, c => Assert.Contains(c, RestFixtures.Config.AllowlistExternalUrls));
            Assert.All(RestFixtures.Config.AllowlistExternalUrls, c => Assert.Contains(c, response.AllowlistExternalUrls));

            Assert.Equal(RestFixtures.Config.Version, response.Version);
            Assert.Equal(ConfigMode.Storage, response.ConfigSource);
            Assert.Equal(RestFixtures.Config.SafeMode, response.SafeMode);
            Assert.Equal(RestFixtures.Config.State, response.State);

            Assert.StartsWith(RestFixtures.Config.InternalUrl, response.InternalUrl.AbsoluteUri, StringComparison.Ordinal);
            Assert.Equal(RestFixtures.Config.InternalUrl.Length, response.InternalUrl.AbsoluteUri.Length - 1);

            Assert.StartsWith(RestFixtures.Config.ExternalUrl, response.ExternalUrl.AbsoluteUri, StringComparison.Ordinal);
            Assert.Equal(RestFixtures.Config.ExternalUrl.Length, response.ExternalUrl.AbsoluteUri.Length - 1);

            Assert.Equal(RestFixtures.Config.Currency, response.Currency);
        }

        public void Dispose()
        {
            MockStateProvider.VerifyAll();
        }

        private IHomeAssistantRestClient CreateRestClient(
            Action<TestHttpMessageHandler> handlerConfig,
            Action<HomeAssistantClientOptions> optionsConfig = null)
        {
            var opt = new HomeAssistantClientOptions
            {
                RestApiUrlPrefix = new Uri("https://sample.ha.com/api/")
            };
            optionsConfig?.Invoke(opt);

            MockHomeAssistantClientOptions.SetupGet(o => o.Value)
                .Returns(opt);

#pragma warning disable CA2000 // Dispose objects before losing scope
            var testMessageHandler = new TestHttpMessageHandler();
            handlerConfig.Invoke(testMessageHandler);

            var httpClient = new HttpClient(testMessageHandler)
            {
                BaseAddress = opt.RestApiUrlPrefix,
            };
#pragma warning restore CA2000 // Dispose objects before losing scope

            var restClient = new HomeAssistantRestClient(
                httpClient,
                MockHomeAssistantClientOptions.Object,
                MockStateProvider.Object,
                MockStateCodeGenerator.Object,
                MockLogger.Object
            );

            return restClient;
        }
    }
}
