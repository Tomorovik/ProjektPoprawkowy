using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ProjektPoprawkowy.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Przy logowaniu używany jest system uwierzytelniania Identity.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {

                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                var result = signinManager.PasswordSignIn(Email.Text, Password.Text, false, shouldLockout: false);
                var user = manager.FindByEmail(Email.Text);
                if (user == null)
                {
                    FailureText.Text = "Nie ma takiego konta.";
                    ErrorMessage.Visible = true;
                    return;
                }
                if (!user.IsActive)
                {
                    FailureText.Text = "Konto nie zostało aktywowane przez administratora";
                    ErrorMessage.Visible = true;
                    return;
                }
                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Nieudana próba logowania.";
                        ErrorMessage.Visible = true;
                        break;
                }
            }

        }
    }
}