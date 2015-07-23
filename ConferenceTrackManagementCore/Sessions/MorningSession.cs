using System;
using System.Linq;

namespace ConferenceTrackManagementCore
{
    public class MorningSession : Session
    {
        public MorningSession()
        {
            this.Start = TimeSpan.FromHours(9);
            this.End = TimeSpan.FromHours(12);
        }

        public override bool IsFull()
        {
            Talk lastTalk = Talks.LastOrDefault();
            return lastTalk != null && (lastTalk.End == this.End || lastTalk.IsLightning);
        }

        public override bool IsValid(Talk talk)
        {
            return talk.End <= this.End;
        }
    }
}
