using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bai_Project2__.Startup))]
namespace Bai_Project2__
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
