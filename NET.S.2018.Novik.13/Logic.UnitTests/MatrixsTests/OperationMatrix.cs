using System;
using System.Collections.Generic;
using System.Linq;
using Logic.Matrixs;
using NUnit.Framework;


namespace Logic.UnitTests.MatrixsTests
{
    [TestFixture]
    class OperationMatrix
    {
        [Test]
        public void OperationMatrixTest_Add_Succed()
        {
            int[,] paramMatrix = new int[,]
            {
                { 3, 5, 4},
                { 5, 6, 8},
                { 4, 8, 7}
            };

            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(paramMatrix);          
            SymmetricalMatrix<int> symmetricalMatrix = new SymmetricalMatrix<int>(paramMatrix);

            int[] expected = new int[]
            {
                 6, 10, 8,
                 10, 12, 16,
                 8, 16, 14
            };

            var result = squareMatrix.Add(symmetricalMatrix);
            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [Test]
        public void OperationMatrixTest_Add_ArgumentNullException()
        {
            int[,] paramMatrix = new int[,]
            {
                { 3, 5, 4},
                { 5, 6, 8},
                { 4, 8, 7}
            };

            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(paramMatrix);
            SymmetricalMatrix<int> symmetricalMatrix = null;

            Assert.Throws<ArgumentNullException>(
                () => squareMatrix.Add(symmetricalMatrix));
        }

        [Test]
        public void OperationMatrixTest_Difference_Size_ArgumentException()
        {
            int[,] paramForSymmetrical = new int[,]
            {
                { 3, 5, 4},
                { 5, 6, 8},
                { 4, 8, 7}
            };

            int[,] paramForSquare = new int[,]
            {
                { 3, 5 },
                { 5, 6 }
            };

            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(paramForSquare);
            SymmetricalMatrix<int> symmetricalMatrix = new SymmetricalMatrix<int>(paramForSymmetrical);

            Assert.Throws<ArgumentException>(
                () => squareMatrix.Add(symmetricalMatrix));
        }
    }
}
