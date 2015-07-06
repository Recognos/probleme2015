using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probleme
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select problem:");

            var problem = int.Parse(Console.ReadLine());

            switch(problem)
            {
                case 1:
                    Problem1.solve();
                    break;
                case 2:
                    Problem2.solve();
                    break;
                case 3:
                    Problem3.solve();
                    break;
                case 4:
                    Problem4.solve();
                    break;
                case 5:
                    Problem5.solve();
                    break;
                case 6:
                    Problem6.solve();
                    break;
                case 7:
                    Problem7.solve();
                    break;
                case 8:
                    Problem8.solve();
                    break;
                case 9:
                    Problem9.solve();
                    break;
            }
        }
    }
}
