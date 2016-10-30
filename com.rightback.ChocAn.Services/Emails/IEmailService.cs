using System.Net.Mail;

namespace com.rightback.ChocAn.Services.Emails
{
    public interface IEmailService
    {
        bool sendEmail(string from, string to, string subject, string body, Attachment[] attachment);
    }
}