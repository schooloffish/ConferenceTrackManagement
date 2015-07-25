using ConferenceTrackManagementCore;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace ConferenceTrackManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                ReadTextFileGenerateTracks(args[0]);
            }
            else if (args.Length == 0)
            {
                string textFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Input.txt");
                ReadTextFileGenerateTracks(textFilePath);
            }
            else
            {
                Console.WriteLine(Properties.Resources.Usage);
            }
        }

        private static void ReadTextFileGenerateTracks(string textFilePath)
        {
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
                            allTalks.Add(Talk.Load(currentLine));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }

                PrintTracks(allTalks);
            }
            else
            {
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, Properties.Resources.FileNotExistMessage, textFilePath));
            }
            Console.Read();
        }

        private static void PrintTracks(Collection<Talk> allTalks)
        {
            var tracks = TrackHelper.GenerateTracks(allTalks);
            for (int i = 0; i < tracks.Count; i++)
            {
                Console.WriteLine(string.Format("Track {0}:", (i + 1).ToString()));
                Console.WriteLine(tracks[i].ToString());
            }
        }
    }
}
