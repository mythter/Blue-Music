using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    [Table("playlist_tracks")]
    public class PlaylistTrackModel
    {
        [Key]
        [Column("playlist_id", Order = 0)]
        public Guid PlaylistId { get; set; }

        [Key]
        [Column("track_id", Order = 1)]
        public Guid TrackId { get; set; }

        [ForeignKey("PlaylistId")]
        public PlaylistModel Playlist { get; set; } = null!;

        [ForeignKey("TrackId")]
        public TrackModel Track { get; set; } = null!;
    }
}
