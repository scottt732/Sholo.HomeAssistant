using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Lock
{
    [PublicAPI]
    public class LockStateAttributes
    {
        public int ClassId { get; set; }
        public string FriendlyName { get; set; }
        public string Genre { get; set; }
        public string Help { get; set; }
        public int Index { get; set; }
        public int Instance { get; set; }
        public bool IsPolled { get; set; }
        public string Label { get; set; }
        public long? LastUpdate { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public int? NodeId { get; set; }
        public bool ReadOnly { get; set; }
        public string Type { get; set; }
        public string Units { get; set; }
        public bool Value { get; set; }
        public string ValueId { get; set; }
        public bool WriteOnly { get; set; }
    }
}
