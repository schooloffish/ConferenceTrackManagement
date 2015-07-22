using System;
using System.Linq;

namespace ConferenceTrackManagementCore
{
    public class AfternoonSession : Session
    {
        public AfternoonSession()
        {
            this.Start = TimeSpan.FromHours(13);
        }

        public override bool IsFull()
        {
            Talk lastTalk = Talks.LastOrDefault();
            return lastTalk != null && (lastTalk.End == TimeSpan.FromHours(17) || lastTalk.IsLightning);
        }

        public override bool IsValid(Talk talk)
        {
            return talk.End <= TimeSpan.FromHours(17);
        }
    }
}
