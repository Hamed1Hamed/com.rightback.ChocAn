﻿using Microsoft.Owin;
using Owin;
using com.rightback.ChocAn.Services;

[assembly: OwinStartupAttribute(typeof(com.rightback.ChocAn.Web.Startup))]
namespace com.rightback.ChocAn.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);

          //friday report generation
          //this is creating exception, please do not leave the app in broken state :) - commenting out
          //Maged reply: the problem fixed I forgot to put async keword on scheduler method :)
          //
            ReportBatch.ScheduleTask();
        }

    }
}
