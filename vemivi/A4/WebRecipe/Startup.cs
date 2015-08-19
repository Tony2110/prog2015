using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebRecipe.Startup))]
namespace WebRecipe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
