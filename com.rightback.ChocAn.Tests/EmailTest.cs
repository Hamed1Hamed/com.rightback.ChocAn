using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.rightback.ChocAn.Services.Helpers;

namespace com.rightback.ChocAn.Tests
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public void TestEmail()
        {
            EmailService emailService = new EmailService();
            bool mailResult= emailService.sendEmail("xxx@gmail.com", "yourmail@hotmail.com", "Test mail from chocan project", "helloo");
            Assert.IsTrue(mailResult);
        }
    }
}
