using System;
using System.Text;

namespace ConferenceTrackManagementCore
{
    public class Track
    {
        private MorningSession morningSession;
        private Lunch lunch;
        private AfternoonSession afternoonSession;
        private NetworkingEvent networkEvent;

        public Track()
        {
            this.morningSession = new MorningSession();
            this.lunch = new Lunch();
            this.afternoonSession = new AfternoonSession();
            this.networkEvent = new NetworkingEvent();
        }

        public MorningSession MorningSession
        {
            get { return morningSession; }
        }

        public NetworkingEvent NetworkEvent
        {
            get { return networkEvent; }
        }

        public AfternoonSession AfternoonSession
        {
            get { return afternoonSession; }
        }

        public bool IsFull()
        {
            return afternoonSession.IsFull() && morningSession.IsFull();
        }

        public bool AddTalk(Talk currentTalk)
        {
            bool result = false;
            if (!MorningSession.IsFull())
            {
                result = MorningSession.AddTalk(currentTalk);
            }
            else
            {
                result = AfternoonSession.AddTalk(currentTalk);
            }

            if (!result)
            {
                currentTalk.Start = default(TimeSpan);
            }

            return result;
        }

        public Talk SpliceLastTalk()
        {
            Talk result = null;
            if (!MorningSession.IsFull())
            {
                result = MorningSession.SpliceLastTalk();
            }
            else
            {
                result = AfternoonSession.SpliceLastTalk();
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(MorningSession.ToString());
            sb.Append(lunch.ToString());
            sb.Append(AfternoonSession.ToString());
            sb.Append(networkEvent.ToString());

            return sb.ToString();
        }
    }
}
