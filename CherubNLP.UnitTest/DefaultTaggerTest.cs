using CherubNLP.Corpus;
using CherubNLP.Tag;
using CherubNLP.Tokenize;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CherubNLP.UnitTest
{
    [TestClass]
    public class DefaultTaggerTest
    {
        [TestMethod]
        public void TagInCoNLL2000()
        {
            var tokenizer = new TokenizerFactory(new TokenizationOptions { }, SupportedLanguage.English);
            tokenizer.GetTokenizer<RegexTokenizer>();

            var tokens = tokenizer.Tokenize("How are you doing?");

            var tagger = new TaggerFactory(new TagOptions
            {
                Tag = "NN"
            }, SupportedLanguage.English);

            tagger.GetTagger<DefaultTagger>();

            tagger.Tag(new Sentence { Words = tokens });
        }
    }
}