using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services.Emails
{
    public class EmailService : IEmailService
    {
        public bool sendEmail(string from, string to,string subject,string body)
        {
            bool result = false;
          
            using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient())
            {
             
                try
                {
                    //MailMessage mail = new MailMessage();
                    //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    //mail.From = new MailAddress("your mail@gmail.com");
                    //mail.To.Add("to_mail@gmail.com");
                    //mail.Subject = "Test Mail - 1";
                    //mail.Body = "mail with attachment";
                    //System.Net.Mail.Attachment attachment;
                    //attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
                    //mail.Attachments.Add(attachment);

                    client.Send(from, to, subject, body);
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

