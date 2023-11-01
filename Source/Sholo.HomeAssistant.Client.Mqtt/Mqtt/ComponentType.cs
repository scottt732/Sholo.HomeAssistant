namespace Sholo.HomeAssistant.Client.Mqtt;

/// <summary>
/// Home Assistant Component Types
/// </summary>
public enum ComponentType
{
    /// <summary>
    /// Alarm Control Panel
    /// </summary>
    /// <remarks>
    /// See <a href="https://www.home-assistant.io/integrations/alarm_control_panel.mqtt/">documentation</a>
    /// </remarks>
    [HomeAssistantMqttValue("alarm_control_panel")]
    AlarmControlPanel,

    /// <summary>
    /// Binary Sensor
    /// </summary>
    /// <remarks>
    /// See <a href="https://www.home-assistant.io/integrations/binary_sensor.mqtt/">documentation</a>
    /// </remarks>
    [HomeAssistantMqttValue("binary_sensor")]
    BinarySensor,

    /// <summary>
    /// Camera
    /// </summary>
    /// <remarks>
    /// See <a href="https://www.home-assistant.io/integrations/camera.mqtt/">documentation</a>
    /// </remarks>
    [HomeAssistantMqttValue("camera")]
    Camera,

    /// <summary>
    /// Cover
    /// </summary>
    /// <remarks>
    /// See <a href="https://www.home-assistant.io/integrations/cover.mqtt/">documentation</a>
    /// </remarks>
    [HomeAssistantMqttValue("cover")]
    Cover,

    /// <summary>
    /// Device Trigger
    /// </summary>
    /// <remarks>
    /// See <a href="https://www.home-assistant.io/integrations/device_trigger.mqtt/">documentation</a>
    /// </remarks>
    [HomeAssistantDiscoveryMqttValue("device_automation")]
    [HomeAssistantMqttValue("trigger")]
    DeviceTrigger,

    /// <summary>
    /// Fan
    /// </summary>
    /// <remarks>
    /// See <a href="https://www.home-assistant.io/integrations/fan.mqtt/">documentation</a>
    /// </remarks>
    [HomeAssistantMqttValue("fan")]
    Fan,

    /// <summary>
    /// Climate
    /// </summary>
    /// <remarks>
    /// See <a href="https://www.home-assistant.io/integrations/climate.mqtt/">documentation</a>
    /// </remarks>
    [HomeAssistantMqttValue("climate")]
    Climate,

    /// <summary>
    /// Light
    /// </summary>
    /// <remarks>
    /// See <a href="https://www.home-assistant.io/integrations/light.mqtt/">documentation</a>
    /// </remarks>
    [HomeAssistantMqttValue("light")]
    Light,

    /// <summary>
    /// Lock
    /// </summary>
    /// <remarks>
    /// See <a href="https://www.home-assistant.io/integrations/lock.mqtt/">documentation</a>
    /// </remarks>
    [HomeAssistantMqttValue("lock")]
    Lock,

    /// <summary>
    /// Sensor
    /// </summary>
    /// <remarks>
    /// See <a href="https://www.home-assistant.io/integrations/sensor.mqtt/">documentation</a>
    /// </remarks>
    [HomeAssistantMqttValue("sensor")]
    Sensor,

    /// <summary>
    /// Switch
    /// </summary>
    /// <remarks>
    /// See <a href="https://www.home-assistant.io/integrations/switch.mqtt/">documentation</a>
    /// </remarks>
    [HomeAssistantMqttValue("switch")]
    Switch,

    /// <summary>
    /// Vacuum
    /// </summary>
    /// <remarks>
    /// See <a href="https://www.home-assistant.io/integrations/vacuum.mqtt/">documentation</a>
    /// </remarks>
    [HomeAssistantMqttValue("vacuum")]
    Vacuum
}
