using CherubNLP.UnitTest.Kaggle;
using FastText.NetWrapper;
using System;
using System.IO;

namespace CherubNLP.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = Path.Combine(@"D:\SciSharp\CherubNLP\data", "dbpedia.bin");
            using (var fastText = new FastTextWrapper())
            {
                fastText.LoadModel(model);
                var vector1 = fastText.GetSentenceVector("Hello");
            }

            var similarities = Similarity.Cosine("Power Outage -Fifth & Park - JPMC150713", new[]
            {
                "Cosine Similarity algorithm function sample.",
                "Power Restored -Fifth & Park - JPMC150713",
                "Compute the similarity of two hardcoded lists.",
                "We can compute the similarity of two hardcoded lists.",
                "Coronavirus app could trace your contacts without sacrificing your privacy"
            }, model);

            // var test = new KaggleTest();
            // test.SpookyAuthorIdentification();
        }
    }
}
