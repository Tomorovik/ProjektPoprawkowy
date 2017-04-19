using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using ProjektPoprawkowy.Models;

namespace ProjektPoprawkowy.Users
{
    public partial class CreatePlaylists : Page
    {
        private ApplicationDbContext Ctx = ApplicationDbContext.Create();

        /// <summary>
        /// Przy ³adowaniu strony pobierana jest lista artystów, która przypisywana jest kontrolce DropDownList.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var artists = Ctx.Songs.Select(af => af.Artist).Distinct().ToList();
                ArtistDDL.DataSource = artists;
                ArtistDDL.DataBind();
            }
        }

        /// <summary>
        /// Przy tworzeniu playlisty sprawdzany jest tryb tworzenia poprzez sprawdzenie stanu kontrolki RadioButton.
        /// Przy ka¿dym przypisaniu utworu do playlisty zwiêkszany jest jego licznik u¿yæ.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Generate_OnClick(object sender, EventArgs e)
        {
            Playlist playlist = new Playlist();

            var limit = Ctx.Songs.ToList().Count;
            var allSongs = Ctx.Songs.ToList();

            playlist.AudioFiles = new List<AudioFile>();
            playlist.Name = PlaylistNameTB.Text;

            if (RandomRB.Checked)
            {
                var amount = Convert.ToInt32(AmountTB.Text);
                Random r = new Random();

                while (playlist.AudioFiles.Count < amount)
                {
                    var song = allSongs[r.Next(limit)];
                    song.TimesPlayed++;
                    if (!playlist.AudioFiles.Contains(song))
                        playlist.AudioFiles.Add(song);
                }
            }
            else if (ByTimeRB.Checked)
            {
                var time = Convert.ToInt32(TimeTB.Text) * 60;
                int timeOfPlaylist = 0;
                List<AudioFile> songs = new List<AudioFile>();
                Random r = new Random();
                while ((timeOfPlaylist < time || timeOfPlaylist - time < 200) &&(songs.Count!=allSongs.Count))
                {
                    var song = allSongs[r.Next(allSongs.Count)];
                    if (!songs.Contains(song))
                    {
                        songs.Add(song);
                        song.TimesPlayed++;
                        timeOfPlaylist += song.TotalTimeInSeconds;
                    }
                }
                playlist.AudioFiles = songs;
            }
            else if (ByAuthorRB.Checked)
            {
                var artist = ArtistDDL.SelectedValue;
                allSongs = allSongs.Where(af => af.Artist.Equals(artist)).ToList();

                if (RandomOrderRB.Checked)
                {
                    Random r = new Random();
                    while (allSongs.Count > 0)
                    {
                        var song = allSongs[r.Next(allSongs.Count)];
                        song.TimesPlayed++;
                        playlist.AudioFiles.Add(song);
                        allSongs.Remove(song);
                    }
                }
                else if (TitleOrderRB.Checked)
                {
                    playlist.AudioFiles = allSongs.OrderBy(af => af.Title).ToList();
                    foreach (AudioFile file in playlist.AudioFiles)
                        file.TimesPlayed++;
                }
                else if (CreationOrderdRB.Checked)
                {
                    playlist.AudioFiles = allSongs.OrderBy(af => af.Creation).ToList();
                    foreach (AudioFile file in playlist.AudioFiles)
                        file.TimesPlayed++;
                }
                else if (LengthOrderRB.Checked)
                {
                    playlist.AudioFiles = allSongs.OrderBy(af => af.TotalTimeInSeconds).ToList();
                    foreach (AudioFile file in playlist.AudioFiles)
                        file.TimesPlayed++;
                }
            }
            Ctx.Playlists.Add(playlist);
            Ctx.SaveChanges();
            Response.Redirect("CreatePlaylists.aspx");
        }
    }
}