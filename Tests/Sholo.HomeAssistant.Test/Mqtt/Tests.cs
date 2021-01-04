using System.Linq;
using System.Text;
using Moq;
using MQTTnet;
using MQTTnet.Protocol;
using Sholo.HomeAssistant.Mqtt.ControlPanel;
using Sholo.HomeAssistant.Mqtt.Discovery.Payloads;
using Sholo.HomeAssistant.Mqtt.Dispatchers;
using Sholo.HomeAssistant.Mqtt.Entities.Switch;
using Sholo.HomeAssistant.Mqtt.EntityDefinitionBuilders.Switch;
using Sholo.HomeAssistant.Mqtt.EntityDefinitions.Switch;
using Sholo.HomeAssistant.Mqtt.MessageBus;
using Sholo.HomeAssistant.Mqtt.MqttEntityBindingManagers;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurationBuilders.Switch;
using Sholo.HomeAssistant.Mqtt.MqttEntityConfigurations.Switch;
using Sholo.Mqtt.ApplicationProvider;
using Sholo.Mqtt.Consumer;
using Xunit;

namespace Sholo.HomeAssistant.Test.Mqtt
{
    public class Tests
    {
        [Fact]
        public void Test()
        {
            var mockOutboundMessageBus = new Mock<IMqttMessageBus>();
            var mockMqttApplicationProvider = new Mock<IMqttApplicationProvider>();

            var device = CreateTestDevice();

            using var switchEntity = new Switch();
            var switchEntityDefinition = CreateSwitchEntityDefinition(device);
            var switchMqttEntityConfiguration = CreateSwitchMqttEntityConfiguration(switchEntity, switchEntityDefinition);

            var mcp = new MqttEntityControlPanel();
            mcp.AddSwitch(switchMqttEntityConfiguration);

            var expectedDiscoveryPayload = switchMqttEntityConfiguration.DiscoveryMessage.Payload;
            var expectedStateOnPayload = Encoding.UTF8.GetBytes(switchMqttEntityConfiguration.EntityDefinition.StateOn);
            var expectedStateOffPayload = Encoding.UTF8.GetBytes(switchMqttEntityConfiguration.EntityDefinition.StateOff);
            var expectedDeletePayload = switchMqttEntityConfiguration.DeleteMessage.Payload;

            mockOutboundMessageBus
                .Setup(mb => mb.PublishMessage(It.Is<MqttApplicationMessage>(m =>
                    m.Payload.SequenceEqual(expectedDiscoveryPayload) &&
                    m.Topic.Equals(switchMqttEntityConfiguration.DiscoveryTopic))))
                .Verifiable();

            mockOutboundMessageBus
                .Setup(mb => mb.PublishMessage(It.Is<MqttApplicationMessage>(m =>
                    m.Payload.SequenceEqual(expectedStateOnPayload) &&
                    m.Topic.Equals(switchMqttEntityConfiguration.EntityDefinition.StateTopic))))
                .Verifiable();

            mockOutboundMessageBus
                .Setup(mb => mb.PublishMessage(It.Is<MqttApplicationMessage>(m =>
                    m.Payload.SequenceEqual(expectedStateOffPayload) &&
                    m.Topic.Equals(switchMqttEntityConfiguration.EntityDefinition.StateTopic))))
                .Verifiable();

            mockOutboundMessageBus
                .Setup(mb => mb.PublishMessage(It.Is<MqttApplicationMessage>(m =>
                    m.Payload.SequenceEqual(expectedDeletePayload) &&
                    m.Topic.Equals(switchMqttEntityConfiguration.DiscoveryTopic))))
                .Verifiable();

            using (mcp)
            {
                mcp.BindAll(mockMqttApplicationProvider.Object, mockOutboundMessageBus.Object);

                var foundSwitchEntity = mcp.Switches().GetEntityByName(switchEntityDefinition.Name);

                Assert.NotNull(foundSwitchEntity);

                foundSwitchEntity.TurnOn();
                foundSwitchEntity.TurnOff();

                mcp.DeleteAll();
            }

            mockOutboundMessageBus.VerifyAll();
        }

        private static ISwitchMqttEntityConfiguration CreateSwitchMqttEntityConfiguration(ISwitch switchEntity, ISwitchEntityDefinition switchEntityDefinition)
        {
            var ecb = new SwitchMqttEntityConfigurationBuilder()

                // BaseMqttEntityConfigurationBuilder
                .WithEntity(switchEntity)
                .WithEntityDefinition(switchEntityDefinition)
                .WithDiscoveryTopic("test/discovery") // -> CreateDefaultDiscoveryMessage
                .WithDiscoveryMessageQualityOfServiceLevel(MqttQualityOfServiceLevel.ExactlyOnce)
                .WithRetainedDiscoveryMessages(false)

                // .WithDiscoveryMessage(mb => mb.WithPayload("test"))

                // .WithDeleteMessage(mb => mb.WithPayload("test"))

                // Abstract
                .WithDefaultCommandHandlers()

                // BaseMqttStatefulEntityConfigurationBuilder
                .WithStateMessageQualityOfServiceLevel(MqttQualityOfServiceLevel.ExactlyOnce)
                .WithRetainedStateMessages(false)
                .WithDefaultStateChangeHandlers()
                .Build();
            return ecb;
        }

        /*
        private class TestSwitch : ISwitch
        {
            public SwitchState Value { get; set; }
            public IObservable<SwitchState> Values { get; }
            public void TurnOff()
            {
            }

            public void TurnOn()
            {
                throw new NotImplementedException();
            }

            public void Toggle()
            {
                throw new NotImplementedException();
            }
        }
        */

        private IDevice CreateTestDevice()
        {
            var device = new DeviceBuilder()

                // Additive
                .WithConnection("test0", "00_testing")
                .WithConnection("test1", "11_testing")
                .WithIdentifier("test_00112233")
                .WithIdentifier("test_11223344")

                // Last write wins
                .WithManufacturer("Replaced")
                .WithManufacturer("Unit")
                .WithModel("Replaced")
                .WithModel("Test")
                .WithName("Replaced")
                .WithName("Test Device")
                .WithSwVersion("0.1")
                .WithSwVersion("1.0")

                .Build();

            Assert.Equal(2, device.Connections.Count);
            Assert.True(device.Connections.TryGetValue("test0", out var test0Value));
            Assert.True(device.Connections.TryGetValue("test1", out var test1Value));
            Assert.True(device.Connections.TryGetValue("TEST0", out var test0ValueCaseInsensitive));
            Assert.True(device.Connections.TryGetValue("TEST1", out var test1ValueCaseInsensitive));
            Assert.Equal("00_testing", test0Value);
            Assert.Equal("11_testing", test1Value);
            Assert.Equal("00_testing", test0ValueCaseInsensitive);
            Assert.Equal("11_testing", test1ValueCaseInsensitive);

            Assert.Equal(2, device.Identifiers.Length);
            Assert.Collection(
                device.Identifiers,
                id => Assert.Equal("test_00112233", id),
                id => Assert.Equal("test_11223344", id)
            );

            Assert.Equal("Unit", device.Manufacturer);
            Assert.Equal("Test", device.Model);
            Assert.Equal("Test Device", device.Name);
            Assert.Equal("1.0", device.SwVersion);

            return device;
        }

        private ISwitchEntityDefinition CreateSwitchEntityDefinition(IDevice device)
        {
            var sed = new SwitchEntityDefinitionBuilder()

                // BaseEntityDefinitionBuilder
                .WithDevice(device)

                .WithName("Replaced")
                .WithName("Test Switch")
                .WithUniqueId("Replaced")
                .WithUniqueId("switch_00")

                // BaseStatefulEntityDefinitionBuilder
                .WithAvailabilityPayloads("replaced", "replaced")
                .WithAvailabilityPayloads("test_online", "test_offline")
                .WithAvailabilityTopic("replaced")
                .WithAvailabilityTopic("test/switch/availability")
                .WithJsonAttributes("replaced", "{{ value_json.replaced }}")
                .WithJsonAttributes("test/switch/attributes", "{{ value_json.test }}")
                .WithQos(MqttQualityOfServiceLevel.AtMostOnce)
                .WithQos(MqttQualityOfServiceLevel.AtLeastOnce, false)
                .WithQos(MqttQualityOfServiceLevel.ExactlyOnce, true)
                .WithState("replaced", "replaced")
                .WithState("test/state", "{{ value_json.value }}")

                // BaseCoreSwitchEntityDefinitionBuilder
                .WithCommandTopic("replaced")
                .WithCommandTopic("test/command")
                .WithOptimisticMode(false)
                .WithOptimisticMode(true)

                // SwitchEntityDefinitionBuilder
                .WithIcon("mdi:replaced")
                .WithIcon("mdi:test")
                .WithOnOffPayloads("REPLACED_ON", "REPLACED_OFF")
                .WithOnOffPayloads("TEST_ON", "TEST_OFF")
                .WithOnOffStates("REPLACED_ON_STATE", "REPLACED_OFF_STATE")
                .WithOnOffStates("TEST_ON_STATE", "TEST_OFF_STATE")

                .Build();

            // BaseEntityDefinitionBuilder
            Assert.Same(device, sed.Device);

            Assert.Equal("Test Switch", sed.Name);
            Assert.Equal("switch_00", sed.UniqueId);

            // BaseStatefulEntityDefinitionBuilder
            Assert.Equal("test_online", sed.PayloadAvailable);
            Assert.Equal("test_offline", sed.PayloadNotAvailable);

            Assert.Equal("test/switch/availability", sed.AvailabilityTopic);

            Assert.Equal("test/switch/attributes", sed.JsonAttributesTopic);
            Assert.Equal("{{ value_json.test }}", sed.JsonAttributesTemplate);

            Assert.Equal(MqttQualityOfServiceLevel.ExactlyOnce, sed.Qos);
            Assert.Equal(true, sed.Retain);

            Assert.Equal("test/state", sed.StateTopic);
            Assert.Equal("{{ value_json.value }}", sed.ValueTemplate);

            // BaseCoreSwitchEntityDefinitionBuilder
            Assert.Equal("test/command", sed.CommandTopic);
            Assert.True(sed.Optimistic);

            // SwitchEntityDefinitionBuilder
            Assert.Equal("mdi:test", sed.Icon);

            Assert.Equal("TEST_ON", sed.PayloadOn);
            Assert.Equal("TEST_OFF", sed.PayloadOff);

            Assert.Equal("TEST_ON_STATE", sed.StateOn);
            Assert.Equal("TEST_OFF_STATE", sed.StateOff);

            return sed;
        }
    }
}
