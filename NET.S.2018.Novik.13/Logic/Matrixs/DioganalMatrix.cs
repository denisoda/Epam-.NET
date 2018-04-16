using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Matrixs
{
    /// <summary>
    /// Provides methods to work with the dioganal matrix.
    /// </summary>
    /// <typeparam name="T">Type elements in dioganal matrix.</typeparam>
    public class DioganalMatrix<T> : SquareMatrix<T>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DioganalMatrix{T}"/> class.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If size less than 1.
        /// </exception>
        /// <param name="size">Size of the <see cref="DioganalMatrix{T}"/>.</param>
        public DioganalMatrix(int size)
            : base(size)
        {
        }

        #endregion

        #region properties

        /// <summary>
        /// The indexer for the <see cref="DioganalMatrix{T}"/>.
        /// </summary>
        /// <param name="i">The row index.</param>
        /// <param name="j">The column index.</param>
        /// <exception cref="IndexOutOfRangeException">
        /// If <paramref name="i"/> or <paramref name="j"/> outside of size.
        /// If indexs are not on main dioganal.
        /// </exception>
        /// <returns>The element of <see cref="DioganalMatrix{T}"/>.</returns>
        public override T this[int i, int j]
        {
            get
            {
                if (!this.VerifyIndex(i, j))
                {
                    throw new IndexOutOfRangeException();
                }

                return this.container[i, j];
            }

            set
            {
                if (!this.VerifyIndex(i, j))
                {
                    throw new IndexOutOfRangeException();
                }

                if (!this.IsDioganal(i, j))
                {
                    throw new IndexOutOfRangeException("indexs must be on main dioganal.");
                }

                this.OnChangeValue(new ChangeElementMatrixEventArgs<T>(i, j, this.container[i, j], value));
                this.container[i, j] = value;
            }
        }

        #endregion

        #region private methods

        private bool IsDioganal(int i, int j) => i == j;

        #endregion
    }
}
