using System;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// This class implementation <see cref="IComparer{int}"/> to determine sort's order.
    /// </summary>
    public class DescendingOrder : IComparer<int>
    {
        int IComparer<int>.Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
}
