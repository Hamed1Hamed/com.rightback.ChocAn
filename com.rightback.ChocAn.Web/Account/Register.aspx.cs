using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using com.rightback.ChocAn.Web.Models;

namespace com.rightback.ChocAn.Web.Account
{
    public partial class Register : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
     
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert" + UniqueID,
    "alert('Registeration is turned off, please call Admin');", true);
            HttpContext.Current.Response.Redirect("Login.aspx");
          
        }
        


        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}