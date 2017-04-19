using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjektPoprawkowy.Models;

namespace ProjektPoprawkowy.Admin
{
    public partial class ManageAccount : Page
    {
        public ApplicationDbContext Ctx = ApplicationDbContext.Create();

        /// <summary>
        /// Przy ładowaniu strony ładowana jest lista użytkowników, która nie została aktywowana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var users = from u in Ctx.Users where !u.IsActive select u;
            UserListRepeater.DataSource = users.ToList();
            UserListRepeater.DataBind();
        }

        /// <summary>
        /// W argumencie przycisku zostaje przekazany identyfikator służący do znalezienia użytkownika w bazie danych, po czym następuje jego aktywacja.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void UserListRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            foreach (RepeaterItem item in UserListRepeater.Items)
            {
                LinkButton btn = (LinkButton)item.FindControl("ActivateBTN");
                if (btn == e.CommandSource)
                {
                    var user = Ctx.Users.Find(e.CommandArgument);
                    if (user != null)
                        user.IsActive = true;
                    Ctx.SaveChanges();
                }
            }
            UserListRepeater.DataBind();
            Response.Redirect("ManageAccounts.aspx");
        }
    }
}