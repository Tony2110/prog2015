using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebScheduler.Startup))]
namespace WebScheduler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
