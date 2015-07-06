using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme
{
    public static class Utilities
    {
        public static int[] AddArrays(int[] a, int[] b)
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

        public static int[] CalculateFrequencyArray(string source)
        {
            // ret[ch] == instances of letter ch in source
            var ret = new int['z' - 'a' + 1];

            Array.Clear(ret, 0, ret.Length);

            foreach (var ch in source.ToCharArray())
                if (Char.IsLetter(ch))
                    ret[Char.ToLower(ch) - 'a']++;

            // Debugging code
            var debug = 0;

            if (debug != 0)
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
