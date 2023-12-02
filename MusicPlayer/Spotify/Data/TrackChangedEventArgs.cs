namespace Spotify.Data
{
    public class TrackChangedEventArgs : EventArgs
    {
        public TrackChangedEventArgs()
        {
        }

        public TrackChangedEventArgs(Guid collectionId, Guid trackId)
        {
            CollectionId = collectionId;
            TrackId = trackId;
        }

        public Guid CollectionId { get; set; }

        public Guid TrackId { get; set; }

        public static readonly new TrackChangedEventArgs Empty = new TrackChangedEventArgs();
    }
}
