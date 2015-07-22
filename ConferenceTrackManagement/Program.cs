using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace ConferenceTrackManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFilePath = "Input.txt";
            if (File.Exists(textFilePath))
            {
                Collection<Talk> allTalks = new Collection<Talk>();

                using (StreamReader streamReader = new StreamReader(textFilePath))
                {
                    string currentLine = null;
                    while ((currentLine = streamReader.ReadLine()) != null)
                    {
                        try
                        {
                            allTalks.Add(Talk.Init(currentLine));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine();
                        }
                    }
                }

                GenerateTracks(allTalks);
            }
        }

        private static void GenerateTracks(Collection<Talk> allTalks)
        {
            var track1 = NewMethod(allTalks);

            foreach (Track item in track1)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine("=============================================");
            }
            Console.Read();
        }

        private static Collection<Track> NewMethod(Collection<Talk> allTalks)
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

                if (!track.MorningSession.IsFull())
                {
                    if (track.MorningSession.Talks.Count == 0)
                    {
                        currentTalk.Start = track.MorningSession.Start;
                        currentTalk.End = currentTalk.Start + currentTalk.Duration;
                        track.MorningSession.Talks.Add(currentTalk);
                    }
                    else
                    {
                        Talk lastTalkInTrack = track.MorningSession.Talks.Last();
                        currentTalk.Start = lastTalkInTrack.End;
                        currentTalk.End = currentTalk.Start + currentTalk.Duration;
                        if (track.MorningSession.IsValid(currentTalk))
                        {
                            track.MorningSession.Talks.Add(currentTalk);
                        }
                        else
                        {
                            if (mightNeedToBeRemovedTalk == null)
                            {
                                mightNeedToBeRemovedTalk = currentTalk;
                                currentTalk.Start = 0;
                                currentTalk.End = 0;
                                queue.Enqueue(currentTalk);
                                continue;
                            }

                            if (mightNeedToBeRemovedTalk == currentTalk)
                            {
                                Talk lastTalk = track.MorningSession.Talks.Last();
                                lastTalk.Start = 0;
                                lastTalk.End = 0;
                                track.MorningSession.Talks.RemoveAt(track.MorningSession.Talks.Count - 1);
                                queue.Enqueue(lastTalk);
                            }

                            currentTalk.Start = 0;
                            currentTalk.End = 0;
                            queue.Enqueue(currentTalk);
                        }
                    }
                }
                else
                {
                    if (track.AfternoonSession.Talks.Count == 0)
                    {
                        currentTalk.Start = track.AfternoonSession.Start;
                        currentTalk.End = currentTalk.Start + currentTalk.Duration;
                        track.AfternoonSession.Talks.Add(currentTalk);
                    }
                    else
                    {
                        Talk lastTalkInTrack = track.AfternoonSession.Talks.Last();
                        currentTalk.Start = lastTalkInTrack.End;
                        currentTalk.End = currentTalk.Start + currentTalk.Duration;
                        if (track.AfternoonSession.IsValid(currentTalk))
                        {
                            track.AfternoonSession.Talks.Add(currentTalk);
                        }
                        else
                        {
                            currentTalk.Start = 0;
                            currentTalk.End = 0;
                            queue.Enqueue(currentTalk);
                        }
                    }
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
                currentTrack.NetworkEvent.Start = 17;
            }

            return allTracks;
        }
    }
}
