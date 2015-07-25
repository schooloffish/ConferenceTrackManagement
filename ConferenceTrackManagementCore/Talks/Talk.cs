using System;
using System.Linq;

namespace ConferenceTrackManagementCore
{
    public class Talk
    {
        private bool isLightning;
        private string title;
        private TimeSpan start;
        private TimeSpan duration;

        public static Talk Init(string proposal)
        {
            var tempArray = proposal.Split(' ').ToList();
            if (tempArray.Count > 1)
            {
                string durationText = tempArray.LastOrDefault().ToUpperInvariant();
                tempArray.RemoveAt(tempArray.Count - 1);

                string tempTitle = string.Join(" ", tempArray);
                TimeSpan duration = default(TimeSpan);

                bool tempIsLightning = durationText == "LIGHTNING";
                if (tempIsLightning)
                {
                    duration = TimeSpan.FromMinutes(5);
                }
                else
                {
                    int durationValue;
                    if (int.TryParse(durationText.Replace("MIN", ""), out durationValue))
                    {
                        duration = TimeSpan.FromMinutes(durationValue);
                    }
                    else
                    {
                        throw new InvalidCastException("'" + durationText + "'" + " contains invalid characters.");
                    }
                }
                return new Talk(tempTitle, duration, tempIsLightning);
            }
            else
            {
                throw new FormatException("Invalid proposal.");
            }
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
