using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProjektPoprawkowy.Models;

namespace ProjektPoprawkowy.Account
{
    public partial class Register : Page
    {

        /// <summary>
        /// Podczas rejestracji użytkownika stosowany jest system rejestracji Identity.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text, IsActive = false };
            IdentityResult result = manager.Create(user, Password.Text);

            if (result.Succeeded)
            {
                manager.AddToRole(user.Id, "user");
                if (user.IsActive)
                {
                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    ErrorMessage.Text = "Konto zostało stworzone. Poczekaj na aktywację przez administratora.";
                }
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}