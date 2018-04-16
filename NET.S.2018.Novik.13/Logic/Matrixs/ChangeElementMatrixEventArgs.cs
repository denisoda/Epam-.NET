using System;

namespace Logic.Matrixs
{
    /// <summary>
    ///  Provides data for the <see cref="SquareMatrix{T}.ChangeValue"/> events.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ChangeElementMatrixEventArgs<T> : EventArgs
    {
        #region fileds

        public readonly int i;
        public readonly int j;
        public readonly T OldValue;
        public readonly T NewValue;

        #endregion

        #region constructors

        public ChangeElementMatrixEventArgs(int i, int j, T oldValue, T newValue)
        {
            this.i = i;
            this.j = j;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }

        #endregion
    }
}
