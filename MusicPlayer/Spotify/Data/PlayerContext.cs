using Microsoft.EntityFrameworkCore;
using Spotify.Data;
using Spotify.Data.Images;

namespace Spotify.Models
{
    public class PlayerContext : DbContext
    {
        public DbSet<ArtistModel> Artists { get; set; } = null!;
        public DbSet<AlbumModel> Albums { get; set; } = null!;
        public DbSet<TrackModel> Tracks { get; set; } = null!;
        public DbSet<PlaylistModel> Playlists { get; set; } = null!;
        public DbSet<FavoriteModel> Favorites { get; set; } = null!;
        public DbSet<PlaylistTrackModel> PlaylistTracks { get; set; } = null!;
        public DbSet<UserModel> Users { get; set; } = null!;

        public PlayerContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = builder.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavoriteModel>()
                .HasKey(f => new { f.UserId, f.TrackId });

            modelBuilder.Entity<PlaylistTrackModel>()
                .HasKey(p => new { p.PlaylistId, p.TrackId });

            // Database initialization
            // =============================================================================================

            ArtistModel KomodoArtist = new()
            {
                Id = Guid.NewGuid(),
                Name = "Komodo",
            };

            ArtistModel TheSeigeArtist = new()
            {
                Id = Guid.NewGuid(),
                Name = "The Seige",
            };

            ArtistModel QueenArtist = new()
            {
                Id = Guid.NewGuid(),
                Name = "Queen",
            };

            ArtistModel OkeanElzyArtist = new()
            {
                Id = Guid.NewGuid(),
                Name = "Okean Elzy",
            };

            ArtistModel MacQuayleArtist = new()
            {
                Id = Guid.NewGuid(),
                Name = "Mac Quayle",
            };

            ArtistModel PinsArtist = new()
            {
                Id = Guid.NewGuid(),
                Name = "PINS",
            };

            ArtistModel ForeignAirArtist = new()
            {
                Id = Guid.NewGuid(),
                Name = "Foreign Air",
            };

            ArtistModel TheWeekndArtist = new()
            {
                Id = Guid.NewGuid(),
                Name = "The Weeknd",
            };

            ArtistModel LedZeppelinArtist = new()
            {
                Id = Guid.NewGuid(),
                Name = "Led Zeppelin",
            };

            ArtistModel PinkFloydArtist = new()
            {
                Id = Guid.NewGuid(),
                Name = "Pink Floyd",
            };

            ArtistModel ACDCArtist = new()
            {
                Id = Guid.NewGuid(),
                Name = "AC/DC",
            };

            ArtistModel TheAnimalsArtist = new()
            {
                Id = Guid.NewGuid(),
                Name = "The Animals",
            };

            ArtistModel TheBlackKeysArtist = new()
            {
                Id = Guid.NewGuid(),
                Name = "The Black Keys",
            };

            ArtistModel MichaelJacksonArtist = new()
            {
                Id = Guid.NewGuid(),
                Name = "Michael Jackson",
            };

            ArtistModel TheScoreArtist = new()
            {
                Id = Guid.NewGuid(),
                Name = "The Score",
            };

            ArtistModel TheZealotsArtist = new()
            {
                Id = Guid.NewGuid(),
                Name = "The Zealots",
            };

            // =============================================================================================

            AlbumModel LedZeppelinIIIAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = LedZeppelinArtist.Id,
                Image = AlbumCovers.LedZeppelinIII,
                Title = "Led Zeppelin III",
            };

            AlbumModel TheDarkSideOfTheMoonAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = PinkFloydArtist.Id,
                Image = AlbumCovers.TheDarkSideOfTheMoon,
                Title = "The Dark Side Of The Moon",
                ReleaseDate = new DateTime(1973, 03, 01),
            };

            AlbumModel NewsOfTheWorldAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = QueenArtist.Id,
                Image = AlbumCovers.NewsOfTheWorld,
                Title = "News Of The World",
                ReleaseDate = new DateTime(1977, 10, 28),
            };

            AlbumModel BackInBlackAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = ACDCArtist.Id,
                Image = AlbumCovers.BackInBlack,
                Title = "Back In Black",
                ReleaseDate = new DateTime(1980, 07, 25),
            };

            AlbumModel TheSinglesPlusAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = TheAnimalsArtist.Id,
                Image = AlbumCovers.TheSinglesPlus,
                Title = "The Singles Plus",
                ReleaseDate = new DateTime(1987, 10, 19),
            };

            AlbumModel TheDivisionBellAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = PinkFloydArtist.Id,
                Image = AlbumCovers.TheDivisionBell,
                Title = "The Division Bell",
                ReleaseDate = new DateTime(1994, 03, 28),
            };

            AlbumModel BrothersAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = TheBlackKeysArtist.Id,
                Image = AlbumCovers.Brothers,
                Title = "Brothers",
                ReleaseDate = new DateTime(2010, 05, 18),
            };

            AlbumModel ElCaminoAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = TheBlackKeysArtist.Id,
                Image = AlbumCovers.ElCamino,
                Title = "El Camino",
                ReleaseDate = new DateTime(2011, 12, 06),
            };

            AlbumModel OffTheWallAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = MichaelJacksonArtist.Id,
                Image = AlbumCovers.OffTheWall,
                Title = "Off the Wall",
                ReleaseDate = new DateTime(1979, 08, 10),
            };

            AlbumModel ThrillerAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = MichaelJacksonArtist.Id,
                Image = AlbumCovers.Thriller,
                Title = "Thriller",
                ReleaseDate = new DateTime(1982, 11, 30),
            };

            AlbumModel BadAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = MichaelJacksonArtist.Id,
                Image = AlbumCovers.Bad,
                Title = "Bad",
                ReleaseDate = new DateTime(1987, 08, 31),
            };

            AlbumModel DangerousAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = MichaelJacksonArtist.Id,
                Image = AlbumCovers.Dangerous,
                Title = "Dangerous",
                ReleaseDate = new DateTime(1991, 11, 13),
            };

            AlbumModel HistoryAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = MichaelJacksonArtist.Id,
                Image = AlbumCovers.History,
                Title = "HIStory - PAST, PRESENT AND FUTURE - BOOK I",
                ReleaseDate = new DateTime(1995, 06, 16),
            };

            AlbumModel BloodOnTheDanceFloorAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = MichaelJacksonArtist.Id,
                Image = AlbumCovers.BloodOnTheDanceFloor,
                Title = "BLOOD ON THE DANCE FLOOR",
                ReleaseDate = new DateTime(1997, 05, 11),
            };

            AlbumModel InvincibleAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = MichaelJacksonArtist.Id,
                Image = AlbumCovers.Invincible,
                Title = "Invincible",
                ReleaseDate = new DateTime(2001, 10, 29),
            };

            AlbumModel MythsAndLegendsAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = TheScoreArtist.Id,
                Image = AlbumCovers.MythsAndLegends,
                Title = "Myths & Legends",
                ReleaseDate = new DateTime(2017, 04, 14),
            };

            AlbumModel OnlyRocksLiveForeverAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = TheZealotsArtist.Id,
                Image = AlbumCovers.OnlyRocksLiveForever,
                Title = "Only Rocks Live Forever",
                ReleaseDate = new DateTime(2018, 06, 01),
            };

            AlbumModel InnuendoAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = QueenArtist.Id,
                Image = AlbumCovers.Innuendo,
                Title = "Innuendo",
                ReleaseDate = new DateTime(1991, 02, 05),
            };

            AlbumModel DolceVitaAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = OkeanElzyArtist.Id,
                Image = AlbumCovers.DolceVita,
                Title = "Dolce vita",
                ReleaseDate = new DateTime(2010, 03, 10),
            };

            AlbumModel MrRobotVol1Album = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = MacQuayleArtist.Id,
                Image = AlbumCovers.MrRobotVol1,
                Title = "Mr. Robot, Vol. 1",
                ReleaseDate = new DateTime(2016, 06, 03),
            };

            AlbumModel TroubleAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = PinsArtist.Id,
                Image = AlbumCovers.Trouble,
                Title = "Trouble",
                ReleaseDate = new DateTime(2016, 06, 17),
            };

            AlbumModel ForTheLightAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = ForeignAirArtist.Id,
                Image = AlbumCovers.ForTheLight,
                Title = "For the Light",
                ReleaseDate = new DateTime(2016, 09, 23),
            };

            AlbumModel AggrophobeAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = PinsArtist.Id,
                Image = AlbumCovers.Aggrophobe,
                Title = "Aggrophobe",
                ReleaseDate = new DateTime(2017, 01, 26),
            };

            AlbumModel DualityAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = TheSeigeArtist.Id,
                Image = AlbumCovers.Duality,
                Title = "Duality",
                ReleaseDate = new DateTime(2019, 01, 10),
            };

            AlbumModel KomodoAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = KomodoArtist.Id,
                Image = AlbumCovers.Komodo,
                Title = "Komodo",
                ReleaseDate = new DateTime(2019, 02, 22),
            };

            AlbumModel YourTouchAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = QueenArtist.Id,
                Image = AlbumCovers.YourTouch,
                Title = "Your Touch",
                ReleaseDate = new DateTime(2021, 08, 06),
            };

            AlbumModel DawnFMAlbum = new()
            {
                Id = Guid.NewGuid(),
                ArtistId = TheWeekndArtist.Id,
                Image = AlbumCovers.DawnFM,
                Title = "Dawn FM",
                ReleaseDate = new DateTime(2022, 01, 06),
            };

            // =============================================================================================

            TrackModel HeadlongTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = InnuendoAlbum.Id,
                Title = "Headlong",
                Duration = 278,
                Source = @"assets/audio/Headlong - Remastered 2011.mp3",
            };

            TrackModel IReallyWantTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = DolceVitaAlbum.Id,
                Title = "Я так хочу...",
                Duration = 282,
                Source = @"assets/audio/Я так хочу....mp3",
            };

            TrackModel Da3m0nsneverstopTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = MrRobotVol1Album.Id,
                Title = "1.3_5-da3m0nsneverstop.caf",
                Duration = 130,
                Source = @"assets/audio/1.3_5-da3m0nsneverstop.caf.mp3",
            };

            TrackModel TroubleTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = TroubleAlbum.Id,
                Title = "Trouble",
                Duration = 258,
                Source = @"assets/audio/Trouble.mp3",
            };

            TrackModel FreeAnimalTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = ForTheLightAlbum.Id,
                Title = "Free Animal",
                Duration = 180,
                Source = @"assets/audio/Free Animal.mp3",
            };

            TrackModel Aggrophobe = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = AggrophobeAlbum.Id,
                Title = "Aggrophobe",
                Duration = 204,
                Source = @"assets/audio/Aggrophobe.mp3",
            };

            TrackModel FindMeTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = DualityAlbum.Id,
                Title = "Find Me",
                Duration = 204,
                Source = @"assets/audio/Find Me.mp3",
            };

            TrackModel DevilsShortHandTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = KomodoAlbum.Id,
                Title = "Devil's Short Hand",
                Duration = 222,
                Source = @"assets/audio/Devil's Short Hand.mp3",
            };

            TrackModel YourTouchTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = YourTouchAlbum.Id,
                Title = "Your Touch",
                Duration = 225,
                Source = @"assets/audio/Your Touch.mp3",
            };

            TrackModel SacrificeTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = DawnFMAlbum.Id,
                Title = "Sacrifice",
                Duration = 189,
                Source = @"assets/audio/Sacrifice.mp3",
            };

            TrackModel HigherTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = MythsAndLegendsAlbum.Id,
                Title = "Higher",
                Duration = 215,
                Source = @"assets/audio/Higher.mp3",
            };

            TrackModel LegendTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = MythsAndLegendsAlbum.Id,
                Title = "Legend",
                Duration = 189,
                Source = @"assets/audio/Legend.mp3",
            };

            TrackModel MiracleTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = MythsAndLegendsAlbum.Id,
                Title = "Miracle",
                Duration = 206,
                Source = @"assets/audio/Miracle.mp3",
            };

            TrackModel RevolutionTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = MythsAndLegendsAlbum.Id,
                Title = "Revolution",
                Duration = 232,
                Source = @"assets/audio/Revolution.mp3",
            };

            TrackModel AlabamaGentlemenTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = OnlyRocksLiveForeverAlbum.Id,
                Title = "Alabama Gentlemen",
                Duration = 205,
                Source = @"assets/audio/Alabama Gentlemen.mp3",
            };

            TrackModel BrandNewKicksTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = OnlyRocksLiveForeverAlbum.Id,
                Title = "Brand New Kicks",
                Duration = 156,
                Source = @"assets/audio/Brand New Kicks.mp3",
            };

            TrackModel CaughtUpTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = OnlyRocksLiveForeverAlbum.Id,
                Title = "Caught Up",
                Duration = 169,
                Source = @"assets/audio/Caught Up.mp3",
            };

            TrackModel MedicineManTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = OnlyRocksLiveForeverAlbum.Id,
                Title = "Medicine Man",
                Duration = 215,
                Source = @"assets/audio/Medicine Man.mp3",
            };

            TrackModel OnlyRocksLiveForeverTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = OnlyRocksLiveForeverAlbum.Id,
                Title = "Only Rocks Live Forever",
                Duration = 264,
                Source = @"assets/audio/Only Rocks Live Forever.mp3",
            };

            TrackModel SledgeTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = OnlyRocksLiveForeverAlbum.Id,
                Title = "Sledge",
                Duration = 225,
                Source = @"assets/audio/Sledge.mp3",
            };

            TrackModel SupernovaTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = OnlyRocksLiveForeverAlbum.Id,
                Title = "Supernova",
                Duration = 201,
                Source = @"assets/audio/Supernova.mp3",
            };

            TrackModel SweetMississippiTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = OnlyRocksLiveForeverAlbum.Id,
                Title = "Sweet Mississippi",
                Duration = 202,
                Source = @"assets/audio/Sweet Mississippi.mp3",
            };

            TrackModel TangerineDreamsTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = OnlyRocksLiveForeverAlbum.Id,
                Title = "Tangerine Dreams",
                Duration = 140,
                Source = @"assets/audio/Tangerine Dreams.mp3",
            };

            TrackModel TequilaMockingbirdTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = OnlyRocksLiveForeverAlbum.Id,
                Title = "Tequila Mockingbird",
                Duration = 226,
                Source = @"assets/audio/Tequila Mockingbird.mp3",
            };

            TrackModel BadTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = BadAlbum.Id,
                Title = "Bad",
                Duration = 247,
                Source = @"assets/audio/Bad.mp3",
            };

            TrackModel BeatItTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = ThrillerAlbum.Id,
                Title = "Beat It",
                Duration = 258,
                Source = @"assets/audio/Beat It.mp3",
            };

            TrackModel BillieJeanTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = ThrillerAlbum.Id,
                Title = "Billie Jean",
                Duration = 294,
                Source = @"assets/audio/Billie Jean.mp3",
            };

            TrackModel DirtyDianaTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = BadAlbum.Id,
                Title = "Dirty Diana",
                Duration = 281,
                Source = @"assets/audio/Dirty Diana.mp3",
            };

            TrackModel BloodOnTheDanceFloorTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = BloodOnTheDanceFloorAlbum.Id,
                Title = "Blood on the Dance Floor",
                Duration = 253,
                Source = @"assets/audio/Blood on the Dance Floor.mp3",
            };

            TrackModel DontStopTilYouGetEnoughTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = OffTheWallAlbum.Id,
                Title = "Don't Stop 'Til You Get Enough",
                Duration = 365,
                Source = @"assets/audio/Don't Stop 'Til You Get Enough.mp3",
            };

            TrackModel GiveInToMeTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = DangerousAlbum.Id,
                Title = "Give In to Me",
                Duration = 329,
                Source = @"assets/audio/Give In to Me.mp3",
            };

            TrackModel MorphineTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = BloodOnTheDanceFloorAlbum.Id,
                Title = "Morphine",
                Duration = 388,
                Source = @"assets/audio/Morphine.mp3",
            };

            TrackModel PrivacyTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = InvincibleAlbum.Id,
                Title = "Privacy",
                Duration = 304,
                Source = @"assets/audio/Privacy.mp3",
            };

            TrackModel SmoothCriminalTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = BadAlbum.Id,
                Title = "Smooth Criminal",
                Duration = 258,
                Source = @"assets/audio/Smooth Criminal.mp3",
            };

            TrackModel SuperflySisterTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = BloodOnTheDanceFloorAlbum.Id,
                Title = "Superfly Sister",
                Duration = 387,
                Source = @"assets/audio/Superfly Sister.mp3",
            };

            TrackModel ComeTogetherTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = HistoryAlbum.Id,
                Title = "Come Together",
                Duration = 242,
                Source = @"assets/audio/Come Together.mp3",
            };

            TrackModel TheyDontCareAboutUsTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = HistoryAlbum.Id,
                Title = "They Don't Care About Us",
                Duration = 284,
                Source = @"assets/audio/They Don't Care About Us.mp3",
            };

            TrackModel ThisTimeAroundTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = HistoryAlbum.Id,
                Title = "This Time Around",
                Duration = 261,
                Source = @"assets/audio/This Time Around.mp3",
            };

            TrackModel BackInBlackTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = BackInBlackAlbum.Id,
                Title = "Back In Black",
                Duration = 256,
                Source = @"assets/audio/Back In Black.mp3",
            };

            TrackModel GoldOnTheCeilingTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = ElCaminoAlbum.Id,
                Title = "Gold on the Ceiling",
                Duration = 224,
                Source = @"assets/audio/Gold on the Ceiling.mp3",
            };

            TrackModel HellsBellsTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = BackInBlackAlbum.Id,
                Title = "Hells Bells",
                Duration = 312,
                Source = @"assets/audio/Hells Bells.mp3",
            };

            TrackModel HouseOfTheRisingSunTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = TheSinglesPlusAlbum.Id,
                Title = "House of the Rising Sun",
                Duration = 270,
                Source = @"assets/audio/House of the Rising Sun.mp3",
            };

            TrackModel ImmigrantSongTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = LedZeppelinIIIAlbum.Id,
                Title = "Immigrant Song",
                Duration = 146,
                Source = @"assets/audio/Immigrant Song.mp3",
            };

            TrackModel LonelyBoyTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = ElCaminoAlbum.Id,
                Title = "Lonely Boy",
                Duration = 194,
                Source = @"assets/audio/Lonely Boy.mp3",
            };

            TrackModel MaroonedTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = TheDivisionBellAlbum.Id,
                Title = "Marooned",
                Duration = 330,
                Source = @"assets/audio/Marooned.mp3",
            };

            TrackModel MoneyTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = TheDarkSideOfTheMoonAlbum.Id,
                Title = "Money",
                Duration = 383,
                Source = @"assets/audio/Money.mp3",
            };

            TrackModel TightenUpTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = BrothersAlbum.Id,
                Title = "Tighten Up",
                Duration = 214,
                Source = @"assets/audio/Tighten Up.mp3",
            };

            TrackModel WeWillRockYouTrack = new()
            {
                Id = Guid.NewGuid(),
                AlbumId = NewsOfTheWorldAlbum.Id,
                Title = "We Will Rock You",
                Duration = 122,
                Source = @"assets/audio/We Will Rock You.mp3",
            };

            // =============================================================================================

            UserModel ArkadiyUser = new()
            {
                Id = Guid.NewGuid(),
                Name = "Arkadiy",
            };

            UserModel VeselchakUser = new()
            {
                Id = Guid.NewGuid(),
                Name = "Veselchak",
            };

            UserModel KabanUser = new()
            {
                Id = Guid.NewGuid(),
                Name = "Kaban",
            };

            // =============================================================================================

            PlaylistModel RockPlaylist = new()
            {
                Id = Guid.NewGuid(),
                UserId = KabanUser.Id,
                Title = "Rock Playlist",
            };

            PlaylistModel MichaelJacksonPlaylist = new()
            {
                Id = Guid.NewGuid(),
                UserId = ArkadiyUser.Id,
                Title = "Michael Jackson Playlist",
                Image = PlaylistImages.MichaelJackson,
            };

            // =============================================================================================

            PlaylistTrackModel MichaelJacksonPlaylist1 = new()
            {
                PlaylistId = MichaelJacksonPlaylist.Id,
                TrackId = BadTrack.Id,
            };

            PlaylistTrackModel MichaelJacksonPlaylist2 = new()
            {
                PlaylistId = MichaelJacksonPlaylist.Id,
                TrackId = BeatItTrack.Id,
            };

            PlaylistTrackModel MichaelJacksonPlaylist3 = new()
            {
                PlaylistId = MichaelJacksonPlaylist.Id,
                TrackId = BillieJeanTrack.Id,
            };

            PlaylistTrackModel MichaelJacksonPlaylist4 = new()
            {
                PlaylistId = MichaelJacksonPlaylist.Id,
                TrackId = BloodOnTheDanceFloorTrack.Id,
            };

            PlaylistTrackModel MichaelJacksonPlaylist5 = new()
            {
                PlaylistId = MichaelJacksonPlaylist.Id,
                TrackId = DirtyDianaTrack.Id,
            };

            PlaylistTrackModel MichaelJacksonPlaylist6 = new()
            {
                PlaylistId = MichaelJacksonPlaylist.Id,
                TrackId = DontStopTilYouGetEnoughTrack.Id,
            };

            PlaylistTrackModel MichaelJacksonPlaylist7 = new()
            {
                PlaylistId = MichaelJacksonPlaylist.Id,
                TrackId = GiveInToMeTrack.Id,
            };

            PlaylistTrackModel MichaelJacksonPlaylist8 = new()
            {
                PlaylistId = MichaelJacksonPlaylist.Id,
                TrackId = MorphineTrack.Id,
            };

            PlaylistTrackModel MichaelJacksonPlaylist9 = new()
            {
                PlaylistId = MichaelJacksonPlaylist.Id,
                TrackId = PrivacyTrack.Id,
            };

            PlaylistTrackModel MichaelJacksonPlaylist10 = new()
            {
                PlaylistId = MichaelJacksonPlaylist.Id,
                TrackId = SmoothCriminalTrack.Id,
            };

            PlaylistTrackModel MichaelJacksonPlaylist11 = new()
            {
                PlaylistId = MichaelJacksonPlaylist.Id,
                TrackId = SuperflySisterTrack.Id,
            };

            PlaylistTrackModel MichaelJacksonPlaylist12 = new()
            {
                PlaylistId = MichaelJacksonPlaylist.Id,
                TrackId = ComeTogetherTrack.Id,
            };

            PlaylistTrackModel MichaelJacksonPlaylist13 = new()
            {
                PlaylistId = MichaelJacksonPlaylist.Id,
                TrackId = TheyDontCareAboutUsTrack.Id,
            };

            PlaylistTrackModel MichaelJacksonPlaylist14 = new()
            {
                PlaylistId = MichaelJacksonPlaylist.Id,
                TrackId = ThisTimeAroundTrack.Id,
            };

            // ==========

            PlaylistTrackModel RockPlaylist1 = new()
            {
                PlaylistId = RockPlaylist.Id,
                TrackId = BackInBlackTrack.Id,
            };

            PlaylistTrackModel RockPlaylist2 = new()
            {
                PlaylistId = RockPlaylist.Id,
                TrackId = GoldOnTheCeilingTrack.Id,
            };

            PlaylistTrackModel RockPlaylist3 = new()
            {
                PlaylistId = RockPlaylist.Id,
                TrackId = HellsBellsTrack.Id,
            };

            PlaylistTrackModel RockPlaylist4 = new()
            {
                PlaylistId = RockPlaylist.Id,
                TrackId = HouseOfTheRisingSunTrack.Id,
            };

            PlaylistTrackModel RockPlaylist5 = new()
            {
                PlaylistId = RockPlaylist.Id,
                TrackId = ImmigrantSongTrack.Id,
            };

            PlaylistTrackModel RockPlaylist6 = new()
            {
                PlaylistId = RockPlaylist.Id,
                TrackId = LonelyBoyTrack.Id,
            };

            PlaylistTrackModel RockPlaylist7 = new()
            {
                PlaylistId = RockPlaylist.Id,
                TrackId = MaroonedTrack.Id,
            };

            PlaylistTrackModel RockPlaylist8 = new()
            {
                PlaylistId = RockPlaylist.Id,
                TrackId = MoneyTrack.Id,
            };

            PlaylistTrackModel RockPlaylist9 = new()
            {
                PlaylistId = RockPlaylist.Id,
                TrackId = TightenUpTrack.Id,
            };

            PlaylistTrackModel RockPlaylist10 = new()
            {
                PlaylistId = RockPlaylist.Id,
                TrackId = WeWillRockYouTrack.Id,
            };

            // =============================================================================================

            FavoriteModel KabanFavorite1 = new()
            {
                UserId = KabanUser.Id,
                TrackId = TroubleTrack.Id,
            };

            // ==========

            FavoriteModel ArkadiyFavorite1 = new()
            {
                UserId = ArkadiyUser.Id,
                TrackId = BloodOnTheDanceFloorTrack.Id,
            };

            FavoriteModel ArkadiyFavorite2 = new()
            {
                UserId = ArkadiyUser.Id,
                TrackId = BillieJeanTrack.Id,
            };

            FavoriteModel ArkadiyFavorite3 = new()
            {
                UserId = ArkadiyUser.Id,
                TrackId = FreeAnimalTrack.Id,
            };

            // ==========

            FavoriteModel VeselchakFavorite1 = new()
            {
                UserId = VeselchakUser.Id,
                TrackId = SledgeTrack.Id,
            };

            FavoriteModel VeselchakFavorite2 = new()
            {
                UserId = VeselchakUser.Id,
                TrackId = MaroonedTrack.Id,
            };

            FavoriteModel VeselchakFavorite3 = new()
            {
                UserId = VeselchakUser.Id,
                TrackId = HellsBellsTrack.Id,
            };

            FavoriteModel VeselchakFavorite4 = new()
            {
                UserId = VeselchakUser.Id,
                TrackId = TightenUpTrack.Id,
            };

            FavoriteModel VeselchakFavorite5 = new()
            {
                UserId = VeselchakUser.Id,
                TrackId = DirtyDianaTrack.Id,
            };

            // =============================================================================================

            modelBuilder.Entity<ArtistModel>().HasData(
                KomodoArtist,
                TheSeigeArtist,
                QueenArtist,
                OkeanElzyArtist,
                MacQuayleArtist,
                PinsArtist,
                ForeignAirArtist,
                TheWeekndArtist,
                LedZeppelinArtist,
                PinkFloydArtist,
                ACDCArtist,
                TheAnimalsArtist,
                TheBlackKeysArtist,
                MichaelJacksonArtist,
                TheScoreArtist,
                TheZealotsArtist
                );

            modelBuilder.Entity<AlbumModel>().HasData(
                LedZeppelinIIIAlbum,
                TheDarkSideOfTheMoonAlbum,
                NewsOfTheWorldAlbum,
                BackInBlackAlbum,
                TheSinglesPlusAlbum,
                TheDivisionBellAlbum,
                BrothersAlbum,
                ElCaminoAlbum,
                OffTheWallAlbum,
                ThrillerAlbum,
                BadAlbum,
                DangerousAlbum,
                HistoryAlbum,
                BloodOnTheDanceFloorAlbum,
                InvincibleAlbum,
                MythsAndLegendsAlbum,
                OnlyRocksLiveForeverAlbum,
                InnuendoAlbum,
                DolceVitaAlbum,
                MrRobotVol1Album,
                TroubleAlbum,
                ForTheLightAlbum,
                AggrophobeAlbum,
                DualityAlbum,
                KomodoAlbum,
                YourTouchAlbum,
                DawnFMAlbum
                );

            modelBuilder.Entity<TrackModel>().HasData(
                HeadlongTrack,
                IReallyWantTrack,
                Da3m0nsneverstopTrack,
                TroubleTrack,
                FreeAnimalTrack,
                Aggrophobe,
                FindMeTrack,
                DevilsShortHandTrack,
                YourTouchTrack,
                SacrificeTrack,
                HigherTrack,
                LegendTrack,
                MiracleTrack,
                RevolutionTrack,
                AlabamaGentlemenTrack,
                BrandNewKicksTrack,
                CaughtUpTrack,
                MedicineManTrack,
                OnlyRocksLiveForeverTrack,
                SledgeTrack,
                SupernovaTrack,
                SweetMississippiTrack,
                TangerineDreamsTrack,
                TequilaMockingbirdTrack,
                BadTrack,
                BeatItTrack,
                BillieJeanTrack,
                DirtyDianaTrack,
                BloodOnTheDanceFloorTrack,
                DontStopTilYouGetEnoughTrack,
                GiveInToMeTrack,
                MorphineTrack,
                PrivacyTrack,
                SmoothCriminalTrack,
                SuperflySisterTrack,
                ComeTogetherTrack,
                TheyDontCareAboutUsTrack,
                ThisTimeAroundTrack,
                BackInBlackTrack,
                GoldOnTheCeilingTrack,
                HellsBellsTrack,
                HouseOfTheRisingSunTrack,
                ImmigrantSongTrack,
                LonelyBoyTrack,
                MaroonedTrack,
                MoneyTrack,
                TightenUpTrack,
                WeWillRockYouTrack
                );

            modelBuilder.Entity<UserModel>().HasData(
                ArkadiyUser,
                VeselchakUser,
                KabanUser
                );

            modelBuilder.Entity<PlaylistModel>().HasData(
                RockPlaylist,
                MichaelJacksonPlaylist
                );

            modelBuilder.Entity<PlaylistTrackModel>().HasData(
                MichaelJacksonPlaylist1,
                MichaelJacksonPlaylist2,
                MichaelJacksonPlaylist3,
                MichaelJacksonPlaylist4,
                MichaelJacksonPlaylist5,
                MichaelJacksonPlaylist6,
                MichaelJacksonPlaylist7,
                MichaelJacksonPlaylist8,
                MichaelJacksonPlaylist9,
                MichaelJacksonPlaylist10,
                MichaelJacksonPlaylist11,
                MichaelJacksonPlaylist12,
                MichaelJacksonPlaylist13,
                MichaelJacksonPlaylist14,

                RockPlaylist1,
                RockPlaylist2,
                RockPlaylist3,
                RockPlaylist4,
                RockPlaylist5,
                RockPlaylist6,
                RockPlaylist7,
                RockPlaylist8,
                RockPlaylist9,
                RockPlaylist10
                );

            modelBuilder.Entity<FavoriteModel>().HasData(
                KabanFavorite1,
                ArkadiyFavorite1,
                ArkadiyFavorite2,
                ArkadiyFavorite3,
                VeselchakFavorite1,
                VeselchakFavorite2,
                VeselchakFavorite3,
                VeselchakFavorite4,
                VeselchakFavorite5
                );
        }
    }
}
