using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace ConferenceTrackManagementCore
{
    public static class TrackHelper
    {
        public static Collection<Track> GenerateTracks(Collection<Talk> allTalks)
        {
            Collection<Track> allTracks = new Collection<Track>();

            Queue<Talk> queue = new Queue<Talk>();
            foreach (var item in allTalks)
            {
                if (!item.IsLightning)
                    queue.Enqueue(item);
            }

            Track track = null;
            Talk mismatchedTalk = null;
            while (queue.Count > 0)
            {
                if (track != null && track.IsFull())
                {
                    track = null;
                }

                if (track == null)
                {
                    track = new Track();
                    allTracks.Add(track);
                }

                Talk currentTalk = queue.Dequeue();

                if (!track.AddTalk(currentTalk))
                {
                    if (mismatchedTalk == currentTalk)
                    {
                        Talk lastTalk = track.SpliceLastTalk();
                        queue.Enqueue(lastTalk);
                    }
                    else if (mismatchedTalk == null)
                    {
                        mismatchedTalk = currentTalk;
                    }
                    queue.Enqueue(currentTalk);
                }
            }

            foreach (var item in allTalks)
            {
                if (item.IsLightning)
                    queue.Enqueue(item);
            }

            while (queue.Count > 0)
            {
                Talk currentTalk = queue.Dequeue();
                var currentTrack = allTracks.FirstOrDefault(t => !t.IsFull());
                currentTalk.Start = currentTrack.AfternoonSession.LastTalk.End;
                currentTrack.AfternoonSession.AddTalk(currentTalk);
                currentTrack.NetworkEvent.Start = new TimeSpan(16, 30, 0);
            }

            foreach (var tempTrack in allTracks)
            {
                if (tempTrack.NetworkEvent.Start.Equals(default(TimeSpan)))
                {
                    tempTrack.NetworkEvent.Start = tempTrack.AfternoonSession.LastTalk.End;
                }
            }

            return allTracks;
        }

        public static string ToFormattedString(this TimeSpan start)
        {
            DateTime time = DateTime.ParseExact(start.ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);

            return time.ToString("hh:mmtt", CultureInfo.CreateSpecificCulture("en-us"));
        }
    }
}
