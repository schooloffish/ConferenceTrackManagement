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
            this.talks = new Collection<Talk>();
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

        public Collection<Talk> Talks
        {
            get { return talks; }
        }

        public abstract bool IsValid(Talk talk);
        public abstract bool IsFull();

        public Talk SpliceLastTalk()
        {
            Talk lastTalk = this.Talks.Last();
            lastTalk.Start = default(TimeSpan);
            this.Talks.RemoveAt(this.Talks.Count - 1);

            return lastTalk;
        }

        public bool AddTalk(Talk newTalk)
        {
            bool result = false;
            Talk lastTalkInTrack = Talks.LastOrDefault();

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
                Talks.Add(newTalk);
                result = true;
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
