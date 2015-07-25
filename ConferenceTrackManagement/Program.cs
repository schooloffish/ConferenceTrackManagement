using ConferenceTrackManagementCore;
using System;
using System.Collections.ObjectModel;
using System.IO;

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

                PrintTracks(allTalks);
            }
        }

        private static void PrintTracks(Collection<Talk> allTalks)
        {
            var tracks = TrackHelper.GenerateTracks(allTalks);
            for (int i = 0; i < tracks.Count; i++)
            {
                Console.WriteLine(string.Format("Track {0}:", (i + 1).ToString()));
                Console.WriteLine(tracks[i].ToString());
            }
            Console.Read();
        }
    }
}
