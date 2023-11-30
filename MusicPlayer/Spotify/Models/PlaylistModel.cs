using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Spotify.Interfaces;

namespace Spotify.Models
{
    [Table("playlists")]
    public class PlaylistModel : ITrackStorable
    {
        [Key]
        [Column("playlist_id")]
        public Guid Id { get; set; }

        [Column("playlist_title")]
        public string Title { get; set; } = null!;

        [Column("playlist_image")]
        public string? Image { get; set; }


        [Column("user_id")]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public UserModel User { get; set; } = null!;


        public List<PlaylistTrackModel> PlaylistTrack { get; } = new();
    }
}
