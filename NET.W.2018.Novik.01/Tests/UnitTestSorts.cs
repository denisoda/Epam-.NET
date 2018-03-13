using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorts;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class UnitTestSorts
    {
        /// <summary>
        /// Test kind of sort from Sorts.SortsHelper
        /// </summary>
        
        [TestMethod]
        public void TestMegreSort()
        {
            //Arrange
            int[] arrayGoal = new int[] { 1, 2, 3, 4, 5, 6 };
            int[] arrayInput = new int[] { 1, 4, 3, 5, 6, 2 };

            //Act
            arrayInput = SortsHelper.MergerSort(arrayInput);

            //Assert
            Assert.IsTrue(arrayGoal.SequenceEqual(arrayInput));
        }

        [TestMethod]
        public void TestQuickSort()
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
