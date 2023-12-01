using Spotify.Data;
using Spotify.Interfaces;

namespace Spotify.Services
{
    public delegate Task PlayerEventHandler(object sender, PlayEventArgs e);

    public class PlayerService : IPlayerService
    {
        public event PlayerEventHandler? PlayTrack;

        public event PlayerEventHandler? PauseTrack;

        public event PlayerEventHandler? TrackPaused;

        public event PlayerEventHandler? StartPlayingTrack;

        public void StartTrack(ITrackStorable? trackCollection, int trackIndex)
        {
            var args = new PlayEventArgs(trackCollection, trackIndex);
            StartPlayingTrack?.Invoke(this, args);
        }

        public void Pause()
        {
            PauseTrack?.Invoke(this, PlayEventArgs.Empty);
            TrackPaused?.Invoke(this, PlayEventArgs.Empty);
        }

        public void Play()
        {
            PlayTrack?.Invoke(this, PlayEventArgs.Empty);
        }
    }
}
