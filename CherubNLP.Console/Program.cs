using CherubNLP.UnitTest.Kaggle;
using System;
using System.IO;

namespace CherubNLP.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var similarities = Similarity.Cosine("We can use Cosine to compute the similarity of two hardcoded lists.", new[]
            {
                "Cosine Similarity algorithm function sample.",
                "The Cosine Similarity function computes the similarity of two lists of numbers.",
                "Compute the similarity of two hardcoded lists.",
                "We can compute the similarity of two hardcoded lists.",
                "Coronavirus app could trace your contacts without sacrificing your privacy"
            }, Path.Combine(@"D:\SciSharp\CherubNLP\data", "dbpedia.ftz"));

            // var test = new KaggleTest();
            // test.SpookyAuthorIdentification();
        }
    }
}
