using System;
using System.Collections.Generic;
using System.Text;

namespace MyCognitiveApp
{
    public class FlaggedTokens
    {
        public int Offset { get; set; }
        public string Token { get; set; }
        public string Type { get; set; }
        public IList<SpellCheckSuggestion> Suggestions { get; set; }
    }
}
