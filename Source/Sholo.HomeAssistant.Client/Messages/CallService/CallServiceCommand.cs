using System.Collections.Generic;
using Newtonsoft.Json;
using Sholo.HomeAssistant.Client.WebSockets;

namespace Sholo.HomeAssistant.Client.Messages.CallService
{
    public class CallServiceCommand : BaseCommand
    {
        public string Domain { get; }
        public string Service { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, object> ServiceData { get; }

        public CallServiceCommand(string domain, string service)
        {
            MessageType = HomeAssistantWsMessageType.CallService;
            Domain = domain;
            Service = service;
        }

        public CallServiceCommand(string domain, string service, IDictionary<string, object> serviceData)
           : this(domain, service)
        {
            ServiceData = serviceData;
        }
    }
}