using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjektPoprawkowy.Models
{
    public class AudioFile
    {
        public AudioFile(){}

        public AudioFile(string title, string artist, string creation, int minutes, int seconds)
        {
            Title = title;
            Artist = artist;
            Creation = creation;
            Minutes = minutes;
            Seconds = seconds;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Creation { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int TimesPlayed { get; set; }

        public int TotalTimeInSeconds => Minutes*60 + Seconds;
        public ICollection<Playlist> Playlists { get; set; }
    }
}