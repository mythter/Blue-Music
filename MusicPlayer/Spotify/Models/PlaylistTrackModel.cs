using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    [Table("playlist_tracks")]
    public class PlaylistTrackModel
    {
        [Column("playlist_id")]
        public Guid PlaylistId { get; set; }

        [Column("track_id")]
        public Guid TrackId { get; set; }

        [ForeignKey("PlaylistId")]
        public PlaylistModel Playlist { get; set; } = null!;

        [ForeignKey("TrackId")]
        public TrackModel Track { get; set; } = null!;
    }
}
