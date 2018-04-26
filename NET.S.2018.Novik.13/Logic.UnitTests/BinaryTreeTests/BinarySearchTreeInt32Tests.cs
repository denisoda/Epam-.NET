using System;
using System.Collections.Generic;
using Logic.BinaryTree;
using NUnit.Framework;

namespace Logic.UnitTests.BinaryTreeTests
{
    [TestFixture]
    class BinarySearchTreeInt32Tests
    {
        [Test]
        public void BinarySearchTreeInt32()
        {
            //BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            SortedSet<A> sortedSet = new SortedSet<A>(new A());
            sortedSet.Add(new A());
            sortedSet.Add(new A());
        }
    }

    class A : IComparer<A>
    {
        public int Compare(A x, A y)
        {
            return 1;
        }
    }
}
