using Spotify.Data.Models;

namespace Spotify.Data
{
    public static class DataBaseMoq
    {
        public static List<TrackModel> Tracks { get; set; }

        static DataBaseMoq()
        {
            Tracks = new List<TrackModel>()
            {
               new TrackModel()
               {
                   Id = Guid.NewGuid(),
                   Title = "Dr Manhattan",
                   Author =  "Dr Manhattan",
                   Image = "https://i.scdn.co/image/ab67616d0000b27386a8061cdf26909ce5a31c0c"
               },
               new TrackModel()
               {
                   Id = Guid.NewGuid(),
                   Title = "Fight Or Flight",
                   Author = "Hoobastank",
                   Image = "https://i.scdn.co/image/ab67616d0000b273f2d4e8964965b4330ddc258f"
               },
               new TrackModel()
               {
                   Id = Guid.NewGuid(),
                   Title = "Echoes, Silence, Patience & Grace",
                   Author = "Foo Fighters",
                   Image = "https://i.scdn.co/image/ab67616d0000b27383e260c313dc1ff1f17909cf"
               }

        };

        }
    }
}