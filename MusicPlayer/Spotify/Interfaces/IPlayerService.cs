using Spotify.Data;
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

        event EventHandler<PlayPauseTrackEventArgs>? TrackPaused;

        event EventHandler<PlayPauseTrackEventArgs>? TrackPlaying;

        event EventHandler<TrackChangedEventArgs>? TrackChanged;

        event EventHandler<PlayStateChangedEventArgs>? PlayStateChanged;

        void Start(ITrackStorable trackCollection, Guid trackId);

        void Start(ITrackStorable trackCollection);

        void Play();

        void Pause();

        void Playing(ITrackStorable trackCollection, Guid trackId);
        
        void Paused(ITrackStorable trackCollection, Guid trackId);
        
        void Changed(Guid collectionId, Guid trackId);

        void StateChanged(Guid collectionId, Guid trackId, bool isPaused);
    }
}
