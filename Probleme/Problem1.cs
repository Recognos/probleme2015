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
            var frequencySearch = CalculateFrequencyArray(sSearch);

            // Words that have common letters with the search string and their frequency vector
            var candidates = new Dictionary<string, int[]>();
            GetCandidates(frequencySearch, candidates);

            FindAnagrams(frequencySearch, candidates);
        }

        private static void GetCandidates(int[] frequencySearch, Dictionary<string, int[]> candidates)
        {
            try
            {
                var srWordlist = new StreamReader(sFilename);
                var line = srWordlist.ReadLine();

                while (line != null)
                {
                    var frequency = CalculateFrequencyArray(line);

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

            Console.WriteLine("Candidates:" + candidates.Count);
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
                    var added = AddArrays(pair1.Value, pair2.Value);

                    if (Enumerable.SequenceEqual(frequencySearch, added))
                    {
                        anagrams.Add(pair.Key, pair.Value);
                        Console.WriteLine(pair.Key + ' ' + pair.Value);
                    }
                }
        }

        private static int[] AddArrays(int[] a, int[] b)
        {
            var ret = new int[Math.Max(a.Length, b.Length)];

            Array.Clear(ret, 0, ret.Length);

            for (var i = 0; i < ret.Length; i++)
            {
                if (i < a.Length)
                    ret[i] += a[i];

                if (i < b.Length)
                    ret[i] += b[i];
            }

            return ret;
        }

        private static int[] CalculateFrequencyArray(string source)
        {
            // ret[ch] == instances of letter ch in source
            var ret = new int['z' - 'a' + 1];

            Array.Clear(ret, 0, ret.Length);

            foreach (var ch in source.ToCharArray())
                if (Char.IsLetter(ch))
                    ret[Char.ToLower(ch) - 'a']++;

            // Debugging code
            var debug = false;

            if (debug)
            {
                Console.Write(source + " -> ");

                for (var i = 0; i < ret.Length; i++)
                    if (ret[i] > 0)
                        Console.Write((char)('a' + i));
                Console.WriteLine();
            }

            return ret;
        }
    }
}
