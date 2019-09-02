using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcPet.UI.Web.Startup))]
namespace mvcPet.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
