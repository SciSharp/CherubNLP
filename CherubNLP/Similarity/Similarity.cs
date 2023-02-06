using FastText.NetWrapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tensorflow;
using Tensorflow.NumPy;
using static Tensorflow.Binding;
using static Tensorflow.KerasApi;

namespace CherubNLP
{
    public class Similarity
    {
        public static double[] Cosine(string src, string[] dst, string model)
        {
            using (var fastText = new FastTextWrapper())
            {
                fastText.LoadModel(model);
                var vector = fastText.GetSentenceVector(src.ToLower());
                return dst.Select(x => CalCosine(vector, fastText.GetSentenceVector(x.ToLower()))).ToArray();
            }
        }

        public static double CalCosine(NDArray vector1, NDArray vector2)
        {
            var cosine_loss = keras.losses.CosineSimilarity(axis: 0);
            return cosine_loss.Call(vector1, vector2).numpy();
        } 
    }
}
