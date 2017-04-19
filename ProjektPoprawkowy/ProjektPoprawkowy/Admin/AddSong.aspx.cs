using System;
using System.Data.Entity;
using System.Web.UI;
using ProjektPoprawkowy.Models;

namespace ProjektPoprawkowy.Admin
{
    public partial class AddSong : Page
    {
        private ApplicationDbContext Ctx = ApplicationDbContext.Create();

        /// <summary>
        /// Przy ładowaniu strony sprawdzana jest zmienna lokalna czy został podany parametr, który służy do znalezienia odpowiedniego utworu
        /// w bazie danych, ktorego parametry wstawiane są do kontrolek.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);
                AudioFile af = Ctx.Songs.Find(id);
                AuthorTB.Text = af.Artist;
                TitleTB.Text = af.Title;
                CreationTB.Text = af.Creation;
                LengthTB.Text = af.Minutes + ":" + af.Seconds;
                SaveBTN.Text = "Aktualizuj";
            }
        }

        /// <summary>
        /// W zależności od stanu tekstu przycisku utwór jest aktualizowany bądź dodawany do bazy.
        /// Przy aktualizacji stosuje się ustawienie stanu encji jako zmodyfikowany.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddToDB(object sender, EventArgs e)
        {
            if (SaveBTN.Text.Equals("Aktualizuj"))
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);
                AudioFile af = Ctx.Songs.Find(id);
                af.Artist = AuthorTB.Text;
                af.Title = TitleTB.Text;
                af.Creation = CreationTB.Text;
                var times = LengthTB.Text.Split(':');
                var min = Convert.ToInt32(times[0]);
                var secs = Convert.ToInt32(times[1]);
                af.Minutes = min;
                af.Seconds = secs;
                Ctx.Entry(af).State = EntityState.Modified;
                Ctx.SaveChanges();
                Response.Redirect("~/Admin/ManageSongs.aspx");
            }
            else
            {
                var times = LengthTB.Text.Split(':');
                var min = Convert.ToInt32(times[0]);
                var secs = Convert.ToInt32(times[1]);

                AudioFile af = new AudioFile(TitleTB.Text, AuthorTB.Text, CreationTB.Text, min, secs);

                Ctx.Songs.Add(af);
                Ctx.SaveChanges();
                Response.Redirect("AddSong.aspx");
            }
        }
    }
}