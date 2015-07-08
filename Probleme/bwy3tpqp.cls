using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme
{
    class Problem9
    {
        private static string path = "namelist-problem9.txt";

        public static void solve()
        {
            Console.WriteLine("Problem 9");

            var names = new List<string>();

            try
            {
                var reader = new StreamReader(path);

                var line = reader.ReadLine();

                while(line != null)
                {
                    var idxSpace = line.IndexOf(' ');

                    names.Add(line);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            Random random = new Random();

            names.OrderBy(name => random.Next(names.Count));

            foreach (var name in names)
                Console.WriteLine(name);
        }
    }
}
