using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme
{
    // Implement a Secret Santa selection program. 
    // Given a file where each line looks like this : 
    // FIRST_NAME space FAMILY_NAME space newline your program should then choose 
    // a Secret Santa for every name in the list, and print in the console the results. 
    // Obviously, a person cannot be their own Secret Santa. 
    // (Optionally: the program will not allow people in the same family to be Santas for each other.)
    class Problem9
    {
        private static string path = "namelist-problem9.txt";

        public static void solve()
        {
            Console.WriteLine("Problem 9");

            var names = new List<Tuple<string, string>>();
            var familyNameFrequency = new Dictionary<string, int>();

            try
            {
                var reader = new StreamReader(path);

                var line = reader.ReadLine();

                while (line != null)
                {
                    var idxSpace = line.IndexOf(' ');
                    var firstName = line.Substring(0, line.IndexOf(' '));
                    var lastName = line.Substring(line.IndexOf(' '));

                    names.Add(new Tuple<string, string>(firstName, lastName));

                    if(!familyNameFrequency.ContainsKey(lastName))
                        familyNameFrequency.Add(lastName, 1);
                    else
                        familyNameFrequency[lastName]++;

                    line = reader.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if(names.Count % 2 != 0)
            {
                Console.WriteLine("Must have even number of people.");
                return;
            }

            foreach(var name in familyNameFrequency.Keys)
                if(familyNameFrequency[name] >= names.Count / 2)
                {
                    Console.WriteLine("Too many people named {0}", name);
                    return;
                }

            Random random = new Random();

            do
            {
                for (var i = names.Count - 1; i >= 1; i--)
                {
                    var j = random.Next() % i;

                    var aux = names[j];
                    names[j] = names[i];
                    names[i] = aux;
                }
            } while (isSameSurname(names));

            for(var i = 0;i < names.Count - 1;i++)
                Console.WriteLine(names[i] + " <=> " + names[i+1]);
        }

        private static bool isSameSurname(List<Tuple<string, string>> names)
        {
            for (var i = 0; i < names.Count - 1; i++)
                if (names[i].Item2.Equals(names[i + 1].Item2))
                    return true;

            return false;
        }
    }
}
