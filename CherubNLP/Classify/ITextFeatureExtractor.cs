using Bigtree.Algorithm.Features;
using CherubNLP.Tokenize;
using System;
using System.Collections.Generic;
using System.Text;

namespace CherubNLP.Classify
{
    /// <summary>
    /// Featuring text
    /// </summary>
    public interface ITextFeatureExtractor
    {
        List<Feature> GetFeatures(List<Token> words);

    }
}
