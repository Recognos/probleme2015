using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme
{
    // Convert a numeric string to integer (of float) without using any builtin conversion functions
    class Problem3
    {
        public static void solve()
        {
            Console.WriteLine("Problem 3");

            Console.WriteLine("Enter numeric string:");
            var sNumber = Console.ReadLine();

            foreach(var ch in sNumber)
                if(!char.IsDigit(ch) && ch != '.')
                {
                    Console.WriteLine("Invalid string.");
                    return;
                }

            var number = 0.0;
            var posDot = sNumber.IndexOf('.');

            if (posDot != -1)
            {
                number = StringToInt(sNumber.Substring(0, posDot));

                var floatingPart = 0.0;

                for (var i = sNumber.Length - 1; i > posDot; i--)
                    floatingPart = floatingPart / 10.0 + 0.1 * CharToInt(sNumber.ElementAt(i));

                number += floatingPart;
            }
            else
                number = StringToInt(sNumber);

            Console.WriteLine(number);
        }

        private static int StringToInt(string str)
        {
            var ret = 0;

            for (var i = 0; i < str.Length; i++)
                ret = ret * 10 + CharToInt(str.ElementAt(i));

            return ret;
        }

        private static int CharToInt(char ch)
        {
            return ch - '0';
        }
    }
}
