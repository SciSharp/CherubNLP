using CherubNLP.Stem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CherubNLP.UnitTest
{
    [TestClass]
    public class RegexStemmerTest
    {
        [TestMethod]
        public void StemInDefault()
        {
            var stemmer = new StemmerFactory<RegexStemmer>(new StemOptions
            {
                Pattern = RegexStemmer.PATTERN
            }, SupportedLanguage.English);

            var stem = stemmer.Stem("doing");
            Assert.IsTrue(stem == "do");

            stem = stemmer.Stem("ponies");
            Assert.IsTrue(stem == "poni");

            stem = stemmer.Stem("caresses");
            Assert.IsTrue(stem == "caress");

            stem = stemmer.Stem("cats");
            Assert.IsTrue(stem == "cat");

            stem = stemmer.Stem("am");
            Assert.IsTrue(stem == "be");

            stem = stemmer.Stem("are");
            Assert.IsTrue(stem == "be");

            stem = stemmer.Stem("is");
            Assert.IsTrue(stem == "be");

            stem = stemmer.Stem("were");
            Assert.IsTrue(stem == "be");

            stem = stemmer.Stem("running");
            Assert.IsTrue(stem == "run");
        }
    }
}
