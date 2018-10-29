using CherubNLP.UnitTest.Kaggle;
using System;

namespace CherubNLP.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new KaggleTest();
            test.SpookyAuthorIdentification();
        }
    }
}
