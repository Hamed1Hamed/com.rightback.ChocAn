using com.rightback.ChocAn.Terminal.com.rightback.webservices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace com.rightback.ChocAn.Terminal
{
    public partial class ServiceForm : Form
    {
        public ServiceForm()
        {
            InitializeComponent();
        }

        private void btnCheckMemberStatus_Click(object sender, EventArgs e)
        {
            string memberCode = txtMemberCode.Text;

            TerminalService service = new TerminalService();

            VerifyMemberResult result = service.verifyMember(memberCode);
            this.onMemberStatusReceived(result);
            
        }

        private void onMemberStatusReceived(VerifyMemberResult result)
        {
            //set status labels
            lblStatus.Text = result.ToString();
            lblMemberCode.Text = txtMemberCode.Text;
            

            //clear input box
            txtMemberCode.Text = String.Empty;
        }

        private void onMemberStatusCheckRequested()
        {
            lblStatus.Text = "Checking...";
            lblMemberCode.Text = String.Empty;
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            ServiceCodesForm serviceCodesForm = new ServiceCodesForm();
            serviceCodesForm.ShowDialog();

            txtServiceCode.Text = serviceCodesForm.getSelectedServiceCode();

            serviceCodesForm.Dispose();


        }
    }
}
