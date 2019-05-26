using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcEntity.Startup))]
namespace MvcEntity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
