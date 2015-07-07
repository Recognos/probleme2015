using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme
{
    // Given an input string and a dictionary of words, segment the input string 
    // into a space-separated sequence of dictionary words if possible. 
    // For example, if the input string is "applepie" and dictionary contains a standard set of English words, 
    // then we would return the string "apple pie" as output.
    class Problem5
    {
        private static string sFilename = "wordlist-problem1.txt";

        public static void solve()
        {
            Console.WriteLine("Problem 5");

            Console.WriteLine("Enter word to break:");

            var word = Console.ReadLine();
            var candidates = GetCandidates(sFilename, Utilities.CalculateFrequencyArray(word));
            var found = false;

            var start = 0;
            var end = start + 1;

            var brokenWord = new List<string>();

            for (; end < word.Length; end++)
            {
                var part = word.Substring(start, end - start + 1);

                if (candidates.Contains(part))
                {
                    brokenWord.Add(part);

                    start = end + 1;
                    found = true;
                }
            }

            if (!found || start < end)
                Console.WriteLine("Cannot break word.");
            else
            {
                foreach (string part in brokenWord)
                    Console.Write(part + ' ');
                Console.WriteLine();
            }
        }

        private static List<string> GetCandidates(string sFilename, int[] frequencySearch)
        {
            var ret = new List<string>();

            try
            {
                var reader = new StreamReader(sFilename);

                // TODO filter so we obtain only relevant (similar) words

                var line = reader.ReadLine();

                while(line != null)
                {
                    ret.Add(line);

                    line = reader.ReadLine();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ret;
        }
    }
}
