using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConferenceTrackManagementCore.Tests
{
    [TestClass()]
    public class LunchTests
    {
        private Lunch lunch;

        [TestInitialize()]
        public void Initialize()
        {
            lunch = new Lunch();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            string expectedValue = "12:00PM Lunch" + Environment.NewLine;
            string actualValue = lunch.ToString();

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
