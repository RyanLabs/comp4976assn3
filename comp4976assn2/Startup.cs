using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(comp4976assn2.Startup))]
namespace comp4976assn2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
