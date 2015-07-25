using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConferenceTrackManagementCore.Tests
{
    [TestClass()]
    public class TalkTests
    {
        private string testProposal = "Common Ruby Errors 45min";
        private string lightningProposal = "Rails for Python Developers lightning";

        [TestMethod()]
        public void InitSuccessfullyTest()
        {
            Talk talk = Talk.Init(testProposal);

            Assert.IsFalse(talk.IsLightning);
            Assert.AreEqual("Common Ruby Errors", talk.Title);
            Assert.AreEqual(TimeSpan.FromMinutes(45), talk.Duration);
        }

        [TestMethod()]
        public void InitLightningTalkTest()
        {
            Talk talk = Talk.Init(lightningProposal);

            Assert.IsTrue(talk.IsLightning);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException), "Invalid proposal.")]
        public void InitUnsuccessfullyTest()
        {
            string proposal = "Common";

            Talk talk = Talk.Init(proposal);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidCastException))]
        public void InitUnsuccessfullyWithInvalidTimeTest()
        {
            string proposal = "Common Ruby Errors abcmin";

            Talk talk = Talk.Init(proposal);
        }

        [TestMethod()]
        public void NonLightningToStringTest()
        {
            Talk talk = Talk.Init(testProposal);
            talk.Start = new TimeSpan(9, 0, 0);

            string expectedValue1 = "09:00AM Common Ruby Errors 45min";
            string actualValue1 = talk.ToString();

            Assert.AreEqual(expectedValue1, actualValue1);

            talk.Start = new TimeSpan(14, 0, 0);

            string expectedValue2 = "02:00PM Common Ruby Errors 45min";
            string actualValue2 = talk.ToString();

            Assert.AreEqual(expectedValue2, actualValue2);
        }

        [TestMethod()]
        public void LightningToStringTest()
        {
            Talk talk = Talk.Init(lightningProposal);
            talk.Start = new TimeSpan(9, 0, 0);

            string expectedValue1 = "09:00AM Rails for Python Developers lightning";
            string actualValue1 = talk.ToString();

            Assert.AreEqual(expectedValue1, actualValue1);

            talk.Start = new TimeSpan(16, 0, 0);

            string expectedValue2 = "04:00PM Rails for Python Developers lightning";
            string actualValue2 = talk.ToString();

            Assert.AreEqual(expectedValue2, actualValue2);
        }
    }
}
