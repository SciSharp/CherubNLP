using CherubNLP.Classify;
using CherubNLP.Corpus;
using CherubNLP.Tokenize;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Bigtree.Algorithm.Extensions;

namespace CherubNLP.UnitTest.Kaggle
{
    [TestClass]
    public partial class KaggleTest : TestEssential
    {

        [TestMethod]
        public void SpookyAuthorIdentification()
        {
            var reader = new KaggleTextDataReader();
            var sentences = reader.Read(new ReaderOptions { FileName = "train.csv" });

            var tokenizer = new TokenizerFactory(new TokenizationOptions { }, SupportedLanguage.English);
            tokenizer.GetTokenizer<TreebankTokenizer>();

            var newSentences = tokenizer.Tokenize(sentences.Select(x => x.Text).ToList());
            for (int i = 0; i < newSentences.Count; i++)
            {
                newSentences[i].Id = sentences[i].Id;
                newSentences[i].Label = sentences[i].Label;
            }
            sentences = newSentences.ToList();

            sentences.Shuffle();
            var dataset = sentences.Take(2000).ToList().Split(0.7M);

            var options = new ClassifyOptions
            {
                ModelDir = AppContext.BaseDirectory,
                ModelFilePath = Path.Combine(AppContext.BaseDirectory, "nb.model"),
                Dimension = 300
            };
            var classifier = new ClassifierFactory<SentenceFeatureExtractor>(options, SupportedLanguage.English);
            classifier.GetClassifer("NaiveBayesClassifier");
            classifier.Train(dataset.Item1);

            int correct = 0;
            int total = 0;
            dataset.Item2.ForEach(td =>
            {
                var classes = classifier.Classify(td);
                if (td.Label == classes[0].Item1)
                {
                    correct++;
                }
                total++;
            });

            var accuracy = (float)correct / total;

            Assert.IsTrue(accuracy > 0.5);
        }

    }
}
