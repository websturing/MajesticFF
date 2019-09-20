using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgentBookVue.Startup))]
namespace AgentBookVue
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
