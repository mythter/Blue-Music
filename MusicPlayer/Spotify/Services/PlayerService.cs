using Spotify.Data;
using Spotify.Interfaces;
using Spotify.Models;

namespace Spotify.Services
{
    public class PlayerService : IPlayerService
    {
        public event EventHandler<PlayEventArgs>? PlayTrack;

        public event EventHandler? PauseTrack;

        public void Play(List<TrackModel> trackList, int trackIndex)
        {
            var args = new PlayEventArgs(trackList, trackIndex);
            PlayTrack?.Invoke(this, args);
        }

        public void Pause()
        {
            PauseTrack?.Invoke(this, EventArgs.Empty);
        }
    }
}
