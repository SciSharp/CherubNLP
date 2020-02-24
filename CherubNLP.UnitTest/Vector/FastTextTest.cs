using CherubNLP.Txt2Vec;
using FastText.NetWrapper;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Txt2Vec;

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
    }
}
