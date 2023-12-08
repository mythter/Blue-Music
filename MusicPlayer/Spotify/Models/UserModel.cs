using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    [Table("users")]
    public class UserModel
    {
        [Key]
        [Column("user_id")]
        public Guid Id { get; set; }

        [Column("user_name")]
        public string Name { get; set; } = null!;

        [Column("user_image")]
        public string? Image { get; set; }

        [Column("user_email")]
        public string? Email { get; set; }

        public List<FavoriteModel> Favorites { get; } = new();

        public List<PlaylistModel> Playlists { get; } = new();
    }
}
