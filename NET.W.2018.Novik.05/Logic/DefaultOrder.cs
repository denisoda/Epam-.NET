using System;
using System.Collections.Generic;

namespace Logic
{
    public class DefaultOrder : IComparer<int>
    {
        int IComparer<int>.Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }
}
