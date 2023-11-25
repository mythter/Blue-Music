using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spotify.Models
{
    [Table("tracks")]
    public class TrackModel
    {
        [Key]
        [Column("track_id")]
        public Guid Id { get; set; }

        [Column("track_title")]
        public string Title { get; set; } = null!;

        [Column("track_duration")]
        public int Duration { get; set; }

        [NotMapped]
        public string DurationTime
        {
            get => $"{TimeSpan.FromSeconds(Duration).Minutes}:{TimeSpan.FromSeconds(Duration).Seconds:ss}";
        }

        [Column("track_source")]
        public string? Source { get; set; }


        [Column("track_album_id")]
        public Guid AlbumId { get; set; }

        [ForeignKey("AlbumId")]
        public AlbumModel Album { get; set; } = null!;


        public List<FavoriteModel> Favorite { get; } = new();

        public List<PlaylistTrackModel> PlaylistTrack { get; } = new();

    }
}
