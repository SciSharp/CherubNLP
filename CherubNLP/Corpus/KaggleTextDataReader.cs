using CherubNLP.Tokenize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CherubNLP.Corpus
{
    /// <summary>
    /// A corpus reader for Kaggle-style files.  These files consist of a
    /// series of sentences, separated by blank lines.Each sentence is
    /// encoded using a table(or "grid") of values, where each line
    /// corresponds to a single word, and each column corresponds to an
    /// annotation type.The set of columns used by Kaggle-style files can
    /// vary from corpus to corpus;
    /// </summary>
    public class KaggleTextDataReader
    {
        public List<Sentence> Read(ReaderOptions options)
        {
            if (String.IsNullOrEmpty(options.DataDir))
            {
                options.DataDir = AppContext.BaseDirectory;
            }

            var sentences = new List<Sentence>();
            using(StreamReader reader = new StreamReader(Path.Combine(options.DataDir, options.FileName)))
            {
                // skip header
                string line = reader.ReadLine();
                line = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var id = line.Substring(1, 7);
                    var label = line.Substring(line.Length - 4, 3);
                    var text = line.Substring(11, line.Length - 18);

                    sentences.Add(new Sentence
                    {
                        Id = id,
                        Text = text,
                        Label = label
                    });

                    line = reader.ReadLine();
                }
                
            }

            return sentences;
        }
    }
}
