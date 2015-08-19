using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSortingCenter.Startup))]
namespace WebSortingCenter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
