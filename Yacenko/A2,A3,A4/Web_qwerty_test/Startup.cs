using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_qwerty_test.Startup))]
namespace Web_qwerty_test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
