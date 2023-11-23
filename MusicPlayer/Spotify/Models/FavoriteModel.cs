using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    [Table("favorites")]
    public class FavoriteModel
    {
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("track_id")]
        public Guid TrackId { get; set; }

        [ForeignKey("UserId")]
        public UserModel User { get; set; } = null!;

        [ForeignKey("TrackId")]
        public TrackModel Track { get; set; } = null!;
    }
}
