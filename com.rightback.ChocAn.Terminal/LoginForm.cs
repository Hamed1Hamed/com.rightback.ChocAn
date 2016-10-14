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
    public partial class LoginForm : Form
    {
        //for extra security we may add this to provider login process
        //this code can be something embedded in every terminal by its firmware
        public const string TERMINAL_CODE= "CyxBTHEYFGj01L9nL0yl";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string providerCode = txtProviderCode.Text;

            TerminalService service = new TerminalService();
            bool loginResult = false;

            try
            {
                loginResult = service.LoginProvider(providerCode, TERMINAL_CODE);
                if (loginResult)
                {
                    txtLog.Text += "LOGIN SUCCESSFUL";
                    TerminalScreenManager.providerLoggedIn(this);

                }
                else
                    txtLog.Text += "LOGIN FAILURE";
            }
            catch(Exception ex)
            {
                txtLog.Text += "CONNECTION FAILURE";
            }

            txtLog.Text += Environment.NewLine;


        }
    }
}
