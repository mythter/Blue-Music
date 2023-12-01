using Spotify.Data;
using Spotify.Interfaces;

namespace Spotify.Services
{
    public delegate Task StartEventHandler(object sender, StartTrackEventArgs e);

    public delegate void PlayPauseEventHandler(object sender, PlayPauseTrackEventArgs e);

    public class PlayerService : IPlayerService
    {
        public event PlayPauseEventHandler? PlayTrack;

        public event PlayPauseEventHandler? PauseTrack;

        public event PlayPauseEventHandler? TrackPaused;

        public event PlayPauseEventHandler? TrackPlaying;

        public event StartEventHandler? StartTrack;

        public event PlayPauseEventHandler? TrackChanged;

        public void Start(ITrackStorable trackCollection, int trackIndex)
        {
            var args = new StartTrackEventArgs(trackCollection, trackIndex);
            StartTrack?.Invoke(this, args);
        }

        public void Pause(ITrackStorable trackCollection, Guid trackId)
        {
            var args = new PlayPauseTrackEventArgs(trackCollection, trackId);
            PauseTrack?.Invoke(this, args);
            TrackPaused?.Invoke(this, args);
        }

        public void Play(ITrackStorable trackCollection, Guid trackId)
        {
            var args = new PlayPauseTrackEventArgs(trackCollection, trackId);
            PlayTrack?.Invoke(this, args);
            TrackPlaying?.Invoke(this, args);
        }

        public void Paused(ITrackStorable trackCollection, Guid trackId)
        {
            var args = new PlayPauseTrackEventArgs(trackCollection, trackId);
            TrackPaused?.Invoke(this, args);
        }

        public void Playing(ITrackStorable trackCollection, Guid trackId)
        {
            var args = new PlayPauseTrackEventArgs(trackCollection, trackId);
            TrackPlaying?.Invoke(this, args);
        }

        public void Changed(ITrackStorable trackCollection, Guid trackId)
        {
            var args = new PlayPauseTrackEventArgs(trackCollection, trackId);
            TrackChanged?.Invoke(this, args);
        }
    }
}
