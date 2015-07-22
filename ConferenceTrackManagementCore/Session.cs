using System;
using System.Collections.ObjectModel;
using System.Text;

namespace ConferenceTrackManagementCore
{
    public abstract class Session
    {
        private Collection<Talk> talks;
        private TimeSpan start;
        private TimeSpan end;
        
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
