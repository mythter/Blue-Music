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
            get
            {
                int min = TimeSpan.FromSeconds(Duration).Minutes;
                int sec = TimeSpan.FromSeconds(Duration).Seconds;
                return   $"{min}:{sec:d2}";
            }
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
