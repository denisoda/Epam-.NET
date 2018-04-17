using System;
using System.Collections;
using System.Collections.Generic;

namespace Logic.Queue
{
    /// <summary>
    /// Queue's enumeration.
    /// </summary>
    /// <typeparam name="T">Type elements in array.</typeparam>
    public struct QueueEnumerator<T> : IEnumerator<T>
    {
        #region private fields

        private readonly T[] aggregate;
        private readonly int queueTail;
        private readonly int queueHead;
        private readonly int queueCount;
        private int currentIndex;
        private int currentCount;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueEnumerator{T}"/> structure.
        /// </summary>
        /// <param name="aggregate">The array to enum.</param>
        /// <param name="tail">The tail of a queue.</param>
        /// <param name="head">The head of a queue.</param>
        /// <param name="count">Count elements in a queue.</param>
        public QueueEnumerator(T[] aggregate, int tail, int head, int count)
        {
            if (aggregate is null)
            {
                throw new ArgumentNullException(nameof(aggregate));
            }

            this.aggregate = aggregate;
            this.queueTail = tail;
            this.queueHead = head;
            this.queueCount = count;
            this.currentIndex = head - 1;
            this.currentCount = 0;
        }

        #endregion

        #region Properties

        private bool IsEndAggreagte => this.currentIndex == this.aggregate.Length - 1;

        #endregion

        #region Implementation IEnumerator

        public T Current
        {
            get
            {
                if (this.currentIndex == -1 || this.currentIndex == this.queueCount)
                {
                    throw new InvalidOperationException();
                }

                return this.aggregate[this.currentIndex];
            }
        }

        object IEnumerator.Current => (object)this.aggregate[this.currentIndex];

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (this.currentCount >= this.queueCount)
            {
                return false;
            }

            if (this.IsEndAggreagte)
            {
                this.currentIndex = -1;
            }

            this.currentIndex++;
            this.currentCount++;

            return true;
        }

        public void Reset()
        {
            this.currentIndex = this.queueTail;
            this.currentCount = 0;
        }

        #endregion
    }
}
