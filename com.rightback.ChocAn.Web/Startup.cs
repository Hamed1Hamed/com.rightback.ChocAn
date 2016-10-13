using Microsoft.Owin;
using Owin;
using com.rightback.ChocAn.Services;

[assembly: OwinStartupAttribute(typeof(com.rightback.ChocAn.Web.Startup))]
namespace com.rightback.ChocAn.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);

          //friday report generation
            ReportBatch.ScheduleTask();
        }

    }
}
