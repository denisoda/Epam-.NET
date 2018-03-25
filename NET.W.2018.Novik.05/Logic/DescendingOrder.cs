using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DescendingOrder : IComparer<int>
    {
        int IComparer<int>.Compare(int x, int y)
        {
            if (x < y)
            {
                return 1;
            }

            if (x > y)
            {
                return -1;
            }

            return 0;
        }
    }
}
