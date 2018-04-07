using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1Exemplo.Startup))]
namespace _1Exemplo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
