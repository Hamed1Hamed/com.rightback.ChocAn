using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.rightback.ChocAn.Services;
using com.rightback.ChocAn.Services.Emails;

namespace com.rightback.ChocAn.Tests
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public void TestEmailWithNullAttachment()
        {
            EmailService emailService = new EmailService();
            bool mailResult= emailService.sendEmail("xxx@gmail.com", "yourmail@hotmail.com", "Test mail from chocan project", "helloo",null);
            Assert.IsTrue(mailResult);
        }
        [TestMethod]
        public void TestEmailWithEmptySender()
        {
            EmailService emailService = new EmailService();
            bool mailResult = emailService.sendEmail("", "yourmail@hotmail.com", "Test mail from chocan project", "helloo", null);
            Assert.IsTrue(mailResult);
        }
        [TestMethod]
        public void TestEmailWithNullSender()
        {
            EmailService emailService = new EmailService();
            bool mailResult = emailService.sendEmail(null, "yourmail@hotmail.com", "Test mail from chocan project", "helloo", null);
            Assert.IsTrue(mailResult);
        }
        [TestMethod]
        public void TestEmailWithEmptyReciver()
        {
            EmailService emailService = new EmailService();
            bool mailResult = emailService.sendEmail("xxx@gmail.com", "", "Test mail from chocan project", "helloo", null);
            Assert.IsTrue(mailResult);
        }
        [TestMethod]
        public void TestEmailWithNullReciver()
        {
            EmailService emailService = new EmailService();
            bool mailResult = emailService.sendEmail("xxx@gmail.com", null, "Test mail from chocan project", "helloo", null);
            Assert.IsTrue(mailResult);
        }
        [TestMethod]
        public void TestEmailWithEmptySubject()
        {
            EmailService emailService = new EmailService();
            bool mailResult = emailService.sendEmail("xxx@gmail.com", "yourmail@hotmail.com", "", "helloo", null);
            Assert.IsTrue(mailResult);
        }
        [TestMethod]
        public void TestEmailWithNullSubject()
        {
            EmailService emailService = new EmailService();
            bool mailResult = emailService.sendEmail("xxx@gmail.com", "yourmail@hotmail.com", null, "helloo", null);
            Assert.IsTrue(mailResult);
        }
        [TestMethod]
        public void TestEmailWithEmptyBody()
        {
            EmailService emailService = new EmailService();
            bool mailResult = emailService.sendEmail("xxx@gmail.com", "yourmail@hotmail.com", "Test mail from chocan project", "", null);
            Assert.IsTrue(mailResult);
        }
        [TestMethod]
        public void TestEmailWithNullBody()
        {
            EmailService emailService = new EmailService();
            bool mailResult = emailService.sendEmail("xxx@gmail.com", "yourmail@hotmail.com", "Test mail from chocan project", null, null);
            Assert.IsTrue(mailResult);
        }

    }
}
