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

        private ServiceViewModel selectedService;

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
            this.disableVerifyLabels();
            ServiceCodesForm serviceCodesForm = new ServiceCodesForm();
            serviceCodesForm.ShowDialog();

            txtServiceCode.Text = serviceCodesForm.getSelectedServiceCode();

            serviceCodesForm.Dispose();
        }

        private void disableVerifyLabels()
        {
            this.lblServiceName.Visible = false;
            this.lblVerify.Visible = false;
            this.selectedService = null;
        }

        private void enableVerifyLabels(ServiceViewModel service) {

            if (service == null)
            {
                lblVerify.Text = "Service not found";
                this.lblVerify.ForeColor = Color.Red;
                this.selectedService = null;
            }
            else
            {
                this.selectedService = service;
                this.lblVerify.Text = service.Name;
            }


            this.lblServiceName.Visible = true;
            
            this.lblVerify.Visible = true;
            this.lblVerify.ForeColor = Color.Black;
        }


        private void btnVerify_Click(object sender, EventArgs e)
        {
            TerminalService ts = new TerminalService();
            ServiceViewModel service = ts.getService(txtServiceCode.Text);

            if (service==null || String.IsNullOrWhiteSpace(service.Name))
                this.enableVerifyLabels(null);
            else
                this.enableVerifyLabels(service);
        }

        private void txtServiceCode_Click(object sender, EventArgs e)
        {
            this.disableVerifyLabels();
        }

        private String getMemberCode()
        {
            String memberCode;

            memberCode = txtMemberCode.Text;
            if (String.IsNullOrWhiteSpace(memberCode) || memberCode.Length != 9)
                memberCode = lblMemberCode.Text;


            return memberCode;
        }

        private void clearForm()
        {
            this.disableVerifyLabels();
            this.lblMemberCode.Text = String.Empty;
            this.lblStatus.Text = String.Empty;
            this.txtComments.Text = String.Empty;        

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String memberCode = this.getMemberCode();
            if(String.IsNullOrWhiteSpace(memberCode) || memberCode.Length!=9)
            {
                MessageBox.Show("Please enter a 9 digit member code.","Missing information",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (this.selectedService==null)
            {
                MessageBox.Show("Please enter a 6 digit service code and verify","Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TerminalService ts = new TerminalService();
            RecordClaimResult result = ts.recordClaim(TerminalScreenManager.ProviderCode, memberCode, this.selectedService.Code, txtComments.Text, dtServiceProvided.Value);

            if (result.success)
            {
                MessageBox.Show("Claim recorded successfully. Fee to be paid is: " + result.service.Fee, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.clearForm();
            }
            else
                MessageBox.Show(result.message, "Error saving claim", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.clearForm();
            this.Close();
        }
    }
}
