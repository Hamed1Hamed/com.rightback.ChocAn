using Microsoft.VisualStudio.TestTools.UnitTesting;
using com.rightback.ChocAn.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services.Extensions.Tests
{
    [TestClass()]
    public class DateTimeExtensionsTests
    {
        [TestMethod()]
        public void NextTest()
        {
            //saturday
            DateTime date = new DateTime(2016, 11, 19);
            //next monday should be 11/21/2016
           DateTime nextMonday = date.Next(DayOfWeek.Monday);

            Assert.AreEqual(nextMonday.Day, 21);
            Assert.AreEqual(nextMonday.Month, 11);
            Assert.AreEqual(nextMonday.Year, 2016);
        }

        [TestMethod()]
        public void PreviousTest()
        {  //saturday
            DateTime date = new DateTime(2016, 11, 19);
            //previos monday should be 11/14/2016
            DateTime previousMonday = date.Previous(DayOfWeek.Monday);

            Assert.AreEqual(previousMonday.Day, 14);
            Assert.AreEqual(previousMonday.Month, 11);
            Assert.AreEqual(previousMonday.Year, 2016);
        }
    }
}