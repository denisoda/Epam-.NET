using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tasks;

namespace Tasks.Tests.Task1Tests.MSUnit
{
    [TestClass]
    public class InsertNumberTest
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow(8, 15, 0, 0, 9)]
        [DataRow(15, 15, 0, 0, 15)]
        [DataRow(8, 15, 3, 8, 120)]
        public void InsertNumber_InputCorrectValues_MSUnit(int source, int insert, int j, int i, int expected)
        {
            //Arrange

            //Act
            int result = Task1.InsertNumber(source, insert, j, i);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow(8, 15, -1, 0)]
        [DataRow(15, 15, 10, 9)]
        [DataRow(8, 15, 32, 32)]
        public void InsertNumber_InputWrongValues_MSUnit(int source, int insert, int j, int i)
        {
            //Arrange
            try
            {
                //Act
                Task1.InsertNumber(source, insert, j, i);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(true,ex.Message);
            }
        }
    }
}
