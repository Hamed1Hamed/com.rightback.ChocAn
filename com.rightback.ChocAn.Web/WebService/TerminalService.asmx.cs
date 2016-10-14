﻿using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.Services;
using com.rightback.ChocAn.Services.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace com.rightback.ChocAn.Web.WebService
{
    /// <summary>
    /// Summary description for TerminalService
    /// </summary>
    [WebService(Namespace = "http://rightback.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TerminalService : System.Web.Services.WebService
    {
        /// <summary>
        /// Returns true if correct provider code and terminal code provided for the provider.
        /// False otherwise.
        /// </summary>
        /// <param name="providerCode"></param>
        /// <param name="terminalCode"></param>
        /// <returns></returns>
        [WebMethod]
        public bool LoginProvider(String providerCode, String terminalCode)
        {
            //get provider service from factory
            IProviderService providerService = ServiceFactory.getProviderService();

            //try to get provider from db
            Provider provider = providerService.getByCode(providerCode);

            //return true if provider found with matching terminal code.
            return provider!=null && provider
                .TerminalCode
                .Equals(terminalCode);
        }
    }
}
