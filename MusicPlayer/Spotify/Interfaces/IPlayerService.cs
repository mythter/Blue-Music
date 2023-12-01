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

        void Start(ITrackStorable trackCollection, int trackIndex);

        void Play(ITrackStorable trackCollection, Guid trackId);

        void Pause(ITrackStorable trackCollection, Guid trackId);

        void Playing(ITrackStorable trackCollection, Guid trackId);
        
        void Paused(ITrackStorable trackCollection, Guid trackId);
        
        void Changed(ITrackStorable trackCollection, Guid trackId);
    }
}
