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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            TerminalScreenManager.serviceMenu();
        }

        private void btnClaimConfirm_Click(object sender, EventArgs e)
        {
            TerminalScreenManager.claimConfirm();
        }

        private void btnServiceDirectory_Click(object sender, EventArgs e)
        {
            TerminalService ts = new TerminalService();
            String result = ts.requestProviderDirectory(TerminalScreenManager.ProviderCode);

            if (String.IsNullOrEmpty(result))
                MessageBox.Show("Service directory sent to your email address.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("An error occurred while sending service directory. "+result, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnTurnOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
