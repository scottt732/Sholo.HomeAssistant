using JetBrains.Annotations;

namespace Sholo.HomeAssistant.Client.Domains.MediaPlayer
{
    [PublicAPI]
    public class MediaPlayerStateAttributes
    {
        public string FriendlyName { get; set; }
        public bool IsVolumeMuted { get; set; }
        public string MediaContentType { get; set; }
        public string MediaTitle { get; set; }
        public string SoundMode { get; set; }
        public string[] SoundModeList { get; set; }
        public string SoundModeRaw { get; set; }
        public string Source { get; set; }
        public string[] SourceList { get; set; }
        public int? SupportedFeatures { get; set; }
        public double? VolumeLevel { get; set; }
        public string /* Ambiguous */ AdbResponse { get; set; }
        public string AppId { get; set; }
        public string AppName { get; set; }
        public string EntityPicture { get; set; }
        public string SoundOutput { get; set; }
        public bool? NightSound { get; set; }
        public bool? Shuffle { get; set; }
        public string[] SonosGroup { get; set; }
        public bool? SpeechEnhance { get; set; }
        public string MediaContentId { get; set; }
        public int? MediaDuration { get; set; }
        public int? MediaPosition { get; set; }
        public string MediaPositionUpdatedAt { get; set; }
        public string MediaContentRating { get; set; }
        public string MediaLibraryName { get; set; }
        public string SessionUsername { get; set; }
        public string Summary { get; set; }
        public bool? Restored { get; set; }
        public string DeviceID { get; set; }
        public string Type { get; set; }
    }
}
