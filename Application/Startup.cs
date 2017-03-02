using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCappli_rest.Startup))]
namespace MVCappli_rest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
