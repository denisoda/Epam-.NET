using System;
using System.Collections.Generic;

namespace Logic.Matrixs
{
    /// <summary>
    /// Provides methods to work with the symmetrical matrix.
    /// </summary>
    /// <typeparam name="T">Type elements in simmetrical matrix.</typeparam>
    public class SymmetricalMatrix<T> : SquareMatrix<T>
        where T : IComparable<T>
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricalMatrix{T}"/> class.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If size less than 1.
        /// </exception>
        /// <param name="size">Size of the <see cref="SymmetricalMatrix{T}"/>.</param>
        public SymmetricalMatrix(int size)
                : base(size)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricalMatrix{T}"/> class that contains elements copied from the specified matrix.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="array"/> is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If size less than 1.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="array"/> is not a square matrix.
        /// If <paramref name="matrix"/> is not a symmetrical matrix.
        /// </exception>
        /// <param name="array">The specified matrix.</param>
        public SymmetricalMatrix(T[,] matrix)
            : base(matrix)
        {
            if (!this.IsSymmetrical(matrix))
            {
                throw new ArgumentException($"{matrix} must be a symmetrical matrix.");
            }
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

                this.OnChangeValue(new ChangeElementMatrixEventArgs<T>(i, j, this.container[i, j], value));
                this.container[i, j] = value;
                base[j, i] = value;
            }
        }

        #endregion

        #region private methods

        private bool IsSymmetrical(T[,] array)
        {
            for (int i = 0; i < this.container.GetLength(0); i++)
            {
                for (int j = 0; j < this.container.GetLength(1); j++)
                {
                    if (array[i, j].CompareTo(array[j, i]) != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion
    }
}
