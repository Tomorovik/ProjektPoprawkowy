using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjektPoprawkowy.Models;
using Label = System.Web.UI.WebControls.Label;

namespace ProjektPoprawkowy.Users
{
    public partial class PlaylistDetails : Page
    {
        private ApplicationDbContext Ctx = ApplicationDbContext.Create();

        /// <summary>
        /// Przy ³adowaniu strony pobierana jest lista artystów, która przypisywana jest kontrolce DropDownList.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            Ctx.Songs.Load();
            Ctx.Playlists.Load();

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);

                var songs = Ctx.Database.SqlQuery<AudioFile>("SELECT * FROM dbo.AudioFiles JOIN dbo.AudioFilePlaylists ON dbo.AudioFiles.Id = dbo.AudioFilePlaylists.AudioFile_Id WHERE dbo.AudioFilePlaylists.Playlist_Id=@pl",
                    new SqlParameter("@pl", id)).ToList();

                SongsListRepeater.DataSource = songs;
                SongsListRepeater.DataBind();

                Control FooterTemplate = SongsListRepeater.Controls[SongsListRepeater.Controls.Count - 1].Controls[0];
                Label totalTime = FooterTemplate.FindControl("TotalPlaylistTime") as Label;
                if (totalTime != null)
                {
                    var time = songs.Sum(song => song.TotalTimeInSeconds);
                    totalTime.Text = String.Format($"{time / 60}:{time % 60}");
                }

            }

        }

    }
}