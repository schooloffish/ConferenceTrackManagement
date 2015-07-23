using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ConferenceTrackManagementCore
{
    public class Track
    {
        private AfternoonSession afternoonSession;
        private MorningSession morningSession;
        private Lunch lunch;
        private NetworkingEvent networkEvent;

        public Track()
        {
            this.morningSession = new MorningSession();
            this.lunch = new Lunch();
            this.afternoonSession = new AfternoonSession();
            this.networkEvent = new NetworkingEvent();
        }

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
            Talk mightNeedToBeRemovedTalk = null;
            while (queue.Count > 0)
            {
                if (track != null && track.IsFull)
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
                    if (mightNeedToBeRemovedTalk == currentTalk)
                    {
                        Talk lastTalk = track.MorningSession.SpliceLastTalk();
                        queue.Enqueue(lastTalk);
                    }
                    else if (mightNeedToBeRemovedTalk == null)
                    {
                        mightNeedToBeRemovedTalk = currentTalk;
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
                var currentTrack = allTracks.FirstOrDefault(t => !t.IsFull);
                currentTalk.Start = currentTrack.AfternoonSession.Talks.Last().End;
                currentTrack.AfternoonSession.Talks.Add(currentTalk);
                currentTrack.NetworkEvent.Start = new TimeSpan(16,30,0);
            }

            foreach (var tempTrack in allTracks)
            {
                if (tempTrack.NetworkEvent.Start.Equals(default(TimeSpan)))
                {
                    tempTrack.NetworkEvent.Start = tempTrack.AfternoonSession.Talks.Last().End;
                }
            }

            return allTracks;
        }

        public AfternoonSession AfternoonSession
        {
            get { return afternoonSession; }
        }

        public MorningSession MorningSession
        {
            get { return morningSession; }
        }
        
        public NetworkingEvent NetworkEvent
        {
            get { return networkEvent; }
        }

        public bool IsFull
        {
            get
            {
                return afternoonSession.IsFull() && morningSession.IsFull();
            }
        }

        public bool AddTalk(Talk currentTalk)
        {
            bool result = false;
            if (!MorningSession.IsFull())
            {
                result = MorningSession.AddTalk(currentTalk);
            }
            else
            {
                result = AfternoonSession.AddTalk(currentTalk);
            }

            if (!result)
            {
                currentTalk.Start = default(TimeSpan);
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(MorningSession.ToString());
            sb.AppendLine(lunch.ToString());
            sb.Append(AfternoonSession.ToString());
            sb.Append(networkEvent.ToString());

            return sb.ToString();
        }
    }
}
