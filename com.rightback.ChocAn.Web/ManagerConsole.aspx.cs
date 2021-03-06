﻿using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.Web.Code;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace com.rightback.ChocAn.Web
{
    public partial class ManagerConsole : BasePage
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
                if (!User.IsInRole("Manager"))
                    Response.Redirect("~/Account/Login.aspx", true); 
            }

            if (!IsPostBack)
            {
                BindMemberData();
                BindgridviewForMemberClaims();
                BindProviderData();
                BindGridViewForProviderClaims();
                BindStatistics();
                BindFiles();
            }
            else
                //allow update progress animation to show
                System.Threading.Thread.Sleep(800);

        }

        private void BindStatistics()
        {
            var claims = claimService.getClaimsWithin(DateTime.Now.AddDays(-7), DateTime.Now);
            LabelStatProviders.Text = (from u in claims select u.Provider.ProviderID).Distinct().Count().ToString();
            LabelStatconsults.Text= claimService.getClaimsWithin(DateTime.Now.AddDays(-7), DateTime.Now).Count().ToString();
            if(claimService.getClaimsWithin(DateTime.Now.AddDays(-7), DateTime.Now).Count()>0)
                LabelStatFees.Text = claims.Sum(e => e.Service.Fee).ToString();
            else
                LabelStatFees.Text = "0";

        }


        #region Members tab operations
        
        private void BindgridviewForMemberClaims()
        {
            if( Session["MemberClaims"] != null)
            {
            var filtered=from u in (Session["MemberClaims"] as List<Claim>)
                         select new { ClaimID=u.ClaimID,
                             Name =u.Name,
                             DateOfClaim =u.DateOfClaim,
                             Comments =u.Comments,
                             Member_MemberID=u.Member.MemberID,
                             Provider_ProviderID =u.Provider.ProviderID,
                             Service_ServiceID =u.Service.ServiceID };
            GridViewForMemberClaims.DataSource = filtered;
                GridViewForMemberClaims.DataBind();
            }
        }

        private void BindMemberData()
        {
            GridViewMembers.DataSource = memberService.getAllMembers().ToList();
            GridViewMembers.DataBind();
        }

  
        protected void GridViewMembers_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            string Code = (string)this.GridViewMembers.DataKeys[e.AffectedRows]["Code"];
            memberService.deleteMember(Code);
        }

      
       

        protected void GridViewMembers_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            int MemberId = (int)this.GridViewMembers.DataKeys[e.NewSelectedIndex].Value;
            Session["MemberClaims"] = (from u in claimService.getClaimsWithin(DateTime.Now.AddDays(-7), DateTime.Now) where u.Member.MemberID == MemberId select u).ToList();
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
            GridViewForProviders.DataSource = providerService.getAllProviders().ToList();
            GridViewForProviders.DataBind();
        }

        private void BindGridViewForProviderClaims()
        {
            if (Session["ProviderClaims"] != null)
            {
                //serializing on the fly
                var filtered = from u in (Session["ProviderClaims"] as List<Claim>)
                               select new
                               {
                                   ClaimID = u.ClaimID,
                                   Name = u.Name,
                                   DateOfClaim = u.DateOfClaim,
                                   Comments = u.Comments,
                                   Member_MemberID = u.Member.MemberID,
                                   Provider_ProviderID = u.Provider.ProviderID,
                                   Service_ServiceID = u.Service.ServiceID
                               };
                GridViewForProviderClaims.DataSource = filtered;
                GridViewForProviderClaims.DataBind();
            }
        }
       
        protected void GridViewForProviders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewForProviders.PageIndex = e.NewPageIndex;
            BindProviderData();
        }

        protected void GridViewForProviders_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int ProviderId = (int)this.GridViewForProviders.DataKeys[e.NewSelectedIndex].Value;
            Session["ProviderClaims"] = (from u in claimService.getClaimsWithin(DateTime.Now.AddDays(-7), DateTime.Now) where u.Provider.ProviderID == ProviderId select u).ToList();
            BindGridViewForProviderClaims();
        }
        protected void TextBoxSearchProviders_TextChanged(object sender, EventArgs e)
        {
            GridViewForProviders.DataSource = providerService.getProvidersWhoContains(TextBoxSearchProviders.Text).ToList();
            GridViewForProviders.DataBind();
        }
        protected void TextBoxSearchMembers_TextChanged(object sender, EventArgs e)
        {
            GridViewMembers.DataSource = memberService.getMembersWhoContains(TextBoxSearchMembers.Text).ToList();
            GridViewMembers.DataBind();
        }


        #endregion

        public void BindFiles()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Reports/"));
            List<ListItem> files = new List<ListItem>();
            foreach (string filePath in filePaths)
            {
                files.Add(new ListItem(Path.GetFileName(filePath), filePath));
            }
            GridViewForFiles.DataSource = files;
            GridViewForFiles.DataBind();
        }
  
        protected void DownloadFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }
        protected void DeleteFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            File.Delete(filePath);
            Response.Redirect(Request.Url.AbsoluteUri);
        }

    }
}