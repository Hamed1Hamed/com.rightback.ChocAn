using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.DAL.Entities;
using com.rightback.ChocAn.Services.Members;
using com.rightback.ChocAn.Services.Providers;
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
    public partial class OperatorConsole : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

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
            GridViewMembers.DataSource = members.getMembersWhoContains(TextBoxSerchMembers.Text).ToList();
            GridViewMembers.DataBind();
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

      
        protected void DetailsViewForMember_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            //ugly solution to find Member id, but spent hours trying to find another soulution without luck
            var key = e.Keys.Values;
            var enumerator =key.GetEnumerator();
            enumerator.MoveNext();

            Member member = new Member();
            member.MemberID = (int)enumerator.Current;
            member.Name = (DetailsViewForMember.Rows[1].FindControl("TextBox1") as TextBox).Text;
            member.StreetAddres = (DetailsViewForMember.Rows[1].FindControl("TextBox2") as TextBox).Text;
            member.City = (DetailsViewForMember.Rows[1].FindControl("TextBox3") as TextBox).Text;
            member.Zip = (DetailsViewForMember.Rows[1].FindControl("TextBox4") as TextBox).Text;
            member.Email = (DetailsViewForMember.Rows[1].FindControl("TextBox5") as TextBox).Text;
            member.State= (USState.State)Enum.Parse(typeof(USState.State), (DetailsViewForMember.Rows[1].FindControl("DdlForState") as DropDownList).SelectedValue, true);
            member.Code = (DetailsViewForMember.Rows[1].FindControl("TextBox6") as TextBox).Text;
            member.Status = (Member.MemberStatus)Enum.Parse(typeof(Member.MemberStatus), (DetailsViewForMember.Rows[1].FindControl("DdlForStatus") as DropDownList).SelectedValue, true);

            IMemberService members = new MemberService();
            members.upsertMember(member);
            DetailsViewForMember.ChangeMode(DetailsViewMode.ReadOnly);
            Session["Member"] = (from u in members.getAllMembers() where 
                                 u.MemberID == Int32.Parse(GridViewMembers.SelectedDataKey.Value as string)
                                 select u).ToList();
            BindMemberData();
            BindDetailViewForMember();
        }

        protected void GridViewMembers_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            IMemberService members = new MemberService();
            int MemberId = (int)this.GridViewMembers.DataKeys[e.NewSelectedIndex].Value;
            Session["Member"] = (from u in members.getAllMembers() where u.MemberID == MemberId select u).ToList();
            DetailsViewForMember.ChangeMode(DetailsViewMode.ReadOnly);
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
            member.Status = (Member.MemberStatus)Enum.Parse(typeof(Member.MemberStatus), (DetailsViewForMember.Rows[1].FindControl("DdlForStatus") as DropDownList).SelectedValue, true);
                 member.State = (USState.State)Enum.Parse(typeof(USState.State), (DetailsViewForMember.Rows[1].FindControl("DdlForState") as DropDownList).SelectedValue, true);
            IMemberService members = new MemberService();
            members.upsertMember(member);
            DetailsViewForMember.ChangeMode(DetailsViewMode.ReadOnly);
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
            GridViewForProviders.DataSource = providers.getAllProviders().ToList();
            GridViewForProviders.DataBind();
        }

        private void BindDetailViewForProvider()
        {
            if (Session["Provider"] != null)
            {
                DetailsViewForSelectedProvider.DataSource = Session["Provider"];
            }
            else
                //force the statil view into insert mode
                DetailsViewForSelectedProvider.ChangeMode(DetailsViewMode.Insert);
            DetailsViewForSelectedProvider.DataBind();
        }
        protected void GridViewForProviders_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            string Code = (string)this.GridViewMembers.DataKeys[e.AffectedRows]["Code"];
            IProviderService provider = new ProviderService();
            provider.deleteProvider(Code);
        }

        protected void GridViewForProviders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewForProviders.PageIndex = e.NewPageIndex;
            BindProviderData();
        }

        protected void GridViewForProviders_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            IProviderService provider = new ProviderService();
            int ProviderId = (int)this.GridViewForProviders.DataKeys[e.NewSelectedIndex].Value;
            Session["Provider"] = (from u in provider.getAllProviders() where u.ProviderID == ProviderId select u).ToList();
            DetailsViewForSelectedProvider.ChangeMode(DetailsViewMode.ReadOnly);
            BindDetailViewForProvider();
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
            provider.Type = (Provider.ProviderType)Enum.Parse(typeof(Provider.ProviderType), (DetailsViewForSelectedProvider.Rows[1].FindControl("DdlForType") as DropDownList).SelectedValue, true);

            IProviderService providers = new ProviderService();
            providers.upsertProvider(provider);
            DetailsViewForSelectedProvider.ChangeMode(DetailsViewMode.ReadOnly);
            Session["Provider"] = (from u in providers.getAllProviders()
                                 where
u.ProviderID == Int32.Parse(GridViewForProviders.SelectedDataKey.Value as string)
                                 select u).ToList();
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
            provider.State = (USState.State)Enum.Parse(typeof(USState.State), (DetailsViewForMember.Rows[1].FindControl("DdlForState") as DropDownList).SelectedValue, true);
            provider.Email = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox5") as TextBox).Text;
            provider.Type = (Provider.ProviderType)Enum.Parse(typeof(Provider.ProviderType), (DetailsViewForSelectedProvider.Rows[1].FindControl("DdlForType") as DropDownList).SelectedValue, true);
            IProviderService providers = new ProviderService();
            providers.upsertProvider(provider);
            DetailsViewForSelectedProvider.ChangeMode(DetailsViewMode.ReadOnly);
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
            GridViewForProviders.DataSource = providers.getProvidersWhoContains(TextBoxSearchProviders.Text).ToList();
            GridViewForProviders.DataBind();
        }

        #endregion


    }
}