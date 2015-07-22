using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceTrackManagement
{
    public class Talk
    {
        private double duration;
        private double start;
        private double end;
        private string title;
        private bool isLightning;
        public bool isProcessed;

        public bool IsLightning
        {
            get { return isLightning; }
            set { isLightning = value; }
        }

        public static Talk Init(string proposal)
        {
            var tempArray = proposal.Split(' ').ToList();
            string duration = tempArray.Last();
            double tempDuration = 0;
            tempArray.RemoveAt(tempArray.Count - 1);
            string tempTitle = string.Join(" ", tempArray);
            bool tempIsLightning = duration == "lightning";
            if (tempIsLightning)
            {
                tempDuration = 5;
            }
            else
            {
                tempDuration = double.Parse(duration.Replace("min", "")) / 60;
            }
            return new Talk(tempTitle, tempDuration, tempIsLightning);
        }

        public Talk(string title, double duration, bool isLightning = false)
        {
            this.title = title;
            this.duration = duration;
            this.isLightning = isLightning;
        }

        public double Duration
        {
            get { return duration; }
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

        public string Title
        {
            get { return title; }
        }

        public override string ToString()
        {
            return isLightning ? string.Format("{0} {1} lightning", GetStartTimeForDisplay(start), title)
                : string.Format("{0} {1} {2}min", GetStartTimeForDisplay(start), title, duration * 60);
        }

        private string GetStartTimeForDisplay(double start)
        {
            double h = (int)start;
            double m = (start - h) * 60;

            return string.Format("{0}:{1}", h, m);
        }
    }
}
