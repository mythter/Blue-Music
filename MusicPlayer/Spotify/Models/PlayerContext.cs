using Microsoft.EntityFrameworkCore;

namespace Spotify.Models
{
    public class PlayerContext : DbContext
    {
        DbSet<ArtistModel> Artists { get; set; } = null!;
        DbSet<AlbumModel> Albums { get; set; } = null!;
        DbSet<TrackModel> Tracks { get; set; } = null!;
        DbSet<PlaylistModel> Playlists { get; set; } = null!;
        DbSet<FavoriteModel> Favorites { get; set; } = null!;
        DbSet<PlaylistTrackModel> PlaylistTracks { get; set; } = null!;
        DbSet<UserModel> Usres { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = builder.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
