using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceTrackManagementCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ConferenceTrackManagementCore.Tests
{
    [TestClass()]
    public class MorningSessionTests
    {
        private MorningSession morningSession;

        [TestInitialize]
        public void Initilize()
        {
            morningSession = new MorningSession();
        }

        [TestMethod]
        public void SpliceLastTalkTest()
        {
            for (int i = 1; i <= 3; i++)
            {
                morningSession.AddTalk(new Talk("For testing" + i.ToString(), TimeSpan.FromHours(1)));
            }

            Talk talk = morningSession.SpliceLastTalk();

            Assert.IsNotNull(talk);
            Assert.AreNotEqual(morningSession.LastTalk, talk);

            Assert.AreEqual(default(TimeSpan), talk.Start);
        }


        [TestMethod]
        public void AddTalkTest()
        {
            Talk firstTalk = new Talk("For testing", TimeSpan.FromHours(1));

            bool result = morningSession.AddTalk(firstTalk);

            Assert.IsTrue(result);

            Assert.IsNotNull(morningSession.LastTalk);
        }

        [TestMethod()]
        public void IsValidTest()
        {
            Talk firstTalk = new Talk("For testing", TimeSpan.FromHours(1));
            firstTalk.Start = new TimeSpan(10, 0, 0);
            bool isValid1 = morningSession.IsValid(firstTalk);

            Assert.IsTrue(isValid1);

            firstTalk.Start = new TimeSpan(11, 30, 0);
            bool isValid2 = morningSession.IsValid(firstTalk);

            Assert.IsFalse(isValid2);
        }

        [TestMethod()]
        public void IsFullTest()
        {
            for (int i = 1; i <= 3; i++)
            {
                morningSession.AddTalk(new Talk("For testing", TimeSpan.FromHours(1)));
            }

            bool isFull = morningSession.IsFull();

            Assert.IsTrue(isFull);
        }
    }
}
