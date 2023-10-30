namespace Sholo.HomeAssistant.Client.Http;

[PublicAPI]
public class MediaPlayerStateAttributes
{
    public string FriendlyName { get; set; } = null!;
    public bool IsVolumeMuted { get; set; }
    public string MediaContentType { get; set; } = null!;
    public string MediaTitle { get; set; } = null!;
    public string SoundMode { get; set; } = null!;
    public string[] SoundModeList { get; set; } = null!;
    public string SoundModeRaw { get; set; } = null!;
    public string Source { get; set; } = null!;
    public string[] SourceList { get; set; } = null!;
    public int? SupportedFeatures { get; set; }
    public double? VolumeLevel { get; set; }
    public string /* Ambiguous */ AdbResponse { get; set; } = null!;
    public string AppId { get; set; } = null!;
    public string AppName { get; set; } = null!;
    public string EntityPicture { get; set; } = null!;
    public string SoundOutput { get; set; } = null!;
    public bool? NightSound { get; set; }
    public bool? Shuffle { get; set; }
    public string[] SonosGroup { get; set; } = null!;
    public bool? SpeechEnhance { get; set; }
    public string MediaContentId { get; set; } = null!;
    public int? MediaDuration { get; set; }
    public int? MediaPosition { get; set; }
    public string MediaPositionUpdatedAt { get; set; } = null!;
    public string MediaContentRating { get; set; } = null!;
    public string MediaLibraryName { get; set; } = null!;
    public string SessionUsername { get; set; } = null!;
    public string Summary { get; set; } = null!;
    public bool? Restored { get; set; }
    public string DeviceId { get; set; } = null!;
    public string Type { get; set; } = null!;
}
