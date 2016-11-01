using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.rightback.ChocAn.Services;
using com.rightback.ChocAn.Services.Emails;

namespace com.rightback.ChocAn.Tests
{
    [TestClass]
    public class EmailTest
    {
        IEmailService emailService ;

        [TestInitialize]
        public void StartUp()
        {
            emailService = new EmailService();
        }
     

        [TestMethod]
        public void TestEmailWithNullAttachment()
        {
 
            bool mailResult= emailService.sendEmail("xxx@gmail.com", "chocanmailer@gmail.com", "Test mail from chocan project", "helloo",null);
            Assert.IsTrue(mailResult);
        }
        [TestMethod]
        public void TestEmailWithEmptySender()
        {
            bool mailResult = emailService.sendEmail("", "chocanmailer@gmail.com", "Test mail from chocan project", "helloo", null);
            Assert.IsFalse(mailResult);
        }
        [TestMethod]
        public void TestEmailWithNullSender()
        {
            bool mailResult = emailService.sendEmail(null, "chocanmailer@gmail.com", "Test mail from chocan project", "helloo", null);
            Assert.IsFalse(mailResult);
        }
        [TestMethod]
        public void TestEmailWithEmptyReciver()
        {
            bool mailResult = emailService.sendEmail("xxx@gmail.com", "", "Test mail from chocan project", "helloo", null);
            Assert.IsFalse(mailResult);
        }
        [TestMethod]
        public void TestEmailWithNullReciver()
        {
            bool mailResult = emailService.sendEmail("xxx@gmail.com", null, "Test mail from chocan project", "helloo", null);
            Assert.IsFalse(mailResult);
        }
        [TestMethod]
        public void TestEmailWithEmptySubject()
        {
            bool mailResult = emailService.sendEmail("xxx@gmail.com", "chocanmailer@gmail.com", "", "helloo", null);
            Assert.IsTrue(mailResult);
        }
        [TestMethod]
        public void TestEmailWithNullSubject()
        {
            bool mailResult = emailService.sendEmail("xxx@gmail.com", "chocanmailer@gmail.com", null, "helloo", null);
            Assert.IsTrue(mailResult);
        }
        [TestMethod]
        public void TestEmailWithEmptyBody()
        {
            bool mailResult = emailService.sendEmail("xxx@gmail.com", "chocanmailer@gmail.com", "Test mail from chocan project", "", null);
            Assert.IsTrue(mailResult);
        }
        [TestMethod]
        public void TestEmailWithNullBody()
        {
            bool mailResult = emailService.sendEmail("xxx@gmail.com", "chocanmailer@gmail.com", "Test mail from chocan project", null, null);
            Assert.IsTrue(mailResult);
        }

    }
}
