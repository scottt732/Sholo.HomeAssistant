using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sholo.HomeAssistant.Client.Shared.EntityStates;

namespace Sholo.HomeAssistant.Client.WebSockets.Events.StateChanged;

[PublicAPI]
public class EntityState : IEntityState
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string EntityId { get; set; } = null!;

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset? LastChanged { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset? LastUpdated { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public IEntityStateContext Context { get; set; } = null!;

    [JsonProperty("state")]
    public string RawState { get; set; } = null!;

    [JsonProperty("attributes")]
    public IDictionary<string, object> RawAttributes { get; } = new Dictionary<string, object>();
}

[PublicAPI]
public class EntityState<TStateAttributes> : EntityState
{
    [JsonProperty("attributes")]
    public TStateAttributes Attributes { get; set; } = default!;
}

[PublicAPI]
public class EntityState<TStateValue, TStateAttributes> : EntityState<TStateAttributes>
{
    public TStateValue State { get; set; } = default!;
}
