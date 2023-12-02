using Spotify.Services;

namespace Spotify.Interfaces
{
    public interface IPlayerService
    {
        Guid CurrentPlayingTrackId { get; }

        Guid CurrentPlayingCollectionId { get; }

        bool IsPaused { get; }


        event StartTrackEventHandler? StartTrack;

        event StartCollectionEventHandler? StartCollection;

        event EventHandler? PlayTrack;

        event EventHandler? PauseTrack;

        event PlayPauseEventHandler? TrackPaused;

        event PlayPauseEventHandler? TrackPlaying;

        event PlayPauseEventHandler? TrackChanged;

        event PlayStateChangedEventHandler? PlayStateChanged;

        void Start(ITrackStorable trackCollection, Guid trackId);

        void Start(ITrackStorable trackCollection);

        void Play();

        void Pause();

        void Playing(ITrackStorable trackCollection, Guid trackId);
        
        void Paused(ITrackStorable trackCollection, Guid trackId);
        
        void Changed(ITrackStorable trackCollection, Guid trackId);

        void StateChanged(Guid collectionId, Guid trackId, bool isPaused);
    }
}
