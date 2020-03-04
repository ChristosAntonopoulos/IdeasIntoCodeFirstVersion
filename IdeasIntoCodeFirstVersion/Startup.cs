using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdeasIntoCodeFirstVersion.Startup))]
namespace IdeasIntoCodeFirstVersion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
