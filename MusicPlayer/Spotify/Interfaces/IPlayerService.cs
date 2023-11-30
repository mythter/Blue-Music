using Spotify.Data;
using Spotify.Models;

namespace Spotify.Interfaces
{
    public interface IPlayerService
    {
        void Play(List<TrackModel> trackList, int trackIndex);

        void Pause();
    }
}
