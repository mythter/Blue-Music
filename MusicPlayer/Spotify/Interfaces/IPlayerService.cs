using Spotify.Services;

namespace Spotify.Interfaces
{
    public interface IPlayerService
    {
        event StartTrackEventHandler? StartTrack;

        event StartCollectionEventHandler? StartCollection;

        event EventHandler? PlayTrack;

        event EventHandler? PauseTrack;

        event PlayPauseEventHandler? TrackPaused;

        event PlayPauseEventHandler? TrackPlaying;

        event PlayPauseEventHandler? TrackChanged;

        void Start(ITrackStorable trackCollection, Guid trackId);

        void Start(ITrackStorable trackCollection);

        void Play();

        void Pause();

        void Playing(ITrackStorable trackCollection, Guid trackId);
        
        void Paused(ITrackStorable trackCollection, Guid trackId);
        
        void Changed(ITrackStorable trackCollection, Guid trackId);
    }
}
