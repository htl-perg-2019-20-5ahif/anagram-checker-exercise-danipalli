using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramCheckerLibrary
{
    public class Anagram
    {
        public string W1 { get; set; }
        public string W2 { get; set; }

        public Anagram()
        {
        }

        public Anagram(string w1, string w2)
        {
            W1 = w1;
            W2 = w2;
        }
    }
}
