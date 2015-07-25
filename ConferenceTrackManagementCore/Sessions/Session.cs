using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ConferenceTrackManagementCore
{
    public abstract class Session
    {
        private TimeSpan start;
        private TimeSpan end;
        private Collection<Talk> talks;

        public Session()
        {
            talks = new Collection<Talk>();
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

        public Talk LastTalk
        {
            get { return talks.LastOrDefault(); }
        }

        public abstract bool IsValid(Talk talk);

        public abstract bool IsFull();

        public Talk SpliceLastTalk()
        {
            Talk lastTalk = LastTalk;
            if (lastTalk != null)
            {
                lastTalk.Start = default(TimeSpan);
                talks.RemoveAt(talks.Count - 1);
            }
            return lastTalk;
        }

        public bool AddTalk(Talk newTalk)
        {
            bool result = false;
            Talk lastTalkInTrack = talks.LastOrDefault();

            if (lastTalkInTrack == null)
            {
                newTalk.Start = Start;
            }
            else
            {
                newTalk.Start = lastTalkInTrack.End;
            }

            if (IsValid(newTalk))
            {
                talks.Add(newTalk);
                result = true;
            }
            else
            {
                newTalk.Start = default(TimeSpan);
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var talk in talks)
            {
                sb.AppendLine(talk.ToString());
            }

            return sb.ToString();
        }
    }
}
