using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using NUnit.Framework;

namespace Logic.UnitTests
{
    [TestFixture]
    class BubbleSortTests
    {
        [Test, TestCaseSource("GetJuggedSumRows")]
        public int[][] Test_BubbleSortBySumElemntsRows_CorrectValues(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSort.SortBySumRowElements(array);
            return array;
        }

        [Test, TestCaseSource("GetJuggedSumRowsDesc")]
        public int[][] Test_BubbleSortBySumElemntsRowsDesc_CorrectValues(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSort.SortBySumRowElementsDescending(array);
            return array;
        }

        [Test, TestCaseSource("GetJuggedMaxElemRows")]
        public int[][] Test_BubbleSortByMaxElemntsRows_CorrectValues(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSort.SortByMaxRowElement(array);
            return array;
        }

        [Test, TestCaseSource("GetJuggedMaxElemRowsDesc")]
        public int[][] Test_BubbleSortByMaxElemntsRowsDesc_CorrectValues(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSort.SortByMaxRowElementDescending(array);
            return array;
        }

        [Test, TestCaseSource("GetJuggedMinElemRows")]
        public int[][] Test_BubbleSortByMinElemntsRows_CorrectValues(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSort.SortByMinRowElement(array);
            return array;
        }

        [Test, TestCaseSource("GetJuggedMinElemRowsDesc")]
        public int[][] Test_BubbleSortByMinElemntsRowsDesc_CorrectValues(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSort.SortByMinRowElementDescending(array);
            return array;
        }

        [Test, TestCaseSource("GetJuggedArgumentNullException")]
        public void Test_BubbleSort_Null_ArgumentNullException(Func<int[][]> func)
        {
            int[][] array = func();
            Assert.Throws<ArgumentNullException>(() =>BubbleSort.SortByMinRowElementDescending(array));
        }

        private static TestCaseData CreateTestCaseData(Func<int[][]> getJugged)
        {
            return new TestCaseData(getJugged);
        }

        public static IEnumerable<TestCaseData> GetJuggedSumRows()
        {
            yield return CreateTestCaseData(() => 
                new int[][]
                {
                    new int[] {1, 3, 5, 7, 9},
                    new int[] {0, 2, 4, 6},
                    new int[] {11, 22}
                }).Returns(
                new int[][]
                {
                    new int[] {0, 2, 4, 6},
                    new int[] {1, 3, 5, 7, 9},
                    new int[] {11, 22}
                }
                );

            yield return CreateTestCaseData(() =>
                new int[][]
                {
                    new int[] { 1, 2, 3, 4, 5 },
                    new int[] { 1, 1, 1 },
                    new int[] { 10 , 0 }
                }).Returns(
                new int[][]
                {
                    new int[] { 1, 1, 1 },
                    new int[] { 10 , 0 },
                    new int[] { 1, 2, 3, 4, 5 },
                }
                );
        }

        public static IEnumerable<TestCaseData> GetJuggedSumRowsDesc()
        {
            yield return CreateTestCaseData(() =>
                new int[][]
                {
                    new int[] {1, 3, 5, 7, 9},
                    new int[] {0, 2, 4, 6},
                    new int[] {11, 22}
                }).Returns(
                new int[][]
                {
                    new int[] {11, 22},
                    new int[] {1, 3, 5, 7, 9},
                    new int[] {0, 2, 4, 6}                   
                }
                );

            yield return CreateTestCaseData(() =>
                new int[][]
                {
                    new int[] { 1, 2, 3, 4, 5 },
                    new int[] { 1, 1, 1 },
                    new int[] { 10 , 0 }
                }).Returns(
                new int[][]
                {
                    new int[] { 1, 2, 3, 4, 5 },
                    new int[] { 10 , 0 },
                    new int[] { 1, 1, 1 },
                }
                );
        }

        public static IEnumerable<TestCaseData> GetJuggedMaxElemRows()
        {
            yield return CreateTestCaseData(() =>
                new int[][]
                {
                    new int[] {1, 3, 5, 7, 9},
                    new int[] {0, 2, 4, 6},
                    new int[] {11, 22}
                }).Returns(
                new int[][]
                {
                    new int[] {0, 2, 4, 6},
                    new int[] {1, 3, 5, 7, 9},
                    new int[] {11, 22}
                }
                );

            yield return CreateTestCaseData(() =>
                new int[][]
                {
                    new int[] { 1, 2, 3, 4, 5 },
                    new int[] { 1, 1, 1 },
                    new int[] { 10 , 0 }
                }).Returns(
                new int[][]
                {
                    new int[] { 1, 1, 1 },
                    new int[] { 1, 2, 3, 4, 5 },
                    new int[] { 10 , 0 }
                }
                );
        }

        public static IEnumerable<TestCaseData> GetJuggedMaxElemRowsDesc()
        {
            yield return CreateTestCaseData(() =>
                new int[][]
                {
                    new int[] {1, 3, 5, 7, 9},
                    new int[] {0, 2, 4, 6},
                    new int[] {11, 22}
                }).Returns(
                new int[][]
                {
                    new int[] {11, 22},
                    new int[] {1, 3, 5, 7, 9},
                    new int[] {0, 2, 4, 6}
                }
                );

            yield return CreateTestCaseData(() =>
                new int[][]
                {
                    new int[] { 1, 2, 3, 4, 5 },
                    new int[] { 1, 1, 1 },
                    new int[] { 10 , 0 }
                }).Returns(
                new int[][]
                {
                    new int[] { 10 , 0 },
                    new int[] { 1, 2, 3, 4, 5 },
                    new int[] { 1, 1, 1 },
                }
                );
        }

        public static IEnumerable<TestCaseData> GetJuggedMinElemRows()
        {
            yield return CreateTestCaseData(() =>
                new int[][]
                {
                    new int[] {1, 3, 5, 7, 9},
                    new int[] {4, 2, 4, 6},
                    new int[] {11, 22}
                }).Returns(
                new int[][]
                {
                    new int[] {1, 3, 5, 7, 9},
                    new int[] {4, 2, 4, 6},
                    new int[] {11, 22}
                }
                );

            yield return CreateTestCaseData(() =>
                new int[][]
                {
                    new int[] { 2, 2, 3, 4, 5 },
                    new int[] { 1, 1, 1 },
                    new int[] { 10 , 0 }
                }).Returns(
                new int[][]
                {
                    new int[] { 2, 2, 3, 4, 5 },
                    new int[] { 1, 1, 1 },
                    new int[] { 10 , 0 }
                }
                );
        }

        public static IEnumerable<TestCaseData> GetJuggedMinElemRowsDesc()
        {
            yield return CreateTestCaseData(() =>
                new int[][]
                {
                    new int[] {1, 3, 5, 7, 9},
                    new int[] {4, 2, 4, 6},
                    new int[] {11, 22}
                }).Returns(
                new int[][]
                {
                    new int[] {1, 3, 5, 7, 9},
                    new int[] {4, 2, 4, 6},
                    new int[] {11, 22}
                }
                );

            yield return CreateTestCaseData(() =>
                new int[][]
                {
                    new int[] { 2, 2, 3, 4, 5 },
                    new int[] { 1, 1, 1 },
                    new int[] { 10 , 0 }
                }).Returns(
                new int[][]
                {
                    new int[] { 2, 2, 3, 4, 5 },
                    new int[] { 1, 1, 1 },
                    new int[] { 10 , 0 }
                }
                );
        }


        public static IEnumerable<TestCaseData> GetJuggedArgumentNullException()
        {
            yield return CreateTestCaseData(() => null);
        }
    }
}
