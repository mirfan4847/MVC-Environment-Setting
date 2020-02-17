using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnvironmentSetting.Startup))]
namespace EnvironmentSetting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
