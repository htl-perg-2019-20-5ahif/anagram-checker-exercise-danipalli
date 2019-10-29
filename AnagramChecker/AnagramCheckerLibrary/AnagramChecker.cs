using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AnagramCheckerLibrary
{
    public class AnagramChecker : IAnagramChecker
    {
        public bool CheckTwoWords(string word1, string word2)
        {
            return SortAscending(word1).Equals(SortAscending(word2));
        }

        public string SortAscending(string word)
        {
            return String.Concat(word.OrderBy(c => c));
        }

        public IEnumerable<string> FindAnagrams(string dictionaryText, string word)
        {
            var dictionaryLines = dictionaryText.Split('\n');

            string[] anagrams;
            foreach (string line in dictionaryLines)
            {
                anagrams = line.Split(';');
                foreach (string anagram in anagrams)
                {
                    if (anagram.Equals(word))
                    {
                        return anagrams;
                    }
                }
            }
            return default;
        }
    }
}
