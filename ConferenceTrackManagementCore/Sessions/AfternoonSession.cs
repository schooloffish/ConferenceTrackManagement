using System;

namespace ConferenceTrackManagementCore
{
    public class AfternoonSession : Session
    {
        public AfternoonSession()
        {
            Start = TimeSpan.FromHours(13);
        }

        public override bool IsFull()
        {
            return LastTalk != null && (LastTalk.End == TimeSpan.FromHours(17) || LastTalk.IsLightning);
        }

        public override bool IsValid(Talk talk)
        {
            return talk.IsLightning || talk.End <= TimeSpan.FromHours(17);
        }
    }
}
