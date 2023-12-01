using Spotify.Interfaces;

namespace Spotify.Data
{
    public class StartTrackEventArgs : EventArgs
    {
        public StartTrackEventArgs()
        {
        }

        public StartTrackEventArgs(ITrackStorable? trackCollection, int trackIndex)
        {
            TrackCollection = trackCollection;
            TrackIndex = trackIndex;
        }

        public ITrackStorable? TrackCollection { get; set; }

        public int TrackIndex { get; set; } = -1;

        public static readonly new StartTrackEventArgs Empty = new StartTrackEventArgs();
    }
}
