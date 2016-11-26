using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.DAL.Enums;
using com.rightback.ChocAn.Web.Code;
using Microsoft.AspNet.Identity;
using System;
using System.Web.UI.WebControls;
using System.Linq;

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
            {
                //force the detail view into insert mode
                DetailsViewForMember.ChangeMode(DetailsViewMode.Insert);
            }
            DetailsViewForMember.DataBind();

        }
        protected void TextBoxSerchMembers_TextChanged(object sender, EventArgs e)
        {
            GridViewMembers.DataSource = memberService.getMembersWhoContains(TextBoxSerchMembers.Text).ToList();
            GridViewMembers.SelectedIndex = -1;
            GridViewMembers.DataBind();
        }

        private void BindMemberData()
        {
            GridViewMembers.DataSource = memberService.getAllMembers().ToList();
            GridViewMembers.DataBind();
        }

        protected void GridViewMembers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
  
            if (e.CommandName == "Select")
            {
                int MemberId = (int)this.GridViewMembers.DataKeys[Int32.Parse(e.CommandArgument.ToString())].Value;
                var member= memberService.getAllMembers().Where(x=>x.MemberID==MemberId).ToList();
                Session["Member"] = member;
                DetailsViewForMember.ChangeMode(DetailsViewMode.ReadOnly);
                BindDetailViewForMember();
            }
            BindMemberData();
        }
        protected void GridViewMembers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            var row = GridViewMembers.Rows[e.RowIndex];
            string Code = (row.FindControl("Label6") as Label).Text;
            memberService.deleteMember(Code);
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
            member.State = (State)Enum.Parse(typeof(State), (DetailsViewForMember.Rows[1].FindControl("DdlForState") as DropDownList).SelectedValue, true);
            member.Code = (DetailsViewForMember.Rows[1].FindControl("TextBox6") as TextBox).Text;
            member.Status = (MemberStatus)Enum.Parse(typeof(MemberStatus), (DetailsViewForMember.Rows[1].FindControl("DdlForStatus") as DropDownList).SelectedValue, true);
            memberService.upsertMember(member);
            DetailsViewForMember.ChangeMode(DetailsViewMode.ReadOnly);
            Session["Member"] =null;    
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
            member.State = (State)Enum.Parse(typeof(State), (DetailsViewForMember.Rows[1].FindControl("DdlForState") as DropDownList).SelectedValue, true);
            member.Code = (DetailsViewForMember.Rows[1].FindControl("TextBox6") as TextBox).Text;
            memberService.upsertMember(member);
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
            GridViewForProviders.DataSource = providerService.getAllProviders().ToList();
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
            provider.State = (State)Enum.Parse(typeof(State), (DetailsViewForSelectedProvider.Rows[1].FindControl("DdlForState") as DropDownList).SelectedValue, true);
            provider.Type = (ProviderType)Enum.Parse(typeof(ProviderType), (DetailsViewForSelectedProvider.Rows[1].FindControl("DdlForType") as DropDownList).SelectedValue, true);
            provider.TerminalCode = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox7") as TextBox).Text;
            providerService.upsertProvider(provider);
            DetailsViewForSelectedProvider.ChangeMode(DetailsViewMode.ReadOnly);
            Session["Provider"] =null;
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
            provider.State = (State)Enum.Parse(typeof(State), (DetailsViewForSelectedProvider.Rows[1].FindControl("DdlForState") as DropDownList).SelectedValue, true);
            provider.Email = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox5") as TextBox).Text;
            provider.Code = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox6") as TextBox).Text;
            provider.Type = (ProviderType)Enum.Parse(typeof(ProviderType), (DetailsViewForSelectedProvider.Rows[1].FindControl("DdlForType") as DropDownList).SelectedValue, true);
            provider.TerminalCode = (DetailsViewForSelectedProvider.Rows[1].FindControl("TextBox7") as TextBox).Text;
            providerService.upsertProvider(provider);
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
            GridViewForProviders.DataSource = providerService.getProvidersWhoContains(TextBoxSearchProviders.Text).ToList();
            GridViewForProviders.SelectedIndex = -1;
            GridViewForProviders.DataBind();
        }

        protected void GridViewForProviders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          
            if (e.CommandName == "Select")
            {
                int ProviderId = (int)this.GridViewForProviders.DataKeys[Int32.Parse(e.CommandArgument.ToString())].Value;
                Session["Provider"] = providerService.getAllProviders().Where(x=>x.ProviderID==ProviderId).ToList();
                DetailsViewForSelectedProvider.ChangeMode(DetailsViewMode.ReadOnly);
                BindDetailViewForProvider();
            }
 
        }

        protected void GridViewForProviders_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
          
                var row = GridViewForProviders.Rows[e.RowIndex];
                string Code = (row.FindControl("Label6") as Label).Text;
                providerService.deleteProvider(Code);
            DetailsViewForSelectedProvider.ChangeMode(DetailsViewMode.ReadOnly);
            BindDetailViewForProvider();
            BindProviderData();
        }


        #endregion


    }
}