using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TesteSWFast.IO.Site.Startup))]
namespace TesteSWFast.IO.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
