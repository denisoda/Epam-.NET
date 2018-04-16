using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Queue;
using NUnit.Framework;

namespace Logic.UnitTests.Queue
{
    [TestFixture]
    class QueueViaWiseArrayTests
    {
        [Test]
        public void QueueViaWiseArray_Enqueue_Succed()
        {
            QueueViaWiseArray<int> queue = new QueueViaWiseArray<int>();
            queue.Enqueue(10);
            queue.Enqueue(5);
            int[] expected = { 10, 5 };
            bool result = expected.SequenceEqual(queue);

            Assert.IsTrue(result);
        }

        [Test]
        public void QueueViaWiseArray_Dequeue_Succed()
        {
            QueueViaWiseArray<int> queue = new QueueViaWiseArray<int>();
            queue.Enqueue(10);
            queue.Enqueue(5);
            int result = queue.Dequeue();
            int expected = 10;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void QueueViaWiseArray_Count()
        {
            QueueViaWiseArray<int> queue = new QueueViaWiseArray<int>();
            queue.Enqueue(10);
            queue.Enqueue(5);
            QueueViaWiseArray<int> emptyQueue = new QueueViaWiseArray<int>();

            Assert.AreEqual(queue.Count, 2);
            Assert.AreEqual(emptyQueue.Count, 0);
        }

        [Test]
        public void QueueViaWiseArray_Clear()
        {
            QueueViaWiseArray<int> queue = new QueueViaWiseArray<int>();
            queue.Enqueue(10);
            queue.Enqueue(5);
            queue.Clear();

            Assert.AreEqual(queue.Count, 0);
        }

        [Test]
        public void QueueViaWiseArray_Peek()
        {
            QueueViaWiseArray<int> queue = new QueueViaWiseArray<int>();
            queue.Enqueue(10);
            queue.Enqueue(5);
            int oldCount = queue.Count;
            int result = queue.Peek();
            int expected = 10;
            int newCount = queue.Count;

            Assert.AreEqual(expected, result);
            Assert.AreEqual(oldCount, newCount);
        }

        [Test]
        public void QueueViaWiseArray_IEnumerable()
        {
            QueueViaWiseArray<int> queue = new QueueViaWiseArray<int>();
            queue.Enqueue(10);
            queue.Enqueue(5);
            queue.Enqueue(3);

            int[] expected = { 10, 5, 3 };

            Assert.IsTrue(expected.SequenceEqual(queue));
        }

        [Test]
        public void QueueViaWiseArray_Empty_InvalidOperationException()
        {
            QueueViaWiseArray<int> queue = new QueueViaWiseArray<int>();
            Assert.Throws<InvalidOperationException>(
                () => queue.Dequeue());
        }

        [Test]
        public void QueueViaWiseArray_Capacity_Less_1_ArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new QueueViaWiseArray<string>(-1));
        }
    }
}
