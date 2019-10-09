using System;
using System.Collections;
using System.Collections.Generic;

namespace AnagramCheckerLibrary
{
    public class AnagramChecker : IAnagramChecker         // it's a ugly solution, but i had a very stressful week because of the prom and exam in german and the lightning talk
    {


        // Anagram checker -> checkd two different words
        // Anagram dictionary checker -> get all known anagrams from a dictionary
        // Anagram -> create all possible permutations
        public bool CheckTwoWords(string word1, string word2)
        {
            var word1Array = word1.ToLower().ToCharArray();
            var word2Array = word2.ToLower().ToCharArray();

            int[] alphatbetWord1 = new int[23];
            int[] alphatbetWord2 = new int[23];

            foreach (char letter in word1Array)
            {
                alphatbetWord1[letter - 97]++;
            }
            foreach (char letter in word2Array)
            {
                alphatbetWord2[letter - 97]++;
            }

            int counter = 0;
            foreach (int occurences in alphatbetWord1)
            {
                if(occurences != alphatbetWord2[counter])
                {
                    return false;
                }
                counter++;
            }

            return true;
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
