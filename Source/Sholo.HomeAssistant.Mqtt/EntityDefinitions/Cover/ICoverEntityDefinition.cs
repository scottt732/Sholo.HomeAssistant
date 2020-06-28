using JetBrains.Annotations;
using Sholo.HomeAssistant.DeviceClasses;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions.Cover
{
    [PublicAPI]
    public interface ICoverEntityDefinition : ICoreSwitchEntityDefinition
    {
        /// <summary>
        /// Sets the class of the device, changing the device state and icon that is displayed
        /// on the frontend.
        /// </summary>
        CoverDeviceClass? DeviceClass { get; }

        /// <summary>
        /// The command payload that closes the cover.
        /// </summary>
        string PayloadClose { get; }

        /// <summary>
        /// The command payload that opens the cover.
        /// </summary>
        string PayloadOpen { get; }

        /// <summary>
        /// The command payload that stops the cover.
        /// </summary>
        string PayloadStop { get; }

        /// <summary>
        /// Number which represents closed position.
        /// </summary>
        int? PositionClosed { get; }

        /// <summary>
        /// Number which represents open position.
        /// </summary>
        int? PositionOpen { get; }

        /// <summary>
        /// The MQTT topic subscribed to receive cover position messages. If position_topic is
        /// set state_topic is ignored.
        /// </summary>
        string PositionTopic { get; }

        /// <summary>
        /// Defines a template to define the position to be sent to the set_position_topic topic.
        /// Incoming position value is available for use in the template ``. If no template is
        /// defined, the position (0-100) will be calculated according to position_open and
        /// position_closed values.
        /// </summary>
        string SetPositionTemplate { get; }

        /// <summary>
        /// The MQTT topic to publish position commands to. You need to set position_topic as well
        /// if you want to use position topic. Use template if position topic wants different
        /// values than within range position_closed - position_open. If template is not defined
        /// and position_closed != 100 and position_open != 0 then proper position value is
        /// calculated from percentage position.
        /// </summary>
        string SetPositionTopic { get; }

        /// <summary>
        /// The payload that represents the closed state.
        /// </summary>
        string StateClosed { get; }

        /// <summary>
        /// The payload that represents the closing state.
        /// </summary>
        string StateClosing { get; }

        /// <summary>
        /// The payload that represents the open state.
        /// </summary>
        string StateOpen { get; }

        /// <summary>
        /// The payload that represents the opening state.
        /// </summary>
        string StateOpening { get; }

        /// <summary>
        /// The value that will be sent on a close_cover_tilt command.
        /// </summary>
        int? TiltClosedValue { get; }

        /// <summary>
        /// The MQTT topic to publish commands to control the cover tilt.
        /// </summary>
        string TiltCommandTopic { get; }

        /// <summary>
        /// Flag that determines if open/close are flipped; higher values toward closed and lower
        /// values toward open.
        /// </summary>
        bool? TiltInvertState { get; }

        /// <summary>
        /// The maximum tilt value
        /// </summary>
        int? TiltMax { get; }

        /// <summary>
        /// The minimum tilt value.
        /// </summary>
        int? TiltMin { get; }

        /// <summary>
        /// The value that will be sent on an open_cover_tilt command.
        /// </summary>
        int? TiltOpenedValue { get; }

        /// <summary>
        /// Flag that determines if tilt works in optimistic mode.
        /// </summary>
        bool? TiltOptimistic { get; }

        /// <summary>
        /// Defines a template that can be used to extract the payload for the tilt_status_topic topic.
        /// </summary>
        string TiltStatusTemplate { get; }

        /// <summary>
        /// The MQTT topic subscribed to receive tilt status update values.
        /// </summary>
        string TiltStatusTopic { get; }
    }
}
