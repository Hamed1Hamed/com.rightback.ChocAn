using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Terminal
{
    class TerminalScreenManager
    {
        private static MenuForm m_MenuForm;
        private static LoginForm m_LoginForm;
        private static ServiceForm m_ServiceForm;
        private static ClaimConfirmationForm m_ClaimConfirm;
        public static String ProviderCode;

        public static void providerLoggedIn(LoginForm loginForm)
        {
            m_LoginForm = loginForm;
            m_MenuForm = new MenuForm();

            m_LoginForm.Hide();
            m_MenuForm.Show();

            m_MenuForm.Closed += (s, args) => m_LoginForm.Close();
        }

        public static void serviceMenu()
        {
            if (m_ServiceForm != null)
                m_ServiceForm.Dispose();

            m_ServiceForm = new ServiceForm();
            m_MenuForm.Hide();
            m_ServiceForm.Show();

            m_ServiceForm.Closed += (s, args) => m_MenuForm.Show();
        }

        public static void claimConfirm()
        {
            if (m_ClaimConfirm != null)
                m_ClaimConfirm.Dispose();

            m_ClaimConfirm = new ClaimConfirmationForm();
            m_MenuForm.Hide();
            m_ClaimConfirm.Show();
            m_ClaimConfirm.Closed += (s, args) => m_MenuForm.Show();
        }
    }
}
