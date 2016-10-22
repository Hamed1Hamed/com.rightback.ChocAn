using com.rightback.ChocAn.DAL;
using com.rightback.ChocAn.Services.Members;
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
    public partial class MemberManagment : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMemberData();
                BindDetailView();
            }

        }

        private void BindDetailView()
        {
            if (Session["Member"] != null)
            {
                DetailsView1.DataSource = Session["Member"];
            }
            else
                DetailsView1.ChangeMode(DetailsViewMode.Insert);
            DetailsView1.DataBind();
        }

        private void BindMemberData()
        {
            //to ensure persistence data during postback, data stored in session
            // Session["Member"] = members.getAllMembers();

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

        //protected void GridViewMembers_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridViewMembers.EditIndex = e.NewEditIndex;
        //    DropDownList drpstatus = (DropDownList)GridViewMembers.Rows[e.NewEditIndex].Cells[8].FindControl("DropDownList1");
        //    //foreach (Member.MemberStatus r in Enum.GetValues(typeof(Member.MemberStatus)))
        //    //{
        //    //    ListItem item = new ListItem(Enum.GetName(typeof(Member.MemberStatus), r), r.ToString());
        //    //    drpstatus.Items.Add(item);
        //    //}
        //    drpstatus.DataSource = Enum.GetNames(typeof(Member.MemberStatus));
        //    drpstatus.SelectedValue = (GridViewMembers.Rows[e.NewEditIndex].FindControl("Label6") as Label).Text;
        //    drpstatus.DataBind();
        //    GridViewMembers.DataBind();

        //}

        //protected void GridViewMembers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    Member member = new Member();
        //    member.MemberID = Convert.ToInt32(GridViewMembers.Rows[e.RowIndex].Cells[0].Text);
        //    member.Name = (GridViewMembers.Rows[e.RowIndex].FindControl("TextBox1") as TextBox).Text;
        //    member.StreetAddres = (GridViewMembers.Rows[e.RowIndex].FindControl("TextBox2") as TextBox).Text;
        //    member.City = (GridViewMembers.Rows[e.RowIndex].FindControl("TextBox3") as TextBox).Text;
        //    member.Zip = (GridViewMembers.Rows[e.RowIndex].FindControl("TextBox4") as TextBox).Text;
        //    member.Email = (GridViewMembers.Rows[e.RowIndex].FindControl("TextBox5") as TextBox).Text;
        //    member.Status = (Member.MemberStatus)Enum.Parse(typeof(Member.MemberStatus), (GridViewMembers.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList).SelectedValue, true);

        //}

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            //ugly solution to find Member id, but spent hours trying to find another soulution without luck
            var key = e.Keys.Values;
            var enumerator =key.GetEnumerator();
            enumerator.MoveNext();

            Member member = new Member();
            member.MemberID = (int)enumerator.Current;
            member.Name = (DetailsView1.Rows[1].FindControl("TextBox1") as TextBox).Text;
            member.StreetAddres = (DetailsView1.Rows[1].FindControl("TextBox2") as TextBox).Text;
            member.City = (DetailsView1.Rows[1].FindControl("TextBox3") as TextBox).Text;
            member.Zip = (DetailsView1.Rows[1].FindControl("TextBox4") as TextBox).Text;
            member.Email = (DetailsView1.Rows[1].FindControl("TextBox5") as TextBox).Text;
            member.Code = (DetailsView1.Rows[1].FindControl("TextBox6") as TextBox).Text;
            member.Status = (Member.MemberStatus)Enum.Parse(typeof(Member.MemberStatus), (DetailsView1.Rows[1].FindControl("DdlForStatus") as DropDownList).SelectedValue, true);

            IMemberService members = new MemberService();
            members.upsertMember(member);
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            BindMemberData();
            BindDetailView();
        }

        protected void GridViewMembers_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            IMemberService members = new MemberService();
            int MemberId = (int)this.GridViewMembers.DataKeys[e.NewSelectedIndex].Value;
            Session["Member"] = (from u in members.getAllMembers() where u.MemberID == MemberId select u).ToList();
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            BindDetailView();
        }

        protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            DetailsView1.ChangeMode(e.NewMode);
            if (e.CancelingEdit)
            {
                DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);

            }
            BindDetailView();
        }

        protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {

            Member member = new Member();
            member.Name = (DetailsView1.Rows[1].FindControl("TextBox1") as TextBox).Text;
            member.StreetAddres = (DetailsView1.Rows[1].FindControl("TextBox2") as TextBox).Text;
            member.City = (DetailsView1.Rows[1].FindControl("TextBox3") as TextBox).Text;
            member.Zip = (DetailsView1.Rows[1].FindControl("TextBox4") as TextBox).Text;
            member.Email = (DetailsView1.Rows[1].FindControl("TextBox5") as TextBox).Text;
            member.Status = (Member.MemberStatus)Enum.Parse(typeof(Member.MemberStatus), (DetailsView1.Rows[1].FindControl("DdlForStatus") as DropDownList).SelectedValue, true);
            IMemberService members = new MemberService();
            members.upsertMember(member);
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            BindMemberData();
            BindDetailView();
        }

       
    }
}