using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MusicBrainz;
using MusicBrainz.Data;

namespace xmlparsing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("XML Parsing crash demo program.");
            Console.WriteLine("We'll fetch Metallica from MusicBrainz XML API.");
            Console.WriteLine("Press any key to start.");
            Console.ReadKey();

            string artistName = "Lofofora";
            Console.WriteLine("Now parsing {0}, this should NOT crash in either clr.", artistName);
            IEnumerable<ArtistData>  mbArtists = GetArtist(artistName);
            if (mbArtists != null)
                Console.WriteLine("* Found: {0}", mbArtists.First().Name);

            Console.WriteLine("");
            Console.WriteLine("------------");
            Console.WriteLine("");

            artistName = "Metallica";
            Console.WriteLine("Now parsing {0}, this SHOULD crash in .NET 4.51.", artistName);
            // This will crash when using CLR, but not when using CoreCLR
            mbArtists = GetArtist(artistName);
            if (mbArtists != null)
                Console.WriteLine("* Found: {0}", mbArtists.First().Name);

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();

        }

        private static IEnumerable<ArtistData> GetArtist(string artistName)
        {
            return MusicBrainz.Search.Artist(WebUtility.UrlEncode(artistName)).Data;
        }

    }
}
