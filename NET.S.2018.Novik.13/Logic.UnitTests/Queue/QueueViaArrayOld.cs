using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Logic.UnitTests.Queue
{
    public class QueueViaArrayOld : IEnumerable<string>
    {
        private int capacity { get; set; }
        private int head = 0;
        private int tail = -1;

        private int _count = 0;
        public int Count { get => this._count; }

        private string[] array;

        public QueueViaArrayOld(int capacity = 10)
        {
            this.capacity = capacity;
            this.array = new string[this.capacity];
        }

        public void Enqueue(string value)
        {
            if (array.Length - 1 < this.tail + 1)
            {
                if (this.head > 0) // если есть место сбоку , то сделать сдвиг
                {
                    this.array = CopyArray(this.array, this.head, this._count, this.array.Length);
                    this.head = 0;
                    this.tail = this._count - 1;
                }
                else // иначе расширить массив на какое-то число
                {
                    Array.Resize<string>(ref this.array, array.Length + this.capacity);
                }
            }

            this.array[++tail] = value;
            this._count++;
        }

        private string[] CopyArray(string[] array, int start, int count, int lengthNewArray)
        {
            string[] newArray = new string[lengthNewArray];
            for (int i = 0, j = start; i < Count; i++, j++)
            {
                newArray[i] = array[j];
            }
            return newArray;
        }

        public string Dequeue()
        {
            if (this.IsEmpty()) throw new ArgumentOutOfRangeException("в очереди нет элементов");
            string result = this.array[this.head];
            this._count--;
            this.array[this.head++] = null;
            if (this.head == this.array.Length)
            {
                this.head = 0;
                this.tail = -1;
            }
            return result;
        }

        public bool IsEmpty() => this._count == 0;

        #region IEnumerable

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            for (int i = this.head; i <= this.tail; i++)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
