using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Probleme
{
    class IntArrayEqualityComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            for (var i = 0; i < Math.Min(x.Length, y.Length); i++)
                if (x[i] != y[i])
                    return false;

            return true;
        }

        public int GetHashCode(int[] obj)
        {
            return 0;
        }
    }
}
