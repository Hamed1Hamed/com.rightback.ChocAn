using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services.Emails
{
    public class EmailService : IEmailService
    {
        public bool sendEmail(string from, string to,string subject,string body,Attachment[] attachment)
        {
            bool result = false;
          
            using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient())
            {
             
                try
                {
                    MailMessage mail = new MailMessage();
                    //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress(from);
                    mail.To.Add(to);
                    mail.Subject = subject;
                    mail.Body = body;
                    //System.Net.Mail.Attachment attachment;
                    //attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
                    foreach(Attachment a in attachment)
                    mail.Attachments.Add(a);
                    
                    client.Send(mail);
                    result = true;
                }
                catch (Exception ex)
                {
                    Debug.Print("The email was not sent.");
                    Debug.Print("Error message: " + ex.ToString());
                }
            }

           
            return result;
        }

    }
}

