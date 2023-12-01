using Spotify.Services;

namespace Spotify.Interfaces
{
    public interface IPlayerService
    {
        event StartEventHandler? StartTrack;

        event PlayPauseEventHandler? PlayTrack;

        event PlayPauseEventHandler? PauseTrack;

        event PlayPauseEventHandler? TrackPaused;

        event PlayPauseEventHandler? TrackPlaying;

        event PlayPauseEventHandler? TrackChanged;

        void Start(ITrackStorable? trackCollection, int trackIndex);

        void Play(Guid collectionId, Guid trackId);

        void Pause(Guid collectionId, Guid trackId);

        public void Playing(Guid collectionId, Guid trackId);

        public void Paused(Guid collectionId, Guid trackId);

        public void Changed(Guid collectionId, Guid trackId);
    }
}
