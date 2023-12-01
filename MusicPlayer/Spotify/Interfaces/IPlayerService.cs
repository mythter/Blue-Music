using Spotify.Enums;
using Spotify.Services;

namespace Spotify.Interfaces
{
    public interface IPlayerService
    {
        event PlayerEventHandler? StartPlayingTrack;

        event PlayerEventHandler? PlayTrack;

        event PlayerEventHandler? PauseTrack;

        void StartTrack(ITrackStorable? trackCollection, int trackIndex);

        void Play();

        void Pause();
    }
}
