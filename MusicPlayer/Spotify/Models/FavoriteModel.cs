using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    [Table("favorites")]
    public class FavoriteModel
    {
        [Key]
        [Column("user_id", Order = 0)]
        public Guid UserId { get; set; }

        [Key]
        [Column("track_id", Order = 1)]
        public Guid TrackId { get; set; }

        [ForeignKey("UserId")]
        public UserModel User { get; set; } = null!;

        [ForeignKey("TrackId")]
        public TrackModel Track { get; set; } = null!;
    }
}
