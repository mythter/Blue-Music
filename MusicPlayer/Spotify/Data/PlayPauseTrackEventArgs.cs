namespace Spotify.Data
{
    public class PlayPauseTrackEventArgs : EventArgs
    {
        public PlayPauseTrackEventArgs()
        {
        }

        public PlayPauseTrackEventArgs(Guid collectionId, Guid trackId)
        {
            CollectionId = collectionId;
            TrackId = trackId;
        }

        public Guid CollectionId { get; set; }

        public Guid TrackId { get; set; }

        public static readonly new PlayPauseTrackEventArgs Empty = new PlayPauseTrackEventArgs();
    }
}
