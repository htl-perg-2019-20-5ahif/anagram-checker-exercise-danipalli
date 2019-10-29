using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace AnagramCheckerLibrary
{
    public class DictionaryFileReader : IDictionaryFileReader
    {
        private readonly IConfiguration config;

        public DictionaryFileReader(IConfiguration config)
        {
            this.config = config;
        }

        /// <summary>
        /// Reads the dictionary file
        /// </summary>
        /// <returns>Content of the dictionary file</returns>
        public Dictionary<string, List<string>> ReadDictionary()
        {
            var dictionary = new Dictionary<string, List<string>>();
            try
            {
                // Read the dictionary
                var path = config["dictionaryFileName"];
                var dictionaryText = File.ReadAllText(path);
                var dictionaryLines = dictionaryText.Replace("\r", "").Split('\n');

                foreach (var line in dictionaryLines)
                {
                    var words = line.Split(';');
                    if(words.Length > 0)
                    {
                        string key = new AnagramChecker().SortAscending(words[0]);
                        if (dictionary.ContainsKey(key))
                        {
                            foreach(string word in words)
                            {
                                if (!dictionary[key].Contains(word))
                                {
                                    dictionary[key].Add(word);
                                }
                            }
                        }
                        else
                        {
                            dictionary.Add(key, words.ToList());
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Dictionary not found!\n" + ex.ToString());
                throw;
            }
            return dictionary;
        }
    }
}
