using System;

namespace ConferenceTrackManagementCore
{
    public class NetworkingEvent : Talk
    {
        public NetworkingEvent()
            : base("Networking Event", default(TimeSpan))
        {
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", GetStartTimeForDisplay(Start), Title);
        }
    }
}
