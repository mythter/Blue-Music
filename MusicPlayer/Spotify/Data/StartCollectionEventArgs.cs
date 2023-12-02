using Spotify.Interfaces;

namespace Spotify.Data
{
    public class StartCollectionEventArgs : EventArgs
    {
        public StartCollectionEventArgs()
        {
        }

        public StartCollectionEventArgs(ITrackStorable trackCollection)
        {
            TrackCollection = trackCollection;
        }

        public ITrackStorable TrackCollection { get; set; } = null!;

        public static readonly new StartCollectionEventArgs Empty = new StartCollectionEventArgs();
    }
}
