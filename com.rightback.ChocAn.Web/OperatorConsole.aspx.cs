using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.DAL.Entities;
using com.rightback.ChocAn.DAL.Enums;
using com.rightback.ChocAn.Services.Members;
using com.rightback.ChocAn.Services.Providers;
using com.rightback.ChocAn.Web.Code;
using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace com.rightback.ChocAn.Web
{
    public partial class OperatorConsole : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            // check if logged in
            if (User.Identity.GetUserId() == null)
            {
                Response.Redirect("~/Account/Login.aspx", true);
            }
            else
            {
                if (!User.IsInRole("Operator"))
                    Response.Redirect("~/Account/Login.aspx", true);
            }

            if (!IsPostBack)
            {
                BindMemberData();
                BindDetailViewForMember();
                BindProviderData();
                BindDetailViewForProvider();
            }
            else
                //allow update progress animation to show
                System.Threading.Thread.Sleep(800);

        }


        #region Members tab operations

        private void BindDetailViewForMember()
        {
            if (Session["Member"] != null)
            {
                DetailsViewForMember.DataSource = Session["Member"];
            }
            else
                //force the detail view into insert mode
                DetailsViewForMember.ChangeMode(DetailsViewMode.Insert);
            DetailsViewForMember.DataBind();
        }
        protected void TextBoxSerchMembers_TextChanged(object sender, EventArgs e)
        {
            IMemberService members = new MemberService();
            GridViewMembers.DataSource = members.getMembersWhoContains(TextBoxSerchMembers.Text);
            GridViewMembers.SelectedIndex = -1;
            GridViewMembers.DataBind();
        }

        private void BindMemberData()
        {
            IMemberService members = new MemberService();
            GridViewMembers.DataSource = members.getAllMembers();
            GridViewMembers.DataBind();
        }

        protected void GridViewMembers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
  
            if (e.CommandName == "Select")
            {

                IMemberService members = new MemberService();
                int MemberId = (int)this.GridViewMembers.DataKeys[Int32.Parse(e.CommandArgument.ToString())].Value;
                Session["Member"] = (from u in members.getAllMembers() where u.MemberID == MemberId select u);
                DetailsViewForMember.ChangeMode(DetailsViewMode.ReadOnly);
                BindDetailViewForMember();
            }
            BindMemberData();
        }
        protected void GridViewMembers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            var row = GridViewMembers.Rows[e.RowIndex];
            string Code = (row.FindControl("Label6") as Label).Text;
            IMemberService members = new MemberService();
            members.deleteMember(Code);
            DetailsViewForMember.ChangeMode(DetailsViewMode.ReadOnly);
            BindMemberData();
            BindDetailViewForMember();
        }


        protected void DetailsViewForMember_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            //ugly solution to find Member id, but spent hours trying to find another soulution without luck
            var key = e.Keys.Values;
            var enumerator = key.GetEnumerator();
            enumerator.MoveNext();

            Member member = new Member();
            member.MemberID = (int)enumerator.Current;
            member.Name = (DetailsViewForMember.Rows[1].FindControl("TextBox1") as TextBox).Text;
            member.StreetAddres = (DetailsViewForMember.Rows[1].FindControl("TextBox2") as TextBox).Text;
            member.City = (DetailsViewForMember.Rows[1].FindControl("TextBox3") as TextBox).Text;
            member.Zip = (DetailsViewForMember.Rows[1].FindControl("TextBox4") as TextBox).Text;
            member.Email = (DetailsViewForMember.Rows[1].FindControl("TextBox5") as TextBox).Text;
            member.State = (USState.State)Enum.Parse(typeof(USState.State), (DetailsViewForMember.Rows[1].FindControl("DdlForState") as DropDownList).SelectedValue, true);
            member.Code = (DetailsViewForMember.Rows[1].FindControl("TextBox6") as TextBox).Text;
            member.Status = (MemberStatus)Enum.Parse(typeof(MemberStatus), (DetailsViewForMember.Rows[1].FindControl("DdlForStatus") as DropDownList).SelectedValue, true);

            IMemberService members = new MemberService();
            members.upsertMember(member);
            DetailsViewForMember.ChangeMode(DetailsViewMode.ReadOnly);
            int MemberId = member.MemberID;
            Session["Member"] = (from u in members.getAllMembers()
                                 where
                                   u.MemberID == MemberId
                                 select u);
            GridViewMembers.SelectedIndex = -1;
            BindMemberData();
            BindDetailViewForMember();
        }



        protected void DetailsViewForMember_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            DetailsViewForMember.ChangeMode(e.NewMode);
            if (e.CancelingEdit)
            {
                DetailsViewForMember.ChangeMode(DetailsViewMode.ReadOnly);

            }
            BindDetailViewForMember();
        }

        protected void DetailsViewForMember_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            Member member = new Member();
            member.Name = (DetailsViewForMember.Rows[1].FindControl("TextBox1") as TextBox).Text;
            member.StreetAddres = (DetailsViewForMember.Rows[1].FindControl("TextBox2") as TextBox).Text;
            member.City = (DetailsViewForMember.Rows[1].FindControl("TextBox3") as TextBox).Text;
            member.Zip = (DetailsViewForMember.Rows[1].FindControl("TextBox4") as TextBox).Text;
            member.Email = (DetailsViewForMember.Rows[1].FindControl("TextBox5") as TextBox).Text;
            member.Status = (MemberStatus)Enum.Parse(typeof(MemberStatus), (DetailsViewForMember.Rows[1].FindControl("DdlForStatus") as DropDownList).SelectedValue, true);
            member.State = (USState.State)Enum.Parse(typeof(USState.State), (DetailsViewForMember.Rows[1].FindControl("DdlForState") as DropDownList).SelectedValue, true);
            member.Code = (DetailsViewForMember.Rows[1].FindControl("TextBox6") as TextBox).Text;
            IMemberService members = new MemberService();
            members.upsertMember(member);
            DetailsViewForMember.ChangeMode(DetailsViewMode.ReadOnly);
            GridViewMembers.SelectedIndex = -1;
            BindMemberData();
            BindDetailViewForMember();
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
            GridViewForProviders.DataSource = providers.getAllProviders();
            GridViewForProviders.DataBind();
        }

        private void BindDetailViewForProvider()
        {
            if (Session["Provider"] != null)
            {
                DetailsViewForSelectedProvider.DataSource = Session["Provider"];
                DetailsViewForSelectedProvider.DataBind();
            }
            else
                //force the detail view into insert mode
                DetailsViewForSelectedProvider.ChangeMode(DetailsViewMode.Insert);

        }


        protected void GridViewForProviders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewForProviders.PageIndex = e.NewPageIndex;
            BindProviderData();
        }



        protected void DetailsViewForSelectedProvider_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            //ugly solution to find Member id, but spent hours trying to find another soulution without luck
            var key = e.Keys.Values;
            var enumerator = key.GetEnumerator();
            enumerator.MoveNext();

            Provider provider = new Provider();
            provider.ProviderID = (int)enumerator.Current;
            provider.Name = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox1") as TextBox).Text;
            provider.StreetAddres = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox2") as TextBox).Text;
            provider.City = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox3") as TextBox).Text;
            provider.Zip = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox4") as TextBox).Text;
            provider.Email = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox5") as TextBox).Text;
            provider.Code = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox6") as TextBox).Text;
            provider.State = (USState.State)Enum.Parse(typeof(USState.State), (DetailsViewForMember.Rows[1].FindControl("DdlForState") as DropDownList).SelectedValue, true);
            provider.Type = (ProviderType)Enum.Parse(typeof(ProviderType), (DetailsViewForSelectedProvider.Rows[1].FindControl("DdlForType") as DropDownList).SelectedValue, true);
            provider.TerminalCode = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox7") as TextBox).Text;
            IProviderService providers = new ProviderService();
            providers.upsertProvider(provider);
            DetailsViewForSelectedProvider.ChangeMode(DetailsViewMode.ReadOnly);
            int ProviderId = provider.ProviderID;
            Session["Provider"] = (from u in providers.getAllProviders()
                                   where
                                    u.ProviderID == ProviderId
                                   select u);
            GridViewForProviders.SelectedIndex = -1;
            BindProviderData();
            BindDetailViewForProvider();
        }

        protected void DetailsViewForSelectedProvider_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            Provider provider = new Provider();
            provider.Name = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox1") as TextBox).Text;
            provider.StreetAddres = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox2") as TextBox).Text;
            provider.City = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox3") as TextBox).Text;
            provider.Zip = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox4") as TextBox).Text;
            provider.State = (USState.State)Enum.Parse(typeof(USState.State), (DetailsViewForSelectedProvider.Rows[1].FindControl("DdlForState") as DropDownList).SelectedValue, true);
            provider.Email = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox5") as TextBox).Text;
            provider.Code = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox6") as TextBox).Text;
            provider.Type = (ProviderType)Enum.Parse(typeof(ProviderType), (DetailsViewForSelectedProvider.Rows[1].FindControl("DdlForType") as DropDownList).SelectedValue, true);
            provider.TerminalCode = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox7") as TextBox).Text;
            IProviderService providers = new ProviderService();
            providers.upsertProvider(provider);
            DetailsViewForSelectedProvider.ChangeMode(DetailsViewMode.ReadOnly);
            GridViewForProviders.SelectedIndex = -1;
            BindProviderData();
            BindDetailViewForProvider();


        }

        protected void DetailsViewForSelectedProvider_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            DetailsViewForSelectedProvider.ChangeMode(e.NewMode);
            if (e.CancelingEdit)
            {
                DetailsViewForSelectedProvider.ChangeMode(DetailsViewMode.ReadOnly);

            }
            BindDetailViewForProvider();
        }
        protected void TextBoxSearchProviders_TextChanged(object sender, EventArgs e)
        {
            IProviderService providers = new ProviderService();
            GridViewForProviders.DataSource = providers.getProvidersWhoContains(TextBoxSearchProviders.Text);
            GridViewForProviders.SelectedIndex = -1;
            GridViewForProviders.DataBind();
        }

        protected void GridViewForProviders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          
            if (e.CommandName == "Select")
            {
                IProviderService provider = new ProviderService();
                int ProviderId = (int)this.GridViewForProviders.DataKeys[Int32.Parse(e.CommandArgument.ToString())].Value;
                Session["Provider"] = (from u in provider.getAllProviders() where u.ProviderID == ProviderId select u);
                DetailsViewForSelectedProvider.ChangeMode(DetailsViewMode.ReadOnly);
                BindDetailViewForProvider();
            }
 
        }

        protected void GridViewForProviders_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
          
                var row = GridViewForProviders.Rows[e.RowIndex];
                string Code = (row.FindControl("Label6") as Label).Text;
                IProviderService provider = new ProviderService();
                provider.deleteProvider(Code);
            DetailsViewForSelectedProvider.ChangeMode(DetailsViewMode.ReadOnly);
            BindDetailViewForProvider();
            BindProviderData();
        }


        #endregion


    }
}