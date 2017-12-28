using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCareas.Startup))]
namespace MVCareas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
