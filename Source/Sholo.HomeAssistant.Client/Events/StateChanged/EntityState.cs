using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sholo.HomeAssistant.Client.Events.StateChanged
{
    public class EntityState
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string EntityId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LastChanged { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? LastUpdated { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public EntityStateContext Context { get; set; }

        [JsonProperty("state")]
        public string RawState { get; set; }

        [JsonProperty("attributes")]
        public IDictionary<string, object> RawAttributes { get; } = new Dictionary<string, object>();
    }

    public class EntityState<TStateAttributes> : EntityState
    {
        [JsonProperty("attributes")]
        public TStateAttributes Attributes { get; set; }
    }

    public class EntityState<TStateValue, TStateAttributes> : EntityState<TStateAttributes>
    {
        public TStateValue State { get; set; }
    }
}