using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.Person
{
    [PublicAPI]
    public class PersonStateAttributes
    {
        public bool Editable { get; set; }
        public string EntityPicture { get; set; }
        public string FriendlyName { get; set; }
        public int? GpsAccuracy { get; set; }
        public string Id { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Source { get; set; }
        public string UserId { get; set; }
    }
}
