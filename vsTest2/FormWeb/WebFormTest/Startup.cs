using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormTest.Startup))]
namespace WebFormTest
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
