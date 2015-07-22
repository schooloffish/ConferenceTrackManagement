using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceTrackManagement
{
    public class MorningSession
    {
        private Collection<Talk> talks;
        private double start;
        private double end;

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

        public MorningSession()
        {
            this.start = 9;
            this.end = 12;
            this.talks = new Collection<Talk>();
        }

        public Collection<Talk> Talks
        {
            get { return talks; }
            set { talks = value; }
        }

        public bool IsFull()
        {
            Talk lastTalk = Talks.LastOrDefault();
            return lastTalk != null && (lastTalk.End == 12.0 || lastTalk.IsLightning);
        }

        public bool IsValid(Talk talk)
        {
            return talk.End <= 12;
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
