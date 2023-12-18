using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sholo.HomeAssistant.Client.WebSockets;
using Sholo.HomeAssistant.Client.WebSockets.Messages;

namespace Sholo.HomeAssistant.Client.Speech.Messages.RunPipeline;

[PublicAPI]
public abstract class BaseRunPipelineMessage : BaseCommand
{
    public PipelineStartStage StartStage { get; }
    public PipelineEndStage EndStage { get; }

    public Dictionary<string, object> Input { get; } = new();

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string? Pipeline { get; }

    public string? ConversationId { get; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public int? Timeout { get; }

    protected HashSet<int> ValidSampleRates { get; } = new() { 8000, 11025, 16000, 22050, 44100, 48000, 88200, 96000, 176400, 192000, 352800, 384000 };

    protected BaseRunPipelineMessage(PipelineStartStage startStage, PipelineEndStage endStage, string? pipeline = null, string? conversationId = null, int? pipelineTimeout = null)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(pipelineTimeout ?? 1, nameof(pipelineTimeout));

        StartStage = startStage;
        EndStage = endStage;
        Pipeline = pipeline;
        ConversationId = conversationId;
        Timeout = pipelineTimeout;
        MessageType = HomeAssistantWsMessageTypes.Instance.AssistPipelineRun();
    }
}

[PublicAPI]
public class RunPipelineFromWakeWordMessage : BaseRunPipelineMessage
{
    public RunPipelineFromWakeWordMessage(
        PipelineEndStage endStage,
        int sampleRate,
        int? wakeWordTimeout = null,
        NoiseSuppressionLevel noiseSuppressionLevel = NoiseSuppressionLevel.Disabled,
        int autoGainDbfs = 0,
        float volumeMultiplier = 1.0f,
        string? pipeline = null,
        string? conversationId = null,
        int? pipelineTimeout = null
    )
        : base(PipelineStartStage.WakeWord, endStage, pipeline, conversationId, pipelineTimeout)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(sampleRate, 8000);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(wakeWordTimeout ?? 1, nameof(wakeWordTimeout));
        ArgumentOutOfRangeException.ThrowIfLessThan((int)noiseSuppressionLevel, 0);
        ArgumentOutOfRangeException.ThrowIfGreaterThan((int)noiseSuppressionLevel, 4);
        ArgumentOutOfRangeException.ThrowIfNegative(autoGainDbfs);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(autoGainDbfs, 31);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(volumeMultiplier, 0.0f);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(volumeMultiplier, 2.0f);

        if (!ValidSampleRates.Contains(sampleRate))
        {
            throw new ArgumentOutOfRangeException(nameof(sampleRate), $"Sample rate must be one of: {string.Join(", ", ValidSampleRates)}");
        }

        if (wakeWordTimeout != null)
        {
            Input["timeout"] = wakeWordTimeout;
        }

        Input["noise_suppression_level"] = (int)noiseSuppressionLevel;
        Input["auto_gain_dbfs"] = autoGainDbfs;
        Input["volume_multiplier"] = volumeMultiplier;

        Input["sample_rate"] = sampleRate;
    }
}

[PublicAPI]
public class RunPipelineFromSttMessage : BaseRunPipelineMessage
{
    public RunPipelineFromSttMessage(PipelineEndStage endStage, int sampleRate, string? pipeline = null, string? conversationId = null, int? pipelineTimeout = null)
        : base(PipelineStartStage.Stt, endStage, pipeline, conversationId, pipelineTimeout)
    {
        if (!ValidSampleRates.Contains(sampleRate))
        {
            throw new ArgumentOutOfRangeException(nameof(sampleRate), $"Sample rate must be one of: {string.Join(", ", ValidSampleRates)}");
        }

        Input["sample_rate"] = sampleRate;
    }
}

[PublicAPI]
public class RunPipelineFromIntentMessage : BaseRunPipelineMessage
{
    public RunPipelineFromIntentMessage(PipelineEndStage endStage, string text, string? pipeline = null, string? conversationId = null, int? pipelineTimeout = null)
        : base(PipelineStartStage.Intent, endStage, pipeline, conversationId, pipelineTimeout)
    {
        Input["text"] = text;
    }
}

[PublicAPI]
public class RunPipelineFromTtsMessage : BaseRunPipelineMessage
{
    public RunPipelineFromTtsMessage(PipelineEndStage endStage, string text, string? pipeline = null, string? conversationId = null, int? pipelineTimeout = null)
        : base(PipelineStartStage.Tts, endStage, pipeline, conversationId, pipelineTimeout)
    {
        Input["text"] = text;
    }
}

[PublicAPI]
public enum PipelineStartStage
{
    WakeWord,
    Stt,
    Intent,
    Tts
}

[PublicAPI]
public enum PipelineEndStage
{
    Stt,
    Intent,
    Tts
}

[PublicAPI]
public enum NoiseSuppressionLevel
{
    Disabled = 0,
    Low = 1,
    Medium = 2,
    High = 3,
    Max = 4
}
