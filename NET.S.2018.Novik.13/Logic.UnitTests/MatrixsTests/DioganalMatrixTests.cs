using System;
using System.Collections.Generic;
using Logic.Matrixs;
using NUnit.Framework;

namespace Logic.UnitTests.MatrixsTests
{
    [TestFixture]
    public class DioganalMatrixTests
    {
        [Test]
        public void DioganalMatrixTest_Create_Size_Less_1_ArgumenOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new DioganalMatrix<int>(-1));
        }

        [Test]
        public void DioganalMatrixTest_ValueChange_Event_Succed()
        {
            DioganalMatrix<int> dioganalMatrix = new DioganalMatrix<int>(5);
            dioganalMatrix.ChangeValue += (s, e) => {
                Assert.Pass($"{e.i}.{e.j}, old - {e.OldValue} , new - {e.NewValue}");
            };
            dioganalMatrix[0, 0] = 10;
        }

        [Test]
        public void DioganalMatrixTest_Pass_On_No_Dioganal_IndexOutOfRangeException()
        {
            DioganalMatrix<int> dioganalMatrix = new DioganalMatrix<int>(5);
            Assert.Throws<IndexOutOfRangeException>(
                () => dioganalMatrix[0, 1] = 1);
        }

        [Test]
        public void DioganalMatrixTest_Pass_On_Dioganal_Succed()
        {
            DioganalMatrix<int> dioganalMatrix = new DioganalMatrix<int>(5);
            dioganalMatrix[0, 0] = 1;
            Assert.Pass();
        }
    }
}
