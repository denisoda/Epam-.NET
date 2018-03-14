using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorts;
using System.Linq;

namespace Tests
{
    /// <summary>
    /// Tests Sorts.SortsHelper.cs
    /// </summary>
    [TestClass]
    public class SortsHelperTests
    {

        [TestMethod]
        public void MegreSort_InputArrayIntegerNumbers_SortedArrayReturned()
        {
            //Arrange
            int[] arrExpected = new int[] { 1, 2, 3, 4, 5, 6 };
            int[] arrInput = new int[] { 1, 4, 3, 5, 6, 2 };

            //Act
            arrInput = SortsHelper.MergerSort(arrInput);

            //Assert
            Assert.IsTrue(arrExpected.SequenceEqual(arrInput));
        }



        [TestMethod]
        public void QuickSort_InputArrayIntegerNumbers_SortedArrayReturned()
        {
            //Arrange
            int[] arrayGoal = new int[] { 1, 2, 3, 4, 5, 6 };
            int[] arrayInput = new int[] { 1, 4, 3, 5, 6, 2 };

            //Act
            SortsHelper.QuickSort(arrayInput);

            //Assert
            Assert.IsTrue(arrayGoal.SequenceEqual(arrayInput));
        }
    }
}
