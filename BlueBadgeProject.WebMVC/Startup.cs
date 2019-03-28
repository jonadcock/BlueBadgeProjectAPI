using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlueBadgeProject.WebMVC.Startup))]
namespace BlueBadgeProject.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
