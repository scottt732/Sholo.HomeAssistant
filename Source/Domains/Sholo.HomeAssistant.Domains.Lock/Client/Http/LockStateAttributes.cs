namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class LockStateAttributes
{
    public int ClassId { get; set; }
    public string FriendlyName { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public string Help { get; set; } = null!;
    public int Index { get; set; }
    public int Instance { get; set; }
    public bool IsPolled { get; set; }
    public string Label { get; set; } = null!;
    public long? LastUpdate { get; set; }
    public int Max { get; set; }
    public int Min { get; set; }
    public int? NodeId { get; set; }
    public bool ReadOnly { get; set; }
    public string Type { get; set; } = null!;
    public string Units { get; set; } = null!;
    public bool Value { get; set; }
    public string ValueId { get; set; } = null!;
    public bool WriteOnly { get; set; }
}
