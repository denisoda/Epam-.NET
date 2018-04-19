using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Diagnostics;
using Logic.Queue;

namespace Logic.UnitTests.Queue
{
    [TestFixture]
    public class QueueCompareTimeTests
    {
        [Test]
        public void QueueViaWiseArrayTests_Time()
        {
            QueueViaWiseArray<string> queue = new QueueViaWiseArray<string>(2);

            Stopwatch stopwatch = Stopwatch.StartNew();

            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Dequeue();
            queue.Enqueue("C");
            queue.Enqueue("D");
            //for (int i = 0; i < 10000; i++)
            //{
            //    queue.Enqueue("A");
            //}

            //for (int i = 0; i < 1000; i++)
            //{
            //    queue.Dequeue();
            //}

            //for (int i = 0; i < 500; i++)
            //{
            //    queue.Enqueue("A");
            //}         
            stopwatch.Stop();

            Assert.Pass(stopwatch.Elapsed.ToString());

        }

        [Test]
        public void QueueViaLinkedList_Time()
        {
            QueueViaLinkedList<string> queue = new QueueViaLinkedList<string>(5);
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                queue.Enqueue("A");
            }

            for (int i = 0; i < 1000; i++)
            {
                queue.Dequeue();
            }

            for (int i = 0; i < 500; i++)
            {
                queue.Enqueue("A");
            }
            stopwatch.Stop();

            Assert.Pass(stopwatch.Elapsed.ToString());
        }

        [Test]
        public void QueueViaArray_Time()
        {
            QueueViaArrayOld queue = new QueueViaArrayOld(5);
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                queue.Enqueue("A");
            }

            for (int i = 0; i < 1000; i++)
            {
                queue.Dequeue();
            }

            for (int i = 0; i < 500; i++)
            {
                queue.Enqueue("A");
            }
            stopwatch.Stop();

            Assert.Pass(stopwatch.Elapsed.ToString());
        }

        [Test]
        public void QueueNative_Time()
        {
            Queue<string> queue = new Queue<string>(5);
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                queue.Enqueue("A");
            }

            for (int i = 0; i < 1000; i++)
            {
                queue.Dequeue();
            }

            for (int i = 0; i < 500; i++)
            {
                queue.Enqueue("A");
            }
            stopwatch.Stop();

            Assert.Pass(stopwatch.Elapsed.ToString());
        }

    }
}
