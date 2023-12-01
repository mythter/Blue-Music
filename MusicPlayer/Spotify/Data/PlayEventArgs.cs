using Spotify.Enums;
using Spotify.Interfaces;
using Spotify.Models;

namespace Spotify.Data
{
    public class PlayEventArgs : EventArgs
    {
        public PlayEventArgs()
        {
        }

        public PlayEventArgs(ITrackStorable? trackCollection, int trackIndex)
        {
            TrackCollection = trackCollection;
            TrackIndex = trackIndex;
        }

        public ITrackStorable? TrackCollection { get; set; }

        public int TrackIndex { get; set; } = -1;

        public static readonly new PlayEventArgs Empty = new PlayEventArgs();
    }
}
