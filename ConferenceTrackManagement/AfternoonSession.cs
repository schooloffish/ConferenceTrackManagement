using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceTrackManagement
{
    public class AfternoonSession
    {
        private Collection<Talk> talks;
        private double start;

        public double Start
        {
            get { return start; }
        }

        public double End
        {
            get { return Talks.LastOrDefault().End; }
        }

        public AfternoonSession()
        {
            this.start = 13;
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
            return lastTalk != null && (lastTalk.End == 17.0 || lastTalk.IsLightning);
        }

        public bool IsValid(Talk talk)
        {
            return talk.End <= 17;
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
