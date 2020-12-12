using FastText.NetWrapper;
using NumSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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

        public static double CalCosine(float[] vector1, float[] vector2)
        {
            double a = np.dot(vector1, vector2);
            if (a == 0) return 0;

            double b = np.sqrt(np.sum(np.square(vector1))) * np.sqrt(np.sum(np.square(vector2)));
            if (b == 0) return 0;

            return a / b;
        } 
    }
}
