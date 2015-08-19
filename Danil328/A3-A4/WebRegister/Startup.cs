using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebRegister.Startup))]
namespace WebRegister
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
