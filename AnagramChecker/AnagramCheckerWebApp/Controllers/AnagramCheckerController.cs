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
        private readonly IDictionaryFileReader _reader;
        private readonly IAnagramChecker _comparer;
        private readonly ILogger<AnagramCheckerController> _logger;

        public AnagramCheckerController(IDictionaryFileReader reader, IAnagramChecker comparer, ILogger<AnagramCheckerController> logger)
        {
            _reader = reader;
            _comparer = comparer;
            _logger = logger;
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
            var dictionary = _reader.ReadDictionary();
            var key = _comparer.SortAscending(w);

            if (dictionary.ContainsKey(key))
            {
                List<string> words = new List<string>();
                foreach (var word in dictionary[key])
                {
                    if (!word.Equals(w))
                    {
                        words.Add(word);
                    }
                }
                return Ok(words);
            }
            else
            {
                _logger.LogInformation("No anagram found for word \"" + w + "\"");
                return NotFound();
            }
        }
    }
}
