using System;
using System.Collections;
using System.Collections.Generic;

namespace Logic.Queue
{
    /// <summary>
    /// Queue's enumeration.
    /// </summary>
    /// <typeparam name="T">Type elements in array.</typeparam>
    public class QueueEnumerator<T> : IEnumerator<T>
    {
        #region private fields

        private T[] aggregate;
        private int tailQueue;
        private int headQueue;
        private int countQueue;
        private int position;
        private int count;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueEnumerator{T}"/> class.
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
            this.tailQueue = tail;
            this.headQueue = head;
            this.countQueue = count;
            this.position = head - 1;
            this.count = 0;
        }

        #endregion

        #region Properties

        private bool IsEndAggreagte => this.position == this.aggregate.Length - 1;

        #endregion

        #region Implementation IEnumerator

        public T Current => this.aggregate[this.position];

        object IEnumerator.Current => (object)this.aggregate[this.position];

        public void Dispose()
        {
            this.aggregate = null;
        }

        public bool MoveNext()
        {
            if (this.count >= this.countQueue)
            {
                return false;
            }

            if (this.IsEndAggreagte)
            {
                this.position = -1;
            }

            this.position++;
            this.count++;

            return true;
        }

        public void Reset()
        {
            this.position = this.tailQueue;
            this.count = 0;
        }

        #endregion
    }
}
