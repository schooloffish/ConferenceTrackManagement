using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace ConferenceTrackManagementCore.Tests
{
    [TestClass()]
    public class TrackTests
    {
        private Track track;

        [TestInitialize]
        public void Initialize()
        {
            track = new Track();
        }

        [TestMethod()]
        public void AddTalkTest()
        {
            for (int i = 1; i <= 2; i++)
            {
                bool result = track.AddTalk(new Talk("For testing" + i.ToString(), TimeSpan.FromHours(1)));
                Assert.IsTrue(result);
            }

            bool result1 = track.AddTalk(new Talk("For testing3", TimeSpan.FromMinutes(45)));

            Assert.IsTrue(result1);

            bool result2 = track.AddTalk(new Talk("For testing4", TimeSpan.FromMinutes(30)));

            Assert.IsFalse(result2);
        }

        [TestMethod()]
        public void SpliceLastTalkTest()
        {
            Talk talk = new Talk("For Testing", TimeSpan.FromHours(1));

            bool result = track.AddTalk(talk);

            Assert.IsTrue(result);

            Talk actualTalk = track.SpliceLastTalk();

            Assert.AreEqual(talk, actualTalk);

        }

        [TestMethod()]
        public void ToStringTest()
        {
            string textFilePath = "Input.txt";
            if (File.Exists(textFilePath))
            {
                Collection<Talk> allTalks = new Collection<Talk>();

                using (StreamReader streamReader = new StreamReader(textFilePath))
                {
                    string currentLine = null;
                    while ((currentLine = streamReader.ReadLine()) != null)
                    {
                        try
                        {
                            allTalks.Add(Talk.Init(currentLine));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine();
                        }
                    }
                }

                Collection<Track> tracks = TrackHelper.GenerateTracks(allTalks);
                foreach (var track in tracks)
                {
                    Assert.IsTrue(track.IsFull());
                }
            }
        }
    }
}
