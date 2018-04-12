using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Logic.UnitTests
{
    [TestFixture]
    class BinarySearchTests
    {
        [Test]
        public void BinarySearch_1Element_NotFound_Succed()
        {
            int[] number = { 0 };
            Assert.AreEqual(BinarySearch.Search<int>(number, 21), -1);
        }

        [Test]
        public void BinarySearch_EmptyArray_Succed()
        {
            int[] number = { };
            Assert.AreEqual(BinarySearch.Search<int>(number, 21), -1);
        }

        [Test]
        public void BinarySearch_DefaultComparer_Succed()
        {
            int[] number = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765 };
            Assert.AreEqual(BinarySearch.Search<int>(number, 21), 8);
        }

        [Test]
        public void BinarySearch_CustomComparer_Succed()
        {
            char[] strs = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();
            Assert.AreEqual(BinarySearch.Search<char>(strs, 'я', new CharCompareIgnoreCase()), 32);
        }

        [Test]
        public void BinarySerach_TypeNotImpelemntation_IComparer_ArgumentException()
        {
            Point[] points = { new Point() { X = 10, Y = 10 }, new Point() { X = 5, Y = 1 } };
            Point elementToFind = new Point() { X = 5, Y = 1 };

            Assert.Throws<ArgumentException>(
                () => BinarySearch.Search<Point>(points, elementToFind));
        }

        [Test]
        public void BinarySerach_Arguments_Null_ArgumentNullException()
        { 
            Point elementToFind = new Point() { X = 5, Y = 1 };

            Assert.Throws<ArgumentNullException>(
                () => BinarySearch.Search<Point>(null, elementToFind));
        }

        #region Inner types

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        class CharCompareIgnoreCase : IComparer<char>
        {
            public int Compare(char x, char y)
            {
                char xUpper = char.ToUpper(x);
                char yUpper = char.ToUpper(y);

                if (xUpper == yUpper)
                {
                    return 0;
                }

                if (xUpper > yUpper)
                {
                    return 1;
                }

                return -1;
            }
        }

        #endregion
    }
}
