using AnagramCheckerLibrary;
using Microsoft.Extensions.Configuration;
using System;

namespace AnagramCheckerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 2 || !args[0].Equals("AnagramChecker"))
            {
                Console.WriteLine("Please enter valid arguments.");
                return;
            }

            if (args[1].Equals("check") && args.Length == 4)
            {
                AnagramChecker checker = new AnagramChecker();
                if(checker.CheckTwoWords(args[2], args[3]))
                {
                    Console.WriteLine(args[2] + " and " + args[3] + "are anagrams");
                }
                else
                {
                    Console.WriteLine(args[2] + " and " + args[3] + "are no anagrams");
                }
                return;
            }

            if (args[1].Equals("getKnown") && args.Length == 3)
            {
                DictionaryFileReader reader = new DictionaryFileReader();
                var dictionaryText = reader.ReadDictionary();

                AnagramChecker checker = new AnagramChecker();

                var anagrams = checker.FindAnagrams(dictionaryText, args[2]);

                bool found = false;
                foreach (string anagram in anagrams)
                {
                    found = true;
                    Console.WriteLine(anagram);
                }

                if(!found)
                {
                    Console.WriteLine("No known anagrams found");
                }
                return;
            }
        }

        //private static IConfigurationBuilder GetConfiguration()
        //{
        //    var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");
        //    return new ConfigurationBuilder()
        //        .AddJsonFile("appsettings.json")
        //        .AddJsonFile($"appsettings.{environmentName}.json", true)
        //        .AddEnvironmentVariables();
        //}
    }
}
