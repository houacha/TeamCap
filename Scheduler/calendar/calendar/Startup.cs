using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(calendar.Startup))]
namespace calendar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
