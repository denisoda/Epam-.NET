﻿using System;
using NUnit.Framework;
using Tasks;

namespace Tasks.Tests.Task1Tests.NUnit
{
    [TestFixture]
    class InsertNublerTest
    {
        [Test]
        [TestCase(15, 15, 0, 0, 15)]
        [TestCase(8, 15, 0, 0, 9)]
        [TestCase(8, 15, 3, 8, 120)]
        public void InsertNumber_InputCorrectValues_NUnit(int source, int insert, int j, int i, int expected)
        {
            //Act
            int result = Task1.InsertNumber(source, insert, j, i);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(8, 15, -1, 0)]
        [TestCase(15, 15, 10, 9)]
        [TestCase(8, 15, 32, 32)]
        public void InsertNumber_InputWrongValues_Exception_NUnit(int source, int insert, int j, int i)
        {
            //Assert
            Assert.Throws<ArgumentException>(() => Task1.InsertNumber(source, insert, j, i));
        }
    }
}
