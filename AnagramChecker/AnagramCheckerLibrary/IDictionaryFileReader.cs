using System;
using System.Collections.Generic;
using System.Text;

namespace AnagramCheckerLibrary
{
    public interface IDictionaryFileReader
    {
        Dictionary<string, List<string>> ReadDictionary();
    }
}
