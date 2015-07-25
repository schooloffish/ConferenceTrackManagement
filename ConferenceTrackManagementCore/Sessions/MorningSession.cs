using System;

namespace ConferenceTrackManagementCore
{
    public class MorningSession : Session
    {
        public MorningSession()
        {
            Start = TimeSpan.FromHours(9);
            End = TimeSpan.FromHours(12);
        }

        public override bool IsFull()
        {
            return LastTalk != null && (LastTalk.End == End || LastTalk.IsLightning);
        }

        public override bool IsValid(Talk talk)
        {
            return talk.End <= End;
        }
    }
}
