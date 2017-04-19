using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjektPoprawkowy.Models;

namespace ProjektPoprawkowy.Users
{
    public partial class ManagePlaylists : Page
    {
        private ApplicationDbContext Ctx = ApplicationDbContext.Create();

        /// <summary>
        /// Metoda pobiera wszystkie playlisty z bazy danych.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var playlists = Ctx.Playlists.ToList();
            PlaylistsListRepeater.DataSource = playlists;
            PlaylistsListRepeater.DataBind();
        }

        /// <summary>
        /// Metoda okreœla czas rozpoczêcia odtwarzania listy.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void PlaylistsListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("Play"))
            {
                foreach (RepeaterItem item in PlaylistsListRepeater.Items)
                {
                    LinkButton btn = (LinkButton)item.FindControl("PlayBTN");
                    if (btn == e.CommandSource)
                    {
                        var lbl = Convert.ToInt32(e.CommandArgument);
                        var playlist = Ctx.Playlists.Find(lbl);

                        if (playlist != null)
                            playlist.LastPlayingTime = DateTime.UtcNow;

                        Ctx.SaveChanges();
                        Response.Redirect("ManagePlaylists.aspx");
                    }
                }
            }
            else if (e.CommandName.Equals("Details"))
            {
                foreach (RepeaterItem item in PlaylistsListRepeater.Items)
                {
                    LinkButton btn = (LinkButton)item.FindControl("DetailsBTN");
                    if (btn == e.CommandSource)
                    {
                        var id = Convert.ToInt32(e.CommandArgument);
                        Response.Redirect("~/Users/PlaylistDetails.aspx?Id=" + id);
                    }
                }
            }

        }
    }
}