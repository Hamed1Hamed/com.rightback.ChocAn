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
            //todo
        }

        private void btnTurnOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
