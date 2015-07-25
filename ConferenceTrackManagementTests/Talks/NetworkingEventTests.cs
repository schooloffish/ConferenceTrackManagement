using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConferenceTrackManagementCore.Tests
{
    [TestClass()]
    public class NetworkingEventTests
    {
        private NetworkingEvent networkingEvent;

        [TestInitialize()]
        public void Initialize()
        {
            networkingEvent = new NetworkingEvent();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            networkingEvent.Start = new TimeSpan(17, 0, 0);
            string expectedValue = "05:00PM Networking Event";
            string actualValue = networkingEvent.ToString();

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
