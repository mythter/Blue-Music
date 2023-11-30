using Spotify.Models;

namespace Spotify.Data
{
    public class PlayEventArgs : EventArgs
    {
        public PlayEventArgs(List<TrackModel> trackList, int trackIndex)
        {
            TrackList = trackList;
            TrackIndex = trackIndex;
        }

        public List<TrackModel> TrackList { get; set; }

        public int TrackIndex { get; set; }
    }
}
