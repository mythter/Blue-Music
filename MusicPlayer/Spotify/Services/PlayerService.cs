using Spotify.Data;
using Spotify.Interfaces;

namespace Spotify.Services
{
    public delegate Task StartTrackEventHandler(object sender, StartTrackEventArgs e);

    public delegate Task StartCollectionEventHandler(object sender, StartCollectionEventArgs e);

    public delegate void PlayPauseEventHandler(object sender, PlayPauseTrackEventArgs e);

    public delegate void PlayStateChangedEventHandler(object sender, PlayStateChangedEventArgs e);

    public delegate void TrackChangedEventHandler(object sender, TrackChangedEventArgs e);

    public class PlayerService : IPlayerService
    {
        public Guid CurrentPlayingTrackId { get; private set; }
        public Guid CurrentPlayingCollectionId { get; private set; }
        public bool IsPaused { get; private set; }

        public event EventHandler? PlayTrack;

        public event EventHandler? PauseTrack;

        public event PlayPauseEventHandler? TrackPaused;

        public event PlayPauseEventHandler? TrackPlaying;

        public event StartTrackEventHandler? StartTrack;

        public event StartCollectionEventHandler? StartCollection;

        public event TrackChangedEventHandler? TrackChanged;

        public event PlayStateChangedEventHandler? PlayStateChanged;

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
            var args1 = new PlayPauseTrackEventArgs(trackCollection, trackId);
            TrackPaused?.Invoke(this, args1);

            StateChanged(trackCollection.Id, trackId, true);
        }

        public void Playing(ITrackStorable trackCollection, Guid trackId)
        {
            var args1 = new PlayPauseTrackEventArgs(trackCollection, trackId);
            TrackPlaying?.Invoke(this, args1);

            StateChanged(trackCollection.Id, trackId, false);
        }

        public void Changed(Guid collectionId, Guid trackId)
        {
            CurrentPlayingTrackId = trackId;
            CurrentPlayingCollectionId = collectionId;

            var args = new TrackChangedEventArgs(collectionId, trackId);
            TrackChanged?.Invoke(this, args);
        }

        public void StateChanged(Guid collectionId, Guid trackId, bool isPaused)
        {
            CurrentPlayingTrackId = trackId;
            CurrentPlayingCollectionId = collectionId;
            IsPaused = isPaused;

            var args = new PlayStateChangedEventArgs(collectionId, trackId, isPaused);
            PlayStateChanged?.Invoke(this, args);
        }
    }
}
