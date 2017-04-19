using System;
using System.Collections.Generic;

namespace ProjektPoprawkowy.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AudioFile> AudioFiles { get; set; }
        public DateTime? LastPlayingTime { get; set; }
    }
}