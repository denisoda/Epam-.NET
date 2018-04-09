using System;
using System.Collections.Generic;

namespace Logic
{
    public class DescendingOrder : IComparer<int>
    {
        int IComparer<int>.Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
}
