using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(com.rightback.ChochAn.Web.Startup))]
namespace com.rightback.ChochAn.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
