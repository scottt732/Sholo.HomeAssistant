using System.Runtime.Serialization;

namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public enum WeatherStateValue
{
    Unavailable,
    Sunny,
    Cloudy,
    PartlyCloudy,

    [EnumMember(Value = "clear-night")]
    ClearNight
}
