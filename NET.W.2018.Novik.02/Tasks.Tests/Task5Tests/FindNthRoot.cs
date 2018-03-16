using System;
using NUnit.Framework;
using Tasks;

namespace Tasks.Tests.Task5Tests
{
    [TestFixture]
    class FindNthRoot
    {
        [Test]
        [TestCase(1, 5, 0.0001)]
        [TestCase(8, 3, 0.0001)]
        [TestCase(0.001, 3, 0.0001)]
        [TestCase(0.04100625, 4, 0.0001)]
        [TestCase(8, 3, 0.0001)]
        [TestCase(0.0279936, 7, 0.0001)]
        [TestCase(0.0081, 4, 0.1)]
        [TestCase(0.004241979, 9, 0.00000001)]
        public void FindNthRoot_CorrectValues(double n, int a, double eps)
        {
            double result = Task5.FindNthRoot(n, a, eps);
            Assert.IsTrue(Math.Abs(result - Math.Pow(n, 1.0 / a)) < eps);
        }

        [Test]
        [TestCase(1,-5, 0.0001)]
        [TestCase(-8, 4, 0.0001)]
        [TestCase(8, 3, -0.0001)]
        public void FindNthRoot_Numbers_Dergree_ArgumentException(double n, int a, double eps)
        {
            Assert.Throws<ArgumentException>(
                () => { Task5.FindNthRoot(n, a, eps); });
        }


    }
}
