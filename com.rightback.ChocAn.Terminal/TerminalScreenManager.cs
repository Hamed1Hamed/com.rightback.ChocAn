using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Terminal
{
    class TerminalScreenManager
    {
        private static LoginForm m_LoginForm;
        private static ServiceForm m_ServiceForm;
        public static String ProviderCode;

        public static void providerLoggedIn(LoginForm loginForm)
        {
            m_LoginForm = loginForm;
            m_ServiceForm = new ServiceForm();

            m_LoginForm.Hide();
            m_ServiceForm.Show();

            m_ServiceForm.Closed += (s, args) => m_LoginForm.Close();
        }
    }
}
