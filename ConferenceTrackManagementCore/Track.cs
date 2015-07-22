using System;
using System.Text;

namespace ConferenceTrackManagementCore
{
    public class Track
    {
        private AfternoonSession afternoonSession;
        private MorningSession morningSession;
        private Lunch lunch;
        private NetworkingEvent networkEvent;
        private TimeSpan start;
        private TimeSpan end;

        public Track()
        {
            this.start = TimeSpan.FromHours(9);
            this.end = TimeSpan.FromHours(17);
            this.morningSession = new MorningSession();
            this.afternoonSession = new AfternoonSession();
            this.lunch = new Lunch();
            this.networkEvent = new NetworkingEvent();
        }

        public AfternoonSession AfternoonSession
        {
            get { return afternoonSession; }
            set { afternoonSession = value; }
        }

        public MorningSession MorningSession
        {
            get { return morningSession; }
            set { morningSession = value; }
        }

        public bool IsFull
        {
            get
            {
                return afternoonSession.IsFull() && morningSession.IsFull();
            }
        }

        public TimeSpan Start
        {
            get { return start; }
            set { start = value; }
        }

        public TimeSpan End
        {
            get { return end; }
            set { end = value; }
        }

        public NetworkingEvent NetworkEvent
        {
            get { return networkEvent; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(MorningSession.ToString());
            sb.AppendLine(lunch.ToString());
            sb.Append(AfternoonSession.ToString());
            sb.Append(networkEvent.ToString());

            return sb.ToString();
        }
    }
}
