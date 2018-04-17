using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Queue
{
    /// <summary>
    /// Represents a first-in, first-out collection of <typeparamref name="T"/> based the wise array.
    /// </summary>
    /// <typeparam name="T">Type elements in the queue.</typeparam>
    public class QueueViaWiseArray<T> : IEnumerable<T>
    {
        #region private fields

        private T[] container = { };
        private int head = 0;
        private int tail = -1;
        private int _count = 0;
        private int capacity = 1;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueViaWiseArray{T}"/> class.
        /// </summary>
        public QueueViaWiseArray()
            : this(1)
        {
            //TODO: add default capacity.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueViaWiseArray{T}"/> class.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <paramref name="capacity"/> less 1.
        /// </exception>
        /// <param name="capacity">Default value capacity.</param>
        public QueueViaWiseArray(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(capacity)} must be greater than 0");
            }

            this.container = new T[capacity];
            this.capacity = capacity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueViaWiseArray{T}"/> class by the sequence of elements the same type.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="sequence"/> is null.
        /// </exception>
        /// <param name="sequence">The sequence of elements the same type.</param>
        public QueueViaWiseArray(IEnumerable<T> sequence)
        {
            if (sequence is null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }

            this.container = sequence.ToArray();
        }

        #endregion

        #region Properties

        public int Count => this._count;

        public bool IsEmpty => this.Count == 0;

        private bool IsEnoughSpace => this._count + 1 <= this.container.Length;

        private bool TailInTheEnd => this.tail + 1 > this.container.Length - 1;

        #endregion

        #region Public methods

        /// <summary>
        /// Adds element to the end of the <see cref="QueueViaWiseArray{T}"/>.
        /// </summary>
        /// <param name="obj">The element to add.</param>
        public void Enqueue(T obj)
        {
            //TODO: do less.

            if (this.IsEnoughSpace)
            {
                if (this.TailInTheEnd)
                {
                    this.tail = -1;
                }
            }
            else
            {
                if (this.tail < this.head)
                {
                    this.ExtendsContainerInMiddle(ref this.container, this.capacity);
                    this.head = this.head + this.capacity;
                }
                else
                {
                    this.ExtendsContainerRigthSide(ref this.container, this.capacity);
                }
            }

            this.tail++;
            this._count++;
            this.container[this.tail] = obj;
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the Queue.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// If this queue is empty.
        /// </exception>
        /// <returns>First element in this queue.</returns>
        public T Dequeue()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            if (this.head > this.container.Length - 1)
            {
                this.head = 0;
            }

            T result = this.container[this.head];
            this.container[this.head] = default(T);
            this.head++;
            this._count--;

            return result;
        }

        /// <summary>
        /// Removes all objects from the <see cref="QueueViaWiseArray{T}"/>
        /// </summary>
        public void Clear()
        {
            this.container = new T[this.capacity];
            this.tail = -1;
            this.head = 0;
            this._count = 0;
        }

        /// <summary>
        /// Returns the object at the beginning of the <see cref="QueueViaWiseArray{T}"/> without removing it.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// If the Queue is empty.
        /// </exception>
        /// <returns>The object at the beginning of the Queue.</returns>
        public T Peek()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return this.container[this.head];
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            T[] copyContainer = new T[this.container.Length];
            Array.Copy(this.container, copyContainer, copyContainer.Length);

            return new QueueEnumerator<T>(copyContainer, this.tail, this.head, this._count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            T[] copyContainer = new T[this.container.Length];
            Array.Copy(this.container, copyContainer, copyContainer.Length);

            return new QueueEnumerator<T>(copyContainer, this.tail, this.head, this._count);
        }

        #endregion

        #region Private methods

        private void ExtendsContainerInMiddle(ref T[] array, int capacity)
        {
            T[] newArray = new T[array.Length + capacity];
            int indexOldArray = 0;
            int indexNewArray = 0;

            while (indexOldArray < array.Length)
            {
                if (indexOldArray - 1 == this.tail)
                {
                    indexNewArray = indexNewArray + capacity;
                }

                newArray[indexNewArray] = array[indexOldArray];
                indexOldArray++;
                indexNewArray++;
            }

            array = newArray;
        }

        private void ExtendsContainerRigthSide(ref T[] array, int capacity)
        {
            Array.Resize(ref array, array.Length + capacity);
        }

        #endregion

    }
}
