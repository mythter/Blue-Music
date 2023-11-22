using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    [Table("playlists")]
    public class PlaylistModel
    {
        [Key]
        [Column("playlist_id")]
        public Guid Id { get; set; }

        [Column("playlist_title")]
        public string Title { get; set; } = null!;

        [Column("playlist_image")]
        public byte[]? Image { get; set; }


        [Column("user_id")]
        public Guid? UserId { get; set; }

        [ForeignKey("UserId")]
        public UserModel? User { get; set; }


        public PlaylistTrackModel? PlaylistTrack { get; set; }
    }
}
