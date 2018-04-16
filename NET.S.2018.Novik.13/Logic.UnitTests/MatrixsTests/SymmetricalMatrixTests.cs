using System;
using System.Collections.Generic;
using Logic.Matrixs;
using NUnit.Framework;

namespace Logic.UnitTests.MatrixsTests
{
    class SymmetricalMatrixTests
    {
        [Test]
        public void SymmetricalMatrixTest_Create_Size_Less_1_ArgumenOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new SymmetricalMatrix<int>(-1));
        }

        [Test]
        public void SymmetricalMatrixTest_ValueChange_Event_Succed()
        {
            SymmetricalMatrix<int> symmetricalMatrix = new SymmetricalMatrix<int>(5);
            symmetricalMatrix.ChangeValue += (s, e) => {
                Assert.Pass($"{e.i}.{e.j}, old - {e.OldValue} , new - {e.NewValue}");
            };
            symmetricalMatrix[0, 0] = 10;
        }

        [Test]
        public void SymmetricalMatrixTest_Pass_NoSymmetricalMatrix_ArgumentException()
        {
            int[,] paramMatrix = new int[,]
            {
                { 1, 2, 1},
                { 1, 2, 3},
                { 1, 2, 3}
            };

            Assert.Throws<ArgumentException>(
                () => new SymmetricalMatrix<int>(paramMatrix));
        }

        [Test]
        public void SymmetricalMatrixTest_Pass_SymmetricalMatrix_Succed()
        { 
            int[,] paramMatrix = new int[,]
            {
                { 3, 5, 4},
                { 5, 6, 8},
                { 4, 8, 7}
            };
            SymmetricalMatrix<int> symmetricalMatrix = new SymmetricalMatrix<int>(paramMatrix);

            Assert.Pass();
        }
    }
}
