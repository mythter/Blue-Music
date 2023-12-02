namespace Spotify.Data
{
    public class PlayStateChangedEventArgs : EventArgs
    {
        public PlayStateChangedEventArgs()
        {
        }

        public PlayStateChangedEventArgs(Guid collectionId, Guid trackId, bool isPaused)
        {
            CollectionId = collectionId;
            TrackId = trackId;
            IsPaused = isPaused;
        }

        public Guid CollectionId { get; set; }

        public Guid TrackId { get; set; }

        public bool IsPaused { get; set; }

        public static readonly new PlayStateChangedEventArgs Empty = new PlayStateChangedEventArgs();
    }
}
