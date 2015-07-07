using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme
{
    // Write a program that generates all two-word (from the attached wordlist.txt) anagrams of the string "documenting".
    class Problem1
    {
        private static string sFilename = "wordlist-problem1.txt";
        private static string sSearch = "documenting";

        public static void solve()
        {
            Console.WriteLine("Problem 1");

            // Frequency vector of the search string
            var frequencySearch = Utilities.CalculateFrequencyArray(sSearch);

            // Words that have common letters with the search string and their frequency vector
            var candidates = new Dictionary<string, int[]>();
            candidates = GetCandidates(sFilename, frequencySearch);

            FindAnagrams(frequencySearch, candidates);
        }

        private static Dictionary<string, int[]> GetCandidates(string sFilename, int[] frequencySearch)
        {
            var candidates = new Dictionary<string, int[]>();

            try
            {
                var srWordlist = new StreamReader(sFilename);
                var line = srWordlist.ReadLine();

                while (line != null)
                {
                    var frequency = Utilities.CalculateFrequencyArray(line);

                    for (var i = 0; i < frequency.Length; i++)
                        if (frequency[i] > 0)
                            if (frequencySearch[i] == 0)
                                break;
                            else
                                if (frequencySearch[i] <= frequency[i])
                                    if (!candidates.ContainsKey(line))
                                        candidates.Add(line, frequency);

                    line = srWordlist.ReadLine();
                }

                srWordlist.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return candidates;
        }

        private static void FindAnagrams(int[] frequencySearch, Dictionary<string, int[]> candidates)
        {
            Console.WriteLine("Anagrams of '{0}':", sSearch);

            var anagrams = new Dictionary<string, string>();

            foreach (KeyValuePair<string, int[]> pair1 in candidates)
                foreach (KeyValuePair<string, int[]> pair2 in candidates)
                {
                    if (pair1.Key.Equals(pair2.Key) ||
                        pair1.Key.Length + pair2.Key.Length != sSearch.Length ||
                        anagrams.ContainsKey(pair2.Key))
                        continue;

                    var pair = new KeyValuePair<string, string>(pair1.Key, pair2.Key);
                    var added = Utilities.AddArrays(pair1.Value, pair2.Value);

                    if (Enumerable.SequenceEqual(frequencySearch, added))
                    {
                        anagrams.Add(pair.Key, pair.Value);
                        Console.WriteLine(pair.Key + ' ' + pair.Value);
                    }
                }
        }
    }
}
