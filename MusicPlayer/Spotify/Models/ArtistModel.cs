using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    [Table("artists")]
    public class ArtistModel
    {
        [Key]
        [Column("artist_id")]
        public Guid Id { get; set; }

        [Column("artist_name")]
        public string Name { get; set; } = null!;

        [Column("artist_image")]
        public byte[]? Image { get; set; }


        public List<AlbumModel> Albums { get; } = new();
    }
}
