using CherubNLP.Tokenize;
using System;
using System.Collections.Generic;
using System.Text;

namespace CherubNLP
{
    public class Sentence
    {
        // User defined id
        public string Id { get; set; }

        public List<Token> Words { get; set; }

        public String Label { get; set; }

        public String Text { get; set; }

        public double[] Vector { get; set; }
    }
}
