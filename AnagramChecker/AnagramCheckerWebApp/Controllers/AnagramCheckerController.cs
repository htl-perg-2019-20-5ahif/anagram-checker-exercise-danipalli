using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnagramCheckerLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnagramCheckerWebApp.Controllers
{
    [ApiController]
    [Route("api")]
    public class AnagramCheckerController : ControllerBase
    {
        private readonly IDictionaryFileReader reader;
        private readonly IAnagramChecker comparer;

        public AnagramCheckerController(IDictionaryFileReader reader, IAnagramChecker comparer)
        {
            this.reader = reader;
            this.comparer = comparer;
        }

        [HttpGet]
        [Route("checkAnagram")]
        public IActionResult AnagramCheck([FromBody] Anagram anagram)
        {
            AnagramChecker checker = new AnagramChecker();
            if (checker.CheckTwoWords(anagram.W1, anagram.W2))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getKnownAnagrams")]
        public IActionResult KnownAnagramCheck([FromQuery] string w)
        {
            DictionaryFileReader reader = new DictionaryFileReader();
            var dictionaryText = reader.ReadDictionary();

            AnagramChecker checker = new AnagramChecker();

            var anagrams = checker.FindAnagrams(dictionaryText, w);

            if(anagrams.ToArray().Length == 0)
            {
                return NotFound();
            }

            return Ok(anagrams);
        }
    }
}
