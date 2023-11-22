using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spotify.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artists",
                columns: table => new
                {
                    artist_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    artist_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    artist_image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artists", x => x.artist_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "albums",
                columns: table => new
                {
                    album_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    albumt_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    album_cover = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    album_release_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    album_artist_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albums", x => x.album_id);
                    table.ForeignKey(
                        name: "FK_albums_artists_album_artist_id",
                        column: x => x.album_artist_id,
                        principalTable: "artists",
                        principalColumn: "artist_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "playlists",
                columns: table => new
                {
                    playlist_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    playlist_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    playlist_image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlists", x => x.playlist_id);
                    table.ForeignKey(
                        name: "FK_playlists_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "tracks",
                columns: table => new
                {
                    track_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    track_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    track_duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    track_source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    track_album_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tracks", x => x.track_id);
                    table.ForeignKey(
                        name: "FK_tracks_albums_track_album_id",
                        column: x => x.track_album_id,
                        principalTable: "albums",
                        principalColumn: "album_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "favorites",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    track_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favorites", x => new { x.user_id, x.track_id });
                    table.ForeignKey(
                        name: "FK_favorites_tracks_track_id",
                        column: x => x.track_id,
                        principalTable: "tracks",
                        principalColumn: "track_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_favorites_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "playlist_tracks",
                columns: table => new
                {
                    playlist_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    track_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlist_tracks", x => new { x.playlist_id, x.track_id });
                    table.ForeignKey(
                        name: "FK_playlist_tracks_playlists_playlist_id",
                        column: x => x.playlist_id,
                        principalTable: "playlists",
                        principalColumn: "playlist_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_playlist_tracks_tracks_track_id",
                        column: x => x.track_id,
                        principalTable: "tracks",
                        principalColumn: "track_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_albums_album_artist_id",
                table: "albums",
                column: "album_artist_id");

            migrationBuilder.CreateIndex(
                name: "IX_favorites_track_id",
                table: "favorites",
                column: "track_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_playlist_tracks_playlist_id",
                table: "playlist_tracks",
                column: "playlist_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_playlist_tracks_track_id",
                table: "playlist_tracks",
                column: "track_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_playlists_user_id",
                table: "playlists",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tracks_track_album_id",
                table: "tracks",
                column: "track_album_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "favorites");

            migrationBuilder.DropTable(
                name: "playlist_tracks");

            migrationBuilder.DropTable(
                name: "playlists");

            migrationBuilder.DropTable(
                name: "tracks");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "albums");

            migrationBuilder.DropTable(
                name: "artists");
        }
    }
}
