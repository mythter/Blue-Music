using Spotify.Interfaces;

namespace Spotify.Data
{
    public class StartTrackEventArgs : EventArgs
    {
        public StartTrackEventArgs()
        {
        }

        public StartTrackEventArgs(ITrackStorable trackCollection, Guid trackId)
        {
            TrackCollection = trackCollection;
            TrackId = trackId;
        }

        public ITrackStorable TrackCollection { get; set; } = null!;

        public Guid TrackId { get; set; }

        public static readonly new StartTrackEventArgs Empty = new StartTrackEventArgs();
    }
}
