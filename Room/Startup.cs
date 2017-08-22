using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Room.Startup))]
namespace Room
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
