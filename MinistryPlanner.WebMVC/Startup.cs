using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MinistryPlanner.WebMVC.Startup))]
namespace MinistryPlanner.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
