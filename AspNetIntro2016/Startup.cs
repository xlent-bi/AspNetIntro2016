using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetIntro2016.Startup))]
namespace AspNetIntro2016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
