using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme
{
    // Converting Arabic to Roman: We would like to be able to convert Arabic numbers into their Roman numeral equivalents. 
    // We just need some kind of program that can accept a numeric input and output the Roman numeral for the input number.
    class Problem6
    {
        public static void solve()
        {
            Console.WriteLine("Problema 6");

            Console.WriteLine("Enter Arabic number:");

            var line = Console.ReadLine();

            if(string.IsNullOrEmpty(line))
            {
                Console.WriteLine("Null string entered.");
                return;
            }

            foreach(var ch in line)
                if(!char.IsDigit(ch))
                {
                    Console.WriteLine("Input must be formed exclusively by digits.");
                    return;
                }

            var number = int.Parse(line);

            var dictRoman = new Dictionary<int, string>()
            {
                {1000, "M"}, 
                {900, "CM"}, 
                {500, "D"}, 
                {400, "CD"}, 
                {100, "C"}, 
                {90, "XC"},  
                {50, "L"}, 
                {40, "XL"}, 
                {10, "X"}, 
                {9, "IX"}, 
                {5, "V"},
                {4, "IV"}, 
                {1, "I"}
            };

            Console.WriteLine("Roman representation:");

            while(number > 0)
            {
                foreach(var pair in dictRoman)
                    while(number >= pair.Key)
                    {
                        number -= pair.Key;
                        Console.Write(pair.Value);
                    }
            }

            Console.WriteLine();
        }
    }
}
