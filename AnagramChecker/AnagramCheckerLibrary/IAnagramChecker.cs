﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramCheckerLibrary
{
    public interface IAnagramChecker
    {
        bool CheckTwoWords(string word1, string word2);

        string SortAscending(string word);

        IEnumerable<string> FindAnagrams(string dictionaryText, string word);
    }
}
