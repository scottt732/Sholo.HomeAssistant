using System;

namespace Sholo.HomeAssistant
{
    [AttributeUsage(AttributeTargets.Field)]
    public class HomeAssistantMqttValueAttribute : Attribute
    {
        public string MqttString { get; }

        public HomeAssistantMqttValueAttribute(string mqttString)
        {
            MqttString = mqttString;
        }
    }
}