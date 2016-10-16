using com.rightback.ChocAn.Services;
using com.rightback.ChocAn.Services.Members;
using com.rightback.ChocAn.Services.Providers;
using com.rightback.ChocAn.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace com.rightback.ChocAn.Web.Code
{
    public class BasePage : System.Web.UI.Page
    {
        protected IProviderService providerService = ServiceFactory.getProviderService();
        protected IMemberService memberService = ServiceFactory.getMemberService();
        protected IServiceService serviceService = ServiceFactory.getServiceService();
    }
}