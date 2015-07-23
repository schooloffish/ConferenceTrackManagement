using System;
using System.Globalization;
using System.Linq;

namespace ConferenceTrackManagementCore
{
    public class Talk
    {
        private string title;
        private TimeSpan start;
        private TimeSpan duration;
        private bool isLightning;

        public static Talk Init(string proposal)
        {
            var tempArray = proposal.Split(' ').ToList();
            string duration = tempArray.LastOrDefault();
            tempArray.RemoveAt(tempArray.Count - 1);
            string tempTitle = string.Join(" ", tempArray);
            TimeSpan tempDuration = default(TimeSpan);

            bool tempIsLightning = duration == "lightning";
            if (tempIsLightning)
            {
                tempDuration = TimeSpan.FromMinutes(5);
            }
            else
            {
                tempDuration = TimeSpan.FromMinutes(int.Parse(duration.Replace("min", "")));
            }
            return new Talk(tempTitle, tempDuration, tempIsLightning);
        }

        public Talk(string title, TimeSpan duration, bool isLightning = false)
        {
            this.title = title;
            this.duration = duration;
            this.isLightning = isLightning;
        }

        public TimeSpan Duration
        {
            get { return duration; }
        }

        public TimeSpan Start
        {
            get { return start; }
            set { start = value; }
        }

        public TimeSpan End
        {
            get
            {
                return Start.Add(Duration);
            }
        }

        public string Title
        {
            get { return title; }
        }

        public bool IsLightning
        {
            get { return isLightning; }
        }

        public override string ToString()
        {


            return isLightning ? string.Format("{0} {1} lightning", start.ToFormattedString(), title)
                : string.Format("{0} {1} {2}min", start.ToFormattedString(), title, duration.TotalMinutes);
        }

    }
}
