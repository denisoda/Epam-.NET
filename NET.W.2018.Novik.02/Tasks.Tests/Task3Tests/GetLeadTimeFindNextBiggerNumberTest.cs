using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks;
using NUnit.Framework;
using System.Diagnostics;

namespace Tasks.Tests.Task3Tests
{
    [TestFixture]
    class GetLeadTimeFindNextBiggerNumberTest
    {
        [Test]
        [TestCase(1234321)]
        [TestCase(1234126)]
        [TestCase(3456432)]
        public void GetLeadTime_FindNextBiggerNumberTest(int number)
        {
            //Arrange
            Stopwatch timeLead;

            //Act
            timeLead = Task3.GetLeadTimeFindNextBiggerNumber(number);

            //Assert
            //Assert.NotNull(timeLead,$"Time lead is { timeLead.Elapsed.ToString()}");
            Assert.Pass($"Time lead is { timeLead.Elapsed.ToString()}");
        }
    }
}
