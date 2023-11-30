﻿namespace Spotify.Interfaces
{
    public interface ITrackStorable
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string? Image { get; set; }
    }
}