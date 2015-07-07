using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme
{
    class Problem2
    {
        private static string str1 = "cat";
        private static string str2 = "dog";
        private static string pathWordlist = "wordlist-problem2.txt";

        public static void solve()
        {
            Console.WriteLine("Problem 2");

            var words = new List<string>();

            try
            {
                var srWords = new StreamReader(pathWordlist);
                var line = srWords.ReadLine();

                while(line != null)
                {
                    words.Add(line);
                    line = srWords.ReadLine();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(str1);

            var i = 0;

            while(!str1.Equals(str2))
            {
                if (str1[i] == str2[i])
                {
                    i = (i + 1) % str1.Length;
                    continue;
                }

                string str3;

                if (i > 0)
                    str3 = str1.Substring(0, i) + str2[i] + str1.Substring(i + 1);
                else
                    str3 = str2[i] + str1.Substring(1);

                if (words.Contains(str3))
                {
                    str1 = str3;
                    Console.WriteLine(str1);
                }

                i = (i + 1) % str1.Length;
            }
        }
    }
}
