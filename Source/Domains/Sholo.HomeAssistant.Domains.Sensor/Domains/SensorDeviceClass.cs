// ReSharper disable CommentTypo
// ReSharper disable InconsistentNaming
namespace Sholo.HomeAssistant.Domains;

/// <summary>
/// Sensor device classes
/// </summary>
/// <remarks>
/// See <a href="https://www.home-assistant.io/integrations/sensor/#device-class">documentation</a>
/// </remarks>
[PublicAPI]
public enum SensorDeviceClass
{
    /// <summary>
    /// Generic sensor. This is the default and doesn't need to be set.
    /// </summary>
    [HomeAssistantMqttValue("")]
    None,

    /// <summary>
    /// apparent_power: Apparent power in VA.
    /// </summary>
    [HomeAssistantMqttValue("apparent_power")]
    ApparentPower,

    /// <summary>
    /// aqi: Air Quality Index (unitless).
    /// </summary>
    [HomeAssistantMqttValue("aqi")]
    AQI,

    /// <summary>
    /// atmospheric_pressure: Atmospheric pressure in cbar, bar, hPa, mmHg, inHg, kPa, mbar, Pa or psi
    /// </summary>
    [HomeAssistantMqttValue("atmospheric_pressure")]
    AtmosphericPressure,

    /// <summary>
    /// battery: Percentage of battery that is left in %.
    /// </summary>
    [HomeAssistantMqttValue("battery")]
    Battery,

    /// <summary>
    /// carbon_dioxide: Carbon Dioxide in CO2 (Smoke) in ppm
    /// </summary>
    [HomeAssistantMqttValue("carbon_dioxide")]
    CarbonDioxide,

    /// <summary>
    /// carbon_monoxide: Carbon Monoxide in CO (Gas CNG/LPG) in ppm
    /// </summary>
    [HomeAssistantMqttValue("carbon_monoxide")]
    CarbonMonoxide,

    /// <summary>
    /// current: Current in A, mA
    /// </summary>
    [HomeAssistantMqttValue("current")]
    Current,

    /// <summary>
    /// data_rate: Data rate in bit/s, kbit/s, Mbit/s, Gbit/s, B/s, kB/s, MB/s, GB/s, KiB/s, MiB/s or GiB/s
    /// </summary>
    [HomeAssistantMqttValue("data_rate")]
    DataRate,

    /// <summary>
    /// data_size: Data size in bit, kbit, Mbit, Gbit, B, kB, MB, GB, TB, PB, EB, ZB, YB, KiB, MiB, GiB, TiB, PiB, EiB, ZiB or YiB
    /// </summary>
    [HomeAssistantMqttValue("data_size")]
    DataSize,

    /// <summary>
    /// date: Date string (ISO 8601)
    /// </summary>
    [HomeAssistantMqttValue("date")]
    Date,

    /// <summary>
    /// distance: Generic distance in km, m, cm, mm, mi, yd, or in
    /// </summary>
    [HomeAssistantMqttValue("distance")]
    Distance,

    /// <summary>
    /// duration: Duration in d, h, min, or s
    /// </summary>
    [HomeAssistantMqttValue("duration")]
    Duration,

    /// <summary>
    /// energy: Energy in Wh, kWh, MWh, MJ, or GJ
    /// </summary>
    [HomeAssistantMqttValue("energy")]
    Energy,

    /// <summary>
    /// energy_storage: Stored energy in Wh, kWh, MWh, MJ, or GJ
    /// </summary>
    [HomeAssistantMqttValue("energy_storage")]
    EnergyStorage,

    /// <summary>
    /// enum: Has a limited set of (non-numeric) states
    /// </summary>
    [HomeAssistantMqttValue("enum")]
    Enum,

    /// <summary>
    /// frequency: Frequency in Hz, kHz, MHz, or GHz
    /// </summary>
    [HomeAssistantMqttValue("frequency")]
    Frequency,

    /// <summary>
    /// gas: Gasvolume in m³, ft³ or CCF.
    /// </summary>
    [HomeAssistantMqttValue("gas")]
    Gas,

    /// <summary>
    /// humidity: Percentage of humidity in the air in %.
    /// </summary>
    [HomeAssistantMqttValue("humidity")]
    Humidity,

    /// <summary>
    /// illuminance: The current light level in lx or lm.
    /// </summary>
    [HomeAssistantMqttValue("illuminance")]
    Illuminance,

    /// <summary>
    /// irradiance: Irradiance in W/m² or BTU/(h⋅ft²)
    /// </summary>
    [HomeAssistantMqttValue("irradiance")]
    Irradiance,

    /// <summary>
    /// moisture: Percentage of water in a substance in %
    /// </summary>
    [HomeAssistantMqttValue("moisture")]
    Moisture,

    /// <summary>
    /// monetary: The monetary value (ISO 4217)
    /// </summary>
    [HomeAssistantMqttValue("monetary")]
    Monetary,

    /// <summary>
    /// nitrogen_dioxide: Concentration of Nitrogen Dioxide in µg/m³
    /// </summary>
    [HomeAssistantMqttValue("nitrogen_dioxide")]
    NitrogenDioxide,

    /// <summary>
    /// nitrogen_monoxide: Concentration of Nitrogen Monoxide in µg/m³
    /// </summary>
    [HomeAssistantMqttValue("nitrogen_monoxide")]
    NitrogenMonoxide,

    /// <summary>
    /// nitrous_oxide: Concentration of Nitrous Oxide in µg/m³
    /// </summary>
    [HomeAssistantMqttValue("nitrous_oxide")]
    NitrousOxide,

    /// <summary>
    /// ozone: Concentration of Ozone in µg/m³
    /// </summary>
    [HomeAssistantMqttValue("ozone")]
    Ozone,

    /// <summary>
    /// ph: Potential hydrogen (pH) value of a water solution
    /// </summary>
    [HomeAssistantMqttValue("ph")]
#pragma warning disable SA1300
    pH,
#pragma warning restore SA1300

    /// <summary>
    /// pm1: Concentration of particulate matter less than 1 micrometer in µg/m³
    /// </summary>
    [HomeAssistantMqttValue("pm1")]
    PM1,

    /// <summary>
    /// pm25: Concentration of particulate matter less than 2.5 micrometers in µg/m³
    /// </summary>
    [HomeAssistantMqttValue("pm25")]
    PM25,

    /// <summary>
    /// pm10: Concentration of particulate matter less than 10 micrometers in µg/m³
    /// </summary>
    [HomeAssistantMqttValue("pm10")]
    PM10,

    /// <summary>
    /// power_factor: Power factor (unitless), unit may be None or %
    /// </summary>
    [HomeAssistantMqttValue("power_factor")]
    PowerFactor,

    /// <summary>
    /// power: Power in W or kW.
    /// </summary>
    [HomeAssistantMqttValue("power")]
    Power,

    /// <summary>
    /// precipitation: Accumulated precipitation in cm, in or mm
    /// </summary>
    [HomeAssistantMqttValue("precipitation")]
    Precipitation,

    /// <summary>
    /// precipitation_intensity: Precipitation intensity in in/d, in/h, mm/d or mm/h
    /// </summary>
    [HomeAssistantMqttValue("precipitation_intensity")]
    PrecipitationIntensity,

    /// <summary>
    /// pressure: Pressure in Pa, kPa, hPa, bar, cbar, mbar, mmHg, inHg or psi
    /// </summary>
    [HomeAssistantMqttValue("pressure")]
    Pressure,

    /// <summary>
    /// reactive_power: Reactive power in var
    /// </summary>
    [HomeAssistantMqttValue("reactive_power")]
    ReactivePower,

    /// <summary>
    /// signal_strength: Signal strength in dB or dBm.
    /// </summary>
    [HomeAssistantMqttValue("signal_strength")]
    SignalStrength,

    /// <summary>
    /// sound_pressure: Sound pressure in dB or dBA
    /// </summary>
    [HomeAssistantMqttValue("sound_pressure")]
    SoundPressure,

    /// <summary>
    /// speed: Generic speed in ft/s, in/d, in/h, km/h, kn, m/s, mph or mm/d
    /// </summary>
    [HomeAssistantMqttValue("speed")]
    Speed,

    /// <summary>
    /// sulphur_dioxide: Concentration of sulphur dioxide in µg/m³
    /// </summary>
    [HomeAssistantMqttValue("sulphur_dioxide")]
    SulphurDioxide,

    /// <summary>
    /// temperature: Temperature in °C or °F or K.
    /// </summary>
    [HomeAssistantMqttValue("temperature")]
    Temperature,

    /// <summary>
    /// timestamp: Datetime object or timestamp string (ISO 8601)
    /// </summary>
    [HomeAssistantMqttValue("timestamp")]
    Timestamp,

    /// <summary>
    /// volatile_organic_compounds: Concentration of volatile organic compounds in µg/m³
    /// </summary>
    [HomeAssistantMqttValue("volatile_organic_compounds")]
    VolatileOrganicCompounds,

    /// <summary>
    /// volatile_organic_compounds_parts: Ratio of volatile organic compounds in ppm or ppb
    /// </summary>
    [HomeAssistantMqttValue("volatile_organic_compounds_parts")]
    VolatileOrganicCompoundsParts,

    /// <summary>
    /// voltage: Voltage in V, mV
    /// </summary>
    [HomeAssistantMqttValue("voltage")]
    Voltage,

    /// <summary>
    /// volume: Generic volume in L, mL, gal, fl. oz., m³, ft³, or CCF
    /// </summary>
    [HomeAssistantMqttValue("volume")]
    Volume,

    /// <summary>
    /// volume_storage: Generic stored volume in L, mL, gal, fl. oz., m³, ft³, or CCF
    /// </summary>
    [HomeAssistantMqttValue("volume_storage")]
    VolumeStorage,

    /// <summary>
    /// water: Water consumption in L, gal, m³, ft³, or CCF
    /// </summary>
    [HomeAssistantMqttValue("water")]
    Water,

    /// <summary>
    /// weight: Generic mass in kg, g, mg, µg, oz, lb, or st
    /// </summary>
    [HomeAssistantMqttValue("weight")]
    Weight,

    /// <summary>
    /// wind_speed: Wind speed in ft/s, km/h, kn, m/s, or mph
    /// </summary>
    [HomeAssistantMqttValue("wind_speed")]
    WindSpeed,
}
