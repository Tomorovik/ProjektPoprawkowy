using System;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;
using ProjektPoprawkowy.Models;

namespace ProjektPoprawkowy.Admin
{
    public partial class ManageSongs : System.Web.UI.Page
    {
        private ApplicationDbContext Ctx = ApplicationDbContext.Create();

        /// <summary>
        /// Przy ładowaniu strony ładowana jest lista wszystkich utworów w bazie danych. Jednocześnie z tej samej listy utworów wybierany jest
        /// najbardziej i najmniej popularny utwór na podstawie ilości użyć w playlistach.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var songs = from s in Ctx.Songs select s;

            SongsListRepeater.DataSource = songs.ToList();
            SongsListRepeater.DataBind();

            var temp = songs.OrderBy(song => song.TimesPlayed).ToList();
            if (temp.Count <= 0) return;

            var mostPopularSong = temp.LastOrDefault();
            MostPopular.Text = mostPopularSong.Title + " grany przez " + mostPopularSong.Artist + " aż " +
                               mostPopularSong.TimesPlayed + " razy!";

            var leastPopularSong = temp.FirstOrDefault();
            LeastPopular.Text = leastPopularSong.Title + " grany przez " + leastPopularSong.Artist + " tylko " +
                                leastPopularSong.TimesPlayed + " razy!";
        }

        /// <summary>
        /// W zależności od stanu komendy wykonywana jest metoda aktualizacji lub usunięcia.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void SongsListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Update")
                Update(e);
            else if (e.CommandName == "Delete")
                Delete(e);            
        }

        /// <summary>
        /// Metoda ustawia stan encji do usunięcia.
        /// </summary>
        /// <param name="e"></param>
        private void Delete(RepeaterCommandEventArgs e)
        {
            foreach (RepeaterItem item in SongsListRepeater.Items)
            {
                LinkButton btn = (LinkButton)item.FindControl("DeleteBTN");
                if (btn == e.CommandSource)
                {
                    var id = Convert.ToInt32(e.CommandArgument);
                    var song = Ctx.Songs.Find(id);

                    Ctx.Entry(song).State = EntityState.Deleted;
                    Ctx.SaveChanges();
                    Response.Redirect("ManageSongs.aspx");
                    break;
                }
            }
        }

        /// <summary>
        /// Metoda przekazuje identyfikator utworu jako parametr zapytania.
        /// </summary>
        /// <param name="e"></param>
        private void Update(RepeaterCommandEventArgs e)
        {
            foreach (RepeaterItem item in SongsListRepeater.Items)
            {
                LinkButton btn = (LinkButton)item.FindControl("UpdateBtn");
                if (btn == e.CommandSource)
                {
                    var id = Convert.ToInt32(e.CommandArgument);
                    Response.Redirect("~/Admin/AddSong.aspx?Id=" + id);
                }
            }
        }
    }
}