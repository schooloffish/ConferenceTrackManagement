using System;
using System.Globalization;
using System.Linq;

namespace ConferenceTrackManagementCore
{
    public class Talk
    {
        private TimeSpan duration;
        private TimeSpan start;
        private string title;
        private bool isLightning;       

        public static Talk Init(string proposal)
        {
            var tempArray = proposal.Split(' ').ToList();
            string duration = tempArray.Last();
            TimeSpan tempDuration = default(TimeSpan);
            tempArray.RemoveAt(tempArray.Count - 1);
            string tempTitle = string.Join(" ", tempArray);
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
            set { isLightning = value; }
        }

        public override string ToString()
        {
            return isLightning ? string.Format("{0} {1} lightning", GetStartTimeForDisplay(start), title)
                : string.Format("{0} {1} {2}min", GetStartTimeForDisplay(start), title, duration.TotalMinutes);
        }

        public string GetStartTimeForDisplay(TimeSpan start)
        {
            DateTime time = DateTime.ParseExact(start.ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);

            return time.ToString("hh:mmtt", CultureInfo.CreateSpecificCulture("en-us"));
        }
    }
}
