using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjektPoprawkowy.Startup))]
namespace ProjektPoprawkowy
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
