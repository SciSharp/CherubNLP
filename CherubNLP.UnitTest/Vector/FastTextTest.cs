using FastText.NetWrapper;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NumSharp;

namespace CherubNLP.UnitTest.Vector
{
    [TestClass]
    public class FastTextTest : TestEssential
    {
        [TestMethod]
        public void Word2Vec()
        {
            using (var fastText = new FastTextWrapper())
            {
                fastText.LoadModel(Path.Combine(dataDir, "dbpedia.ftz"));
                var vector = fastText.GetSentenceVector("Can I use a larger crockpot than the recipe calls for?");
            }
        }

        [TestMethod]
        public void CosineSimilarity()
        {
            var similarities = Similarity.Cosine("We can use Cosine to compute the similarity of two hardcoded lists.", new[]
            {
                "Cosine Similarity algorithm function sample.",
                "The Cosine Similarity function computes the similarity of two lists of numbers.",
                "Compute the similarity of two hardcoded lists.",
                "We can compute the similarity of two hardcoded lists.",
                "Coronavirus app could trace your contacts without sacrificing your privacy"
            }, Path.Combine(dataDir, "dbpedia.ftz"));

            Assert.AreEqual(new[] { 0, 4, 1, 3, 2 }, np.argsort<double>(similarities));
        }
    }
}
