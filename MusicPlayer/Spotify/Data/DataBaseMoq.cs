using Spotify.Models;

namespace Spotify.Data
{
    public static class DataBaseMoq
    {
        public static List<TrackModel> Tracks { get; set; }
        public static List<PlaylistModel> Playlists { get; set; }

        static DataBaseMoq()
        {
            Tracks = new List<TrackModel>()
            {
               new TrackModel()
               {
                   Id = Guid.NewGuid(),
                   Title = "Dr Manhattan",
                   Author =  "Dr Manhattan",
                   Image = "https://i.scdn.co/image/ab67616d0000b27386a8061cdf26909ce5a31c0c",
                   Source = "Find me.mp3",

               },
               new TrackModel()
               {
                   Id = Guid.NewGuid(),
                   Title = "Fight Or Flight",
                   Author = "Hoobastank",
                   Image = "https://i.scdn.co/image/ab67616d0000b273f2d4e8964965b4330ddc258f",
                   Source = "Find me.mp3",

               },
               new TrackModel()
               {
                   Id = Guid.NewGuid(),
                   Title = "Echoes, Silence, Patience & Grace",
                   Author = "Foo Fighters",
                   Image = "https://i.scdn.co/image/ab67616d0000b27383e260c313dc1ff1f17909cf",
                   Source = "Find me.mp3",

               }
            };

            Playlists = new List<PlaylistModel>()
            {
               new PlaylistModel()
               {
                   Id = Guid.NewGuid(),
                   Title = "Playlist 1",
                   Author =  "Kapusta",
                   Image = "https://i.scdn.co/image/ab67616d0000b27386a8061cdf26909ce5a31c0c"
               },
               new PlaylistModel()
               {
                   Id = Guid.NewGuid(),
                   Title = "Playlist 2",
                   Author = "Ogurec",
                   Image = "https://i.scdn.co/image/ab67616d0000b273f2d4e8964965b4330ddc258f"
               },
               new PlaylistModel()
               {
                   Id = Guid.NewGuid(),
                   Title = "Playlist 3",
                   Author = "Kaban",
                   Image = "https://i.scdn.co/image/ab67616d0000b27383e260c313dc1ff1f17909cf"
               }
            };

        }
    }
}