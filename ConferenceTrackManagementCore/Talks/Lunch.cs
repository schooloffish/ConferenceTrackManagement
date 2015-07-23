﻿using System;
using System.Globalization;

namespace ConferenceTrackManagementCore
{
    public class Lunch : Talk
    {
        public Lunch()
            : base("Lunch", TimeSpan.FromHours(1))
        {
            this.Start = TimeSpan.FromHours(12);
        }

        public override string ToString()
        {
            DateTime time = DateTime.ParseExact(Start.ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);

            return string.Format("{0} {1}", time.ToString("hh:mmtt", CultureInfo.CreateSpecificCulture("en-us")), Title);
        }
    }
}