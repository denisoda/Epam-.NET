using System;
using System.Collections.Generic;
using Logic.Matrixs;
using NUnit.Framework;

namespace Logic.UnitTests.MatrixsTests
{
    [TestFixture]
    class SquareMatrixTests
    {

        [Test]
        public void SquareMatrixTest_Create_Size_Less_1_ArgumenOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new SquareMatrix<int>(-1));
        }
        [Test]
        public void SquareMatrixTest_ValueChange_Event_Succed()
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(5);
            squareMatrix.ChangeValue += (s, e) => {
                Assert.Pass($"{e.i}.{e.j}, old - {e.OldValue} , new - {e.NewValue}");
            };
            squareMatrix[0, 0] = 10;
        }
    }
}
