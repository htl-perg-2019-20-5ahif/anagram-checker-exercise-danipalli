using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AnagramCheckerLibrary
{
    public class DictionaryFileReader : IDictionaryFileReader
    {
        //private readonly IConfiguration config;

        //public DictionaryFileReader(IConfiguration config)
        //{
        //    this.config = config;
        //}

        /// <summary>
        /// Reads the dictionary file
        /// </summary>
        /// <returns>Content of the dictionary file</returns>
        public string ReadDictionary()
        {
            string dictionaryText;
            try
            {
                // Read the dictionary
                var dictFile = "dictionary.csv"; //config["dictionaryFileName"];
                dictionaryText = File.ReadAllText(dictFile);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Dictionary not found!\n" + ex.ToString());
                throw;
            }

            return dictionaryText;
        }
    }
}
