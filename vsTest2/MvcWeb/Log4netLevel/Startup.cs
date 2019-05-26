using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Log4netLevel.Startup))]
namespace Log4netLevel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
