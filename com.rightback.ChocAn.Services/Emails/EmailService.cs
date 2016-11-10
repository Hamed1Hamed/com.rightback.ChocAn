using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services.Emails
{
    public class EmailService : IEmailService
    {
        public bool sendEmail(string from, string to, string subject, string body, Attachment[] attachment)
        {
            using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient())
            {
                //client credential will be loaded  automatically from app.setting
                try
                {
                    MailMessage mail = new MailMessage(from, to, subject, body);
                    if (attachment != null)
                    {
                        foreach (Attachment a in attachment)
                            mail.Attachments.Add(a);
                    }
                    client.Send(mail);

                    return true;
                }

                catch (Exception ex)
                {
                    Debug.Print("The email was not sent.");
                    Debug.Print("Error message: " + ex.ToString());
                    return false;
                }
            }



        }

    }
}

