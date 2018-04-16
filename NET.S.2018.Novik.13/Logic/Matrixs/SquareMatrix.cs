using System;
using System.Collections;
using System.Collections.Generic;

namespace Logic.Matrixs
{
    /// <summary>
    /// Provides the methods to work with square matrix.
    /// </summary>
    /// <typeparam name="T">Type elements of square matrix.</typeparam>
    public class SquareMatrix<T> : IEnumerable<T>
    {
        #region fields

        protected readonly T[,] container;
        protected int _size;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If size less than 1.
        /// </exception>
        /// <param name="size">Size of the <see cref="SquareMatrix{T}"/>.</param>
        public SquareMatrix(int size)
        {
            this.Size = size;
            this.container = new T[this.Size, this.Size];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class that contains elements copied from the specified matrix.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="array"/> is null.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If size less than 1.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// If <paramref name="array"/> is not a square matrix.
        /// </exception>
        /// <param name="array">The specified matrix.</param>
        public SquareMatrix(T[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.GetLength(0) != array.GetLength(1))
            {
                throw new ArgumentException($"{nameof(array)} must be square matrix.");
            }

            this.Size = array.GetLength(0);
            this.container = array;
        }

        #endregion

        #region properties

        public event EventHandler<ChangeElementMatrixEventArgs<T>> ChangeValue;

        /// <summary>
        /// Size of the matrix.
        /// </summary>
        public int Size
        {
            get
            {
                return this._size;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be greater than 0.");
                }

                this._size = value;
            }
        }

        /// <summary>
        /// Returns a copy matrix.
        /// </summary>
        public T[,] Matrix
        {
            get
            {
                T[,] copy = new T[this.container.GetLength(0), this.container.GetLength(1)];
                Array.Copy(this.container, copy, this.container.GetLength(0) + this.container.GetLength(1));
                return copy;
            }
        }

        /// <summary>
        /// The indexer for the <see cref="SquareMatrix{T}"/>.
        /// </summary>
        /// <param name="i">The row index.</param>
        /// <param name="j">The column index.</param>
        /// <exception cref="IndexOutOfRangeException">
        /// If <paramref name="i"/> or <paramref name="j"/> outside of size.
        /// </exception>
        /// <returns>The element of <see cref="SquareMatrix{T}"/>.</returns>
        public virtual T this[int i, int j]
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

                this.container[i, j] = value;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through matrix.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.container.GetLength(0); i++)
            {
                for (int j = 0; j < this.container.GetLength(1); j++)
                {
                    yield return this[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.container.GetEnumerator();
        }

        #endregion

        #region public methods

        protected virtual void OnChangeValue(ChangeElementMatrixEventArgs<T> eventArgs)
        {
            this.ChangeValue?.Invoke(this, eventArgs);
        }

        #endregion

        #region private methods

        protected bool VerifyIndex(int i, int j) => i < this.Size && j < this.Size;

        #endregion
    }
}
