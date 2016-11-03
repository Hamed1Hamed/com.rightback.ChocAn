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
    public partial class ClaimConfirmationForm : Form
    {
        public ClaimConfirmationForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TerminalService ts = new TerminalService();

            DateTime currentDate = dtCurrentDate.Value;
            DateTime serviceDate = dtServiceDate.Value;

            String memberName = txtMemberName.Text;
            String memberNumber = txtMemberNumber.Text;
            String serviceCode = txtServiceCode.Text;

            decimal fee = 0;
            Decimal.TryParse(txtServiceFee.Text, out fee);

            String errors = String.Empty;

            if (serviceDate > currentDate)
                errors += "Service date cannot be after current date." + Environment.NewLine;

            if (String.IsNullOrWhiteSpace(memberNumber))
                errors += "Member code cannot be empty" + Environment.NewLine;

            if (String.IsNullOrWhiteSpace(serviceCode))
                errors += "Service code cannot be empty." + Environment.NewLine;

            if (fee <= 0)
                errors += "Fee must be a valid decimal greater than 0" + Environment.NewLine;


            if (!String.IsNullOrEmpty(errors))
            {
                MessageBox.Show(errors, "Errors in the form.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string serviceResult = ts.recordClaimCheck(TerminalScreenManager.ProviderCode, currentDate, serviceDate, memberName, memberNumber, serviceCode, fee);

            if (!String.IsNullOrWhiteSpace(serviceResult))
            {
                MessageBox.Show(serviceResult, "An error occurred while saving claim check.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Claim check saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
