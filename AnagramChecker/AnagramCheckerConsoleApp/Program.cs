using AnagramCheckerLibrary;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;

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
                var config = new ConfigurationBuilder();
                config.AddJsonFile("config.json");
                config.AddEnvironmentVariables();
                var dictionaryReader = new DictionaryFileReader(config.Build());
                var dictionary = dictionaryReader.ReadDictionary();
                var key = new AnagramChecker().SortAscending(args[2]);

                if (dictionary.ContainsKey(key))
                {
                    foreach (var word in dictionary[key])
                    {
                        if (!word.Equals(args[2]))
                        {
                            Console.WriteLine(word);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No known anagrams found");
                }
                return;
            }

            Console.WriteLine("Please enter valid arguments.");
        }
    }
}
