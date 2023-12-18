using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using Sholo.HomeAssistant.Utilities;

namespace Sholo.HomeAssistant.Client.WebSockets;

[PublicAPI]
public sealed class HomeAssistantWsMessageTypes
{
    public static readonly HomeAssistantWsMessageTypes Instance = new();

    // Send
    public static readonly HomeAssistantWsMessageType Auth = Instance.Register();

    // Command
    public static readonly HomeAssistantWsMessageType Ping = Instance.Register();
    public static readonly HomeAssistantWsMessageType Event = Instance.Register();
    public static readonly HomeAssistantWsMessageType FireEvent = Instance.Register();
    public static readonly HomeAssistantWsMessageType SubscribeTrigger = Instance.Register();
    public static readonly HomeAssistantWsMessageType SubscribeEvents = Instance.Register();
    public static readonly HomeAssistantWsMessageType UnsubscribeEvents = Instance.Register();
    public static readonly HomeAssistantWsMessageType CallService = Instance.Register();
    public static readonly HomeAssistantWsMessageType GetStates = Instance.Register();
    public static readonly HomeAssistantWsMessageType GetConfig = Instance.Register();
    public static readonly HomeAssistantWsMessageType GetServices = Instance.Register();
    public static readonly HomeAssistantWsMessageType RenderTemplate = Instance.Register();
    public static readonly HomeAssistantWsMessageType GetPanels = Instance.Register();
    public static readonly HomeAssistantWsMessageType CameraThumbnail = Instance.Register();
    public static readonly HomeAssistantWsMessageType MediaPlayerThumbnail = Instance.Register();
    public static readonly HomeAssistantWsMessageType ValidateConfig = Instance.Register();

    // Result
    public static readonly HomeAssistantWsMessageType AuthOk = Instance.Register();
    public static readonly HomeAssistantWsMessageType AuthInvalid = Instance.Register();
    public static readonly HomeAssistantWsMessageType AuthRequired = Instance.Register();
    public static readonly HomeAssistantWsMessageType Result = Instance.Register();
    public static readonly HomeAssistantWsMessageType Pong = Instance.Register();

    private ConcurrentDictionary<string, HomeAssistantWsMessageType> MessageTypesByProperty { get; } = new();
    private ConcurrentDictionary<string, HomeAssistantWsMessageType> MessageTypesBySerializedForm { get; } = new();

    public HomeAssistantWsMessageType Register(string? pathOverride = null, [CallerMemberName] string? propertyName = null)
    {
        ArgumentNullException.ThrowIfNull(propertyName);

        var messageType = new HomeAssistantWsMessageType(pathOverride ?? propertyName.ToSnakeCase());

        if (!MessageTypesByProperty.TryAdd(propertyName ?? throw new ArgumentNullException(nameof(propertyName)), messageType))
        {
            throw new InvalidOperationException($"Unable to add {propertyName}");
        }

        if (!MessageTypesBySerializedForm.TryAdd(messageType.ToString(), messageType))
        {
            throw new InvalidOperationException($"Unable to add {messageType}");
        }

        return messageType;
    }

    public HomeAssistantWsMessageType GetOrCreate(string path, out bool wasRecognized)
    {
        var wasRecognizedFromLambda = true;
        var result = MessageTypesBySerializedForm.GetOrAdd(path, _ =>
        {
            wasRecognizedFromLambda = false;
            return new HomeAssistantWsMessageType(path);
        });

        wasRecognized = wasRecognizedFromLambda;
        return result;
    }

    private HomeAssistantWsMessageTypes()
    {
    }
}
