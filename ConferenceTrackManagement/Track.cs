using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceTrackManagement
{
    public class Track
    {
        private AfternoonSession afternoonSession;
        private MorningSession morningSession;
        private Talk lunch;
        private Talk networkEvent;       
        private double start;
        private double end;

        public Track()
        {
            this.start = 9;
            this.end = 17;
            this.morningSession = new MorningSession();
            this.afternoonSession = new AfternoonSession();
            this.lunch = new Talk("lunch", 1);
            this.lunch.Start = 12.0;
            this.networkEvent = new Talk("Networking Event", 0);
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

        public Talk Lunch
        {
            get { return lunch; }
        }

        public bool IsFull
        {
            get
            {
                return afternoonSession.IsFull() && morningSession.IsFull();
            }
        }

        public double Start
        {
            get { return start; }
            set { start = value; }
        }

        public double End
        {
            get { return end; }
            set { end = value; }
        }

        public Talk NetworkEvent
        {
            get { return networkEvent; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(MorningSession.ToString());
            sb.Append(lunch.ToString());
            sb.AppendLine(AfternoonSession.ToString());
            sb.AppendLine(networkEvent.ToString());

            return sb.ToString();
        }
    }
}
