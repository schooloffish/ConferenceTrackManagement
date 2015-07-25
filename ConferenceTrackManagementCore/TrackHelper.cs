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
            Collection<Track> resultTracks = new Collection<Track>();

            Queue<Talk> queue = new Queue<Talk>();
            foreach (var item in allTalks)
            {
                if (!item.IsLightning)
                    queue.Enqueue(item);
            }

            Track currentTrack = null;
            Talk mismatchedTalk = null;
            while (queue.Count > 0)
            {
                if (currentTrack != null && currentTrack.IsFull())
                {
                    currentTrack = null;
                }

                if (currentTrack == null)
                {
                    currentTrack = new Track();
                    resultTracks.Add(currentTrack);
                }

                Talk currentTalk = queue.Dequeue();

                if (!currentTrack.AddTalk(currentTalk))
                {
                    if (mismatchedTalk == currentTalk)
                    {
                        Talk lastTalk = currentTrack.SpliceLastTalk();
                        queue.Enqueue(lastTalk);
                        mismatchedTalk = null;
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
                Talk currentLightningTalk = queue.Dequeue();
                currentTrack = resultTracks.FirstOrDefault(t => !t.IsFull());
                if (currentTrack != null && currentTrack.AddTalk(currentLightningTalk))
                {
                    currentTrack.NetworkEvent.Start = new TimeSpan(17, 0, 0);
                }
            }

            foreach (var tempTrack in resultTracks)
            {
                if (tempTrack.NetworkEvent.Start.Equals(default(TimeSpan)))
                {
                    tempTrack.NetworkEvent.Start = tempTrack.AfternoonSession.LastTalk.End;
                }
            }

            return resultTracks;
        }

        public static string ToFormattedString(this TimeSpan start)
        {
            DateTime time = DateTime.ParseExact(start.ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);

            return time.ToString("hh:mmtt", CultureInfo.CreateSpecificCulture("en-us"));
        }
    }
}
