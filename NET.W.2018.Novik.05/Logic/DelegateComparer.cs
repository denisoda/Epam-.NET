using System;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Adapts <see cref="Comparison{int}"/> to <see cref="IComparer{int}"/>
    /// </summary>
    public class DelegateComparer : IComparer<int>
    {
        #region Private fields

        private readonly Comparison<int> _delegate;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateComparer"/> class by <see cref="Comparison{int}"/>.
        /// </summary>
        /// <param name="delegateToCompare">The delegate to wrap in this class.</param>
        public DelegateComparer(Comparison<int> delegateToCompare)
        {
            if (delegateToCompare is null)
            {
                throw new ArgumentNullException(nameof(delegateToCompare));
            }

            this._delegate = delegateToCompare;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Compare two numbers.
        /// </summary>
        /// <param name="x">First number.</param>
        /// <param name="y">Second number.</param>
        /// <returns>
        /// If <paramref name="x"/> &gt; <paramref name="y"/> return 1.
        /// If <paramref name="x"/> = <paramref name="y"/> return 0.
        /// If <paramref name="x"/> &lt; <paramref name="y"/> return -1.
        /// </returns>
        public int Compare(int x, int y)
        {
            return this._delegate(x, y);
        }

        #endregion

    }
}
