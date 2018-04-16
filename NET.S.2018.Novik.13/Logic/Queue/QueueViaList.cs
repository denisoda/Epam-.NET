using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Queue
{
    public class QueueViaList<T>
    {
        private List<T> list;

        public QueueViaList(int capacity)
        {
            list = new List<T>(capacity);
        }

        public void Enqueue(T obj)
        {
            this.list.Add(obj);
        }

        public void Dequeue()
        {
            if (this.list.Count <= 0)
            {
                throw new InvalidOperationException();
            }

            this.list.RemoveAt(0);
        }
    }
}
