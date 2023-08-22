using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sholo.HomeAssistant.Test.Client.Rest;

public class TestHttpMessageHandler : HttpMessageHandler
{
    private IRequestConfigurationProvider ConfigurationProvider { get; } = new RequestConfigurationProvider();

    public TestHttpMessageHandler Configure(Func<HttpRequestMessage, bool> requestMatcher, Func<HttpRequestMessage, Task<HttpResponseMessage>> responseFactory)
    {
        ConfigurationProvider.Configure(requestMatcher, responseFactory);
        return this;
    }

    public TestHttpMessageHandler Configure(Func<HttpRequestMessage, bool> requestMatcher, Func<HttpRequestMessage, HttpResponseMessage> responseFactory)
    {
        ConfigurationProvider.Configure(requestMatcher, req => Task.FromResult(responseFactory.Invoke(req)));
        return this;
    }

    public TestHttpMessageHandler Configure(Func<HttpRequestMessage, bool> requestMatcher, HttpResponseMessage response)
    {
        ConfigurationProvider.Configure(requestMatcher, req => Task.FromResult(response));
        return this;
    }

    public TestHttpMessageHandler Configure(Func<HttpRequestMessage, bool> requestMatcher, HttpStatusCode statusCode)
    {
        ConfigurationProvider.Configure(requestMatcher, req => Task.FromResult(new HttpResponseMessage(statusCode)));
        return this;
    }

    public TestHttpMessageHandler Configure(Func<HttpRequestMessage, bool> requestMatcher, Func<HttpRequestMessage, Exception> exceptionFactory)
    {
        ConfigurationProvider.Configure(requestMatcher, req => throw exceptionFactory.Invoke(req));
        return this;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return ConfigurationProvider.GetResponse(request);
    }

    private class RequestConfigurationProvider : IRequestConfigurationProvider
    {
        private List<IRequestConfiguration> Configurations { get; } = new ();

        public async Task<HttpResponseMessage> GetResponse(HttpRequestMessage message)
        {
            var matchingConfiguration = Configurations.FirstOrDefault(c => c.IsMatch(message));

            if (matchingConfiguration != null)
            {
                return await matchingConfiguration.GetResponse(message);
            }

            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        public void Configure(Func<HttpRequestMessage, bool> requestMatcher, Func<HttpRequestMessage, Task<HttpResponseMessage>> responseFactory)
        {
            Configurations.Add(new RequestConfiguration(requestMatcher, responseFactory));
        }
    }

    private interface IRequestConfigurationProvider : IRequestProvider
    {
        void Configure(Func<HttpRequestMessage, bool> requestMatcher, Func<HttpRequestMessage, Task<HttpResponseMessage>> responseFactory);
    }

    private interface IRequestProvider
    {
        Task<HttpResponseMessage> GetResponse(HttpRequestMessage message);
    }

    private interface IRequestConfiguration : IRequestProvider
    {
        bool IsMatch(HttpRequestMessage message);
    }

    private class RequestConfiguration : IRequestConfiguration
    {
        private Func<HttpRequestMessage, bool> RequestMatcher { get; }
        private Func<HttpRequestMessage, Task<HttpResponseMessage>> ResponseFactory { get; }

        public bool IsMatch(HttpRequestMessage message) => RequestMatcher.Invoke(message);
        public Task<HttpResponseMessage> GetResponse(HttpRequestMessage message) => ResponseFactory.Invoke(message);

        public RequestConfiguration(Func<HttpRequestMessage, bool> requestMatcher, Func<HttpRequestMessage, Task<HttpResponseMessage>> responseFactory)
        {
            RequestMatcher = requestMatcher;
            ResponseFactory = responseFactory;
        }
    }
}
