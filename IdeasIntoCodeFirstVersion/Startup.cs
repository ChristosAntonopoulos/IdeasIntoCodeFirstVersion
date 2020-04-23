using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;

[assembly: OwinStartupAttribute(typeof(IdeasIntoCodeFirstVersion.Startup))]
namespace IdeasIntoCodeFirstVersion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
            ConfigureAuth(app);
            //RegisterAuth(app);
        }
    }
}
