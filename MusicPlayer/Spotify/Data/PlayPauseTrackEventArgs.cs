using Spotify.Interfaces;

namespace Spotify.Data
{
    public class PlayPauseTrackEventArgs : EventArgs
    {
        public PlayPauseTrackEventArgs()
        {
        }

        public PlayPauseTrackEventArgs(ITrackStorable trackCollection, Guid trackId)
        {
            TrackCollection = trackCollection;
            TrackId = trackId;
        }

        public ITrackStorable TrackCollection { get; set; } = null!;

        public Guid TrackId { get; set; }

        public static readonly new PlayPauseTrackEventArgs Empty = new PlayPauseTrackEventArgs();
    }
}
