using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.Services.Members;
using com.rightback.ChocAn.Services.Providers;
using com.rightback.ChocAn.Services.Services;
using com.rightback.ChocAn.Web.Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace com.rightback.ChocAn.Web
{
    public partial class ManagerConsole : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMemberData();
                BindgridviewForMemberClaims();
                BindProviderData();
                BindGridViewForProviderClaims();
                BindStatistics();
            }
            else
                //allow update progress animation to show
                System.Threading.Thread.Sleep(800);

        }

        private void BindStatistics()
        {
            IServiceService services = new ServiceService();
            var claims = services.getClaimsWithin(DateTime.Now.AddDays(-7), DateTime.Now);
            LabelStatProviders.Text = (from u in claims select u.Provider.ProviderID).Distinct().Count().ToString();
            LabelStatconsults.Text= services.getClaimsWithin(DateTime.Now.AddDays(-7), DateTime.Now).Count().ToString();
            if(services.getClaimsWithin(DateTime.Now.AddDays(-7), DateTime.Now).Count()>0)
                LabelStatFees.Text = claims.Sum(e => e.Service.Fee).ToString();
            else
                LabelStatFees.Text = "0";

        }


        #region Members tab operations

        private void BindgridviewForMemberClaims()
        {
           
            GridViewForMemberClaims.DataSource = (Session["Member"] as List<Member>);
                GridViewForMemberClaims.DataBind();
        }

        private void BindMemberData()
        {
            IMemberService members = new MemberService();
            GridViewMembers.DataSource = members.getAllMembers().ToList();
            GridViewMembers.DataBind();
        }

  
        protected void GridViewMembers_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            string Code = (string)this.GridViewMembers.DataKeys[e.AffectedRows]["Code"];
            IMemberService members = new MemberService();
            members.deleteMember(Code);
        }

      
       

        protected void GridViewMembers_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            IServiceService services = new ServiceService();
            int MemberId = (int)this.GridViewMembers.DataKeys[e.NewSelectedIndex].Value;
            Session["Member"] = (from u in services.getClaimsWithin(DateTime.Now.AddDays(-7), DateTime.Now) where u.Member.MemberID == MemberId select u).ToList();
            BindgridviewForMemberClaims();
        }

      
       
        protected void GridViewMembers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewMembers.PageIndex = e.NewPageIndex;
            BindMemberData();
        }

        #endregion


        #region Providers tab operations

        private void BindProviderData()
        {
            IProviderService providers = new ProviderService();
            GridViewForProviders.DataSource = providers.getAllProviders().ToList();
            GridViewForProviders.DataBind();
        }

        private void BindGridViewForProviderClaims()
        {

            GridViewForProviderClaims.DataSource = (Session["Provider"] as List<Provider>); ;

            GridViewForProviderClaims.DataBind();
        }
       
        protected void GridViewForProviders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewForProviders.PageIndex = e.NewPageIndex;
            BindProviderData();
        }

        protected void GridViewForProviders_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            IServiceService services = new ServiceService();
            int ProviderId = (int)this.GridViewForProviders.DataKeys[e.NewSelectedIndex].Value;
            Session["Provider"] = (from u in services.getClaimsWithin(DateTime.Now.AddDays(-7), DateTime.Now) where u.Provider.ProviderID == ProviderId select u);
            BindGridViewForProviderClaims();
        }
        protected void TextBoxSearchProviders_TextChanged(object sender, EventArgs e)
        {
            IProviderService providers = new ProviderService();
            GridViewForProviders.DataSource = providers.getProvidersWhoContains(TextBoxSearchProviders.Text).ToList();
            GridViewForProviders.DataBind();
        }
        protected void TextBoxSerchMembers_TextChanged(object sender, EventArgs e)
        {
            IMemberService members = new MemberService();
            GridViewMembers.DataSource = members.getMembersWhoContains(TextBoxSerchMembers.Text).ToList();
            GridViewMembers.DataBind();
        }


        #endregion
    }
}