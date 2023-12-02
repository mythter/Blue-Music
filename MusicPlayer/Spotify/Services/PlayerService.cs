using Spotify.Data;
using Spotify.Interfaces;

namespace Spotify.Services
{
    public delegate Task StartTrackEventHandler(object sender, StartTrackEventArgs e);

    public delegate Task StartCollectionEventHandler(object sender, StartCollectionEventArgs e);

    public delegate void PlayPauseEventHandler(object sender, PlayPauseTrackEventArgs e);

    public class PlayerService : IPlayerService
    {
        public event EventHandler? PlayTrack;

        public event EventHandler? PauseTrack;

        public event PlayPauseEventHandler? TrackPaused;

        public event PlayPauseEventHandler? TrackPlaying;

        public event StartTrackEventHandler? StartTrack;

        public event StartCollectionEventHandler? StartCollection;

        public event PlayPauseEventHandler? TrackChanged;

        public void Start(ITrackStorable trackCollection, Guid trackId)
        {
            var args = new StartTrackEventArgs(trackCollection, trackId);
            StartTrack?.Invoke(this, args);
        }

        public void Start(ITrackStorable trackCollection)
        {
            var args = new StartCollectionEventArgs(trackCollection);
            StartCollection?.Invoke(this, args);
        }

        public void Pause()
        {
            PauseTrack?.Invoke(this, EventArgs.Empty);
        }

        public void Play()
        {
            PlayTrack?.Invoke(this, EventArgs.Empty);
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
