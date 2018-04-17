using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.UnitTests.Queue
{
    public class QueueViaLinkedList<T>
    {
        private LinkedList<T> list;

        public QueueViaLinkedList(int capacity)
        {
            list = new LinkedList<T>();
        }

        public void Enqueue(T obj)
        {
            this.list.AddLast(obj);
        }

        public void Dequeue()
        {
            if (this.list.Count <= 0)
            {
                throw new InvalidOperationException();
            }

            this.list.RemoveFirst();
        }
    }
}
