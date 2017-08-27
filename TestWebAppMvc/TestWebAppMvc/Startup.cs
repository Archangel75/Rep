using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestWebAppMvc.Startup))]
namespace TestWebAppMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
