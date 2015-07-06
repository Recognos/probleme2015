using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme
{
    // Given a file containing one word per line, print out all the combinations of words that are anagrams; 
    // each line in the output contains all the words from the input that are anagrams of each other.
    class Problem4
    {
        private static string path = "wordlist-problem4.txt";

        public static void solve()
        {
            Console.WriteLine("Problem 4");
            
            var dict = new Dictionary<int[], List<string>>(new IntArrayEqualityComparer());

            try
            {
                var srRead = new StreamReader(path);

                var line = srRead.ReadLine();

                while(line != null)
                {
                    var frequency = Utilities.CalculateFrequencyArray(line);

                    if (!dict.ContainsKey(frequency))
                        dict.Add(frequency, new List<string>());
                    
                    dict[frequency].Add(line);

                    line = srRead.ReadLine();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var pair in dict)
            {
                foreach (var value in pair.Value)
                    Console.Write(value + ' ');

                Console.WriteLine();
            }
        }
    }
}
