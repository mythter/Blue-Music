using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    [Table("albums")]
    public class AlbumModel : ITrackCollection
    {
        [Key]
        [Column("album_id")]
        public Guid Id { get; set; }

        [Column("albumt_title")]
        public string Title { get; set; } = null!;

        [Column("album_cover")]
        public string? Cover { get; set; }

        [Column("album_release_date")]
        public DateTime? ReleaseDate { get; set; }


        [Column("album_artist_id")]
        public Guid ArtistId { get; set; }

        [ForeignKey("ArtistId")]
        public ArtistModel Artist { get; set; } = null!;


        public List<TrackModel> Tracks { get; } = new();
    }
}
