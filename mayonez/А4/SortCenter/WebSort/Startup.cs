using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSort.Startup))]
namespace WebSort
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
