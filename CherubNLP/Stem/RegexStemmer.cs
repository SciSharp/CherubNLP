/*
 * CherubNLP Library
 * Copyright (C) 2018 Haiping Chen
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CherubNLP.Tokenize;

namespace CherubNLP.Stem
{
    /// <summary>
    /// A stemmer that uses regular expressions to identify morphological affixes.
    /// Any substrings that match the regular expressions will be removed.
    /// </summary>
    public class RegexStemmer : IStemmer
    {
        static string _pattern;
        public static string PATTERN => GetPattern();

        static Regex _regex;

        static Dictionary<string, string> replacements = new Dictionary<string, string>();

        private static string GetPattern()
        {
            if (string.IsNullOrEmpty(_pattern))
            {
                replacements["nning"] = "n"; // running
                replacements["pping"] = "p"; // skipping
                replacements["tting"] = "t"; // putting
                replacements["able"] = "";
                replacements["were"] = "be";
                replacements["sses"] = "ss";
                replacements["ies"] = "i";
                replacements["are"] = "be";
                replacements["ing"] = "";
                replacements["am"] = "be";
                replacements["es"] = "";
                replacements["is"] = "be";
                replacements["s"] = "";

                _pattern = string.Join("$|", replacements.Keys) + "$";

                _regex = new Regex(_pattern);
            }

            return _pattern;
        }

        public string Stem(string word, StemOptions options)
        {
            var match = _regex.Matches(word).Cast<Match>().FirstOrDefault();

            return match == null ?
                word :
                word.Substring(0, match.Index) + replacements[match.Value];
        }
    }
}
