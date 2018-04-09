using System;
using System.Collections.Generic;
using Logic;
using NUnit.Framework;

namespace Logic.UnitTests
{
    class BubbleSortDelegateTests
    {
        #region tests

        [Test, TestCaseSource("GetJuggedSumRows")]
        public int[][] BubbleSortDelegate_BySumElemntsRows_Succed(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSortDelegate.SortRows(array, KeysForSort.GetSumRowsElements(array), new Comparison<int>((a, b) => a.CompareTo(b)));
            return array;
        }

        [Test, TestCaseSource("GetJuggedSumRowsDesc")]
        public int[][] BubbleSortDelegate_BySumElemntsRowsDesc_Succed(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSortDelegate.SortRows(array, KeysForSort.GetSumRowsElements(array), new Comparison<int>((a, b) => b.CompareTo(a)));
            return array;
        }

        [Test, TestCaseSource("GetJuggedMaxElemRows")]
        public int[][] BubbleSortDelegate_ByMaxElemntsRows_Succed(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSortDelegate.SortRows(array, KeysForSort.GetMaxRowsElements(array), new Comparison<int>((a, b) => a.CompareTo(b)));
            return array;
        }

        [Test, TestCaseSource("GetJuggedMaxElemRowsDesc")]
        public int[][] BubbleSortDelegate_ByMaxElemntsRowsDesc_Succed(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSortDelegate.SortRows(array, KeysForSort.GetMaxRowsElements(array), new Comparison<int>((a, b) => b.CompareTo(a)));
            return array;
        }

        [Test, TestCaseSource("GetJuggedMinElemRows")]
        public int[][] BubbleSortDelegate_ByMinElemntsRows_Succed(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSortDelegate.SortRows(array, KeysForSort.GetMinRowsElements(array), new Comparison<int>((a, b) => a.CompareTo(b)));
            return array;
        }

        [Test, TestCaseSource("GetJuggedMinElemRowsDesc")]
        public int[][] BubbleSortDelegate_ByMinElemntsRowsDesc_CorrectValues(Func<int[][]> func)
        {
            int[][] array = func();
            BubbleSortDelegate.SortRows(array, KeysForSort.GetMinRowsElements(array), new Comparison<int>((a, b) => b.CompareTo(a)));
            return array;
        }

        [Test, TestCaseSource("GetJuggedArgumentNullException")]
        public void BubbleSortDelegate_ArgumentNullException(Func<int[][]> func)
        {
            int[][] array = func();
            int[] keys = null;
            Assert.Throws<ArgumentNullException>(() => BubbleSortDelegate.SortRows(array, keys, new Comparison<int>((a, b) => a.CompareTo(b))));
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

