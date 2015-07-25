using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConferenceTrackManagementCore.Tests
{
    [TestClass()]
    public class AfternoonSessionTests
    {
        private AfternoonSession afternoonSession;

        [TestInitialize]
        public void Initilize()
        {
            afternoonSession = new AfternoonSession();
        }

        [TestMethod]
        public void SpliceLastTalkTest()
        {
            for (int i = 1; i <= 4; i++)
            {
                afternoonSession.AddTalk(new Talk("For testing" + i.ToString(), TimeSpan.FromHours(1)));
            }

            Talk talk = afternoonSession.SpliceLastTalk();

            Assert.IsNotNull(talk);
            Assert.AreNotEqual(afternoonSession.LastTalk, talk);

            Assert.AreEqual(default(TimeSpan), talk.Start);
        }

        [TestMethod]
        public void AddTalkTest()
        {
            Talk firstTalk = new Talk("For testing", TimeSpan.FromHours(1));

            bool result = afternoonSession.AddTalk(firstTalk);

            Assert.IsTrue(result);

            Assert.IsNotNull(afternoonSession.LastTalk);
        }

        [TestMethod()]
        public void IsValidTest()
        {
            Talk firstTalk = new Talk("For testing", TimeSpan.FromHours(1));
            firstTalk.Start = new TimeSpan(13, 0, 0);
            bool isValid1 = afternoonSession.IsValid(firstTalk);

            Assert.IsTrue(isValid1);

            firstTalk.Start = new TimeSpan(16, 30, 0);
            bool isValid2 = afternoonSession.IsValid(firstTalk);

            Assert.IsFalse(isValid2);
        }

        [TestMethod()]
        public void IsFullTest()
        {
            for (int i = 1; i <= 4; i++)
            {
                afternoonSession.AddTalk(new Talk("For testing", TimeSpan.FromHours(1)));
            }

            bool isFull = afternoonSession.IsFull();

            Assert.IsTrue(isFull);
        }
    }
}
