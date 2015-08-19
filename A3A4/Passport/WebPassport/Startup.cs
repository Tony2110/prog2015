using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebPassport.Startup))]
namespace WebPassport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
