using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// 
    /// </summary>
    class DelegateComparer : IComparer<int>
    {
        private Comparison<int> _delegate;

        public DelegateComparer(Comparison<int> delegateToCompare)
        {
            if (delegateToCompare is null)
            {
                throw new ArgumentNullException(nameof(delegateToCompare));
            }

            this._delegate = delegateToCompare;
        }

        public int Compare(int x, int y)
        {
            return this._delegate(x, y);
        }
    }
}
