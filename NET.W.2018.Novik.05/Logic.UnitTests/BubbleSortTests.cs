﻿using System;
using System.Collections.Generic;
using Logic;
using NUnit.Framework;

namespace Logic.UnitTests
{
    [TestFixture]
    class BubbleSortTests
    {
        #region tests

        [Test, TestCaseSource("GetJuggedSumRows")]
        public int[][] Test_BubbleSortBySumElemntsRows_CorrectValues(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSort.SortRows(array, KeysForSort.GetSumRowsElements(array), new DefaultOrder());
            return array;
        }

        [Test, TestCaseSource("GetJuggedSumRowsDesc")]
        public int[][] Test_BubbleSortBySumElemntsRowsDesc_CorrectValues(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSort.SortRows(array, KeysForSort.GetSumRowsElements(array), new DescendingOrder());
            return array;
        }

        [Test, TestCaseSource("GetJuggedMaxElemRows")]
        public int[][] Test_BubbleSortByMaxElemntsRows_CorrectValues(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSort.SortRows(array, KeysForSort.GetMaxRowsElements(array), new DefaultOrder());
            return array;
        }

        [Test, TestCaseSource("GetJuggedMaxElemRowsDesc")]
        public int[][] Test_BubbleSortByMaxElemntsRowsDesc_CorrectValues(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSort.SortRows(array, KeysForSort.GetMaxRowsElements(array), new DescendingOrder());
            return array;
        }

        [Test, TestCaseSource("GetJuggedMinElemRows")]
        public int[][] Test_BubbleSortByMinElemntsRows_CorrectValues(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSort.SortRows(array, KeysForSort.GetMinRowsElements(array), new DefaultOrder());
            return array;
        }

        [Test, TestCaseSource("GetJuggedMinElemRowsDesc")]
        public int[][] Test_BubbleSortByMinElemntsRowsDesc_CorrectValues(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSort.SortRows(array, KeysForSort.GetMinRowsElements(array), new DescendingOrder());
            return array;
        }

        [Test, TestCaseSource("GetJuggedArgumentNullException")]
        public void Test_BubbleSort_Null_ArgumentNullException(Func<int[][]> func)
        {
            int[][] array = func();
            int[] keys = { };
            Assert.Throws<ArgumentNullException>(() => BubbleSort.SortRows(array, keys , new DescendingOrder()));
        }

        #endregion !tests

        #region sources for tests

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
                    new int[] { 10 , 0 },
                    new int[] { 1, 1, 1 },
                    new int[] { 2, 2, 3, 4, 5 },
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
                    new int[] {11, 22},
                    new int[] {4, 2, 4, 6},
                    new int[] {1, 3, 5, 7, 9}
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

        #endregion // sources for tests
    }
}
