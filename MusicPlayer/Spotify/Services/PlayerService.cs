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

        public void Start(ITrackStorable? trackCollection, int trackIndex)
        {
            var args = new StartTrackEventArgs(trackCollection, trackIndex);
            StartTrack?.Invoke(this, args);
        }

        public void Pause(Guid collectionId, Guid trackId)
        {
            var args = new PlayPauseTrackEventArgs(collectionId, collectionId);
            PauseTrack?.Invoke(this, args);
            TrackPaused?.Invoke(this, args);
        }

        public void Play(Guid collectionId, Guid trackId)
        {
            var args = new PlayPauseTrackEventArgs(collectionId, collectionId);
            PlayTrack?.Invoke(this, args);
            TrackPlaying?.Invoke(this, args);
        }

        public void Paused(Guid collectionId, Guid trackId)
        {
            var args = new PlayPauseTrackEventArgs(collectionId, trackId);
            TrackPaused?.Invoke(this, args);
        }

        public void Playing(Guid collectionId, Guid trackId)
        {
            var args = new PlayPauseTrackEventArgs(collectionId, trackId);
            TrackPlaying?.Invoke(this, args);
        }

        public void Changed(Guid collectionId, Guid trackId)
        {
            var args = new PlayPauseTrackEventArgs(collectionId, trackId);
            TrackChanged?.Invoke(this, args);
        }
    }
}
