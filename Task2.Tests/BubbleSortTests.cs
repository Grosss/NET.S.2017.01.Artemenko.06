using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Tests
{
    public class AscSumComparer : ICustomComparer
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (ReferenceEquals(array1, null))
                return -1;

            if (ReferenceEquals(array2, null))
                return 1;

            return array1.Sum() - array2.Sum();
        }
    }

    public class DescSumComparer : ICustomComparer
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (ReferenceEquals(array2, null))
                return -1;

            if (ReferenceEquals(array1, null))
                return 1;

            return array2.Sum() - array1.Sum();
        }
    }

    public class AscMaxComparer : ICustomComparer
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (ReferenceEquals(array1, null))
                return -1;

            if (ReferenceEquals(array2, null))
                return 1;

            return array1.Max() - array2.Max();
        }
    }

    public class DescMaxComparer : ICustomComparer
    {
        public int Compare(int[] array1, int[] array2)
        {
            if (ReferenceEquals(array2, null))
                return -1;

            if (ReferenceEquals(array1, null))
                return 1;

            return array2.Max() - array1.Max();
        }
    }

    [TestFixture]
    public class BubbleSortTests
    {
        [Test]
        public void Sort_PassedJaggedArrayAndAscSumComparerObject_ExpectedAscSortedBySumOfRowsArray()
        {
            int[][] actual = {
                new int[] { 1, 2, 4, 5 },
                new int[] { 7, 12, 31 },
                new int[] { 35, 2, 2, 3, 2 },
                new int[] { 8, 13, 1, 9 }
            };
            int[][] expected = {
                new int[] { 1, 2, 4, 5 },
                new int[] { 8, 13, 1, 9 },
                new int[] { 35, 2, 2, 3, 2 },
                new int[] { 7, 12, 31 }                
            };

            BubbleSort.Sort(actual, new AscSumComparer());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Sort_PassedJaggedArrayAndDescSumComparerObject_ExpectedDescSortedBySumOfRowsArray()
        {
            int[][] actual = {
                new int[] { 1, 2, 4, 5 },
                new int[] { 7, 12, 31 },
                new int[] { 35, 2, 2, 3, 2 },
                new int[] { 8, 13, 1, 9 }
            };
            int[][] expected = {           
                new int[] { 7, 12, 31 },
                new int[] { 35, 2, 2, 3, 2 },
                new int[] { 8, 13, 1, 9 },
                new int[] { 1, 2, 4, 5 }
            };

            BubbleSort.Sort(actual, new DescSumComparer());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Sort_PassedJaggedArrayAndAscMaxComparerObject_ExpectedAscSortedByMaxElementsOfRowsArray()
        {
            int[][] actual = {
                new int[] { 1, 2, 4, 5 },
                new int[] { 7, 12, 31 },
                new int[] { 35, 2, 2, 3, 2 },
                new int[] { 8, 13, 1, 9 }
            };
            int[][] expected = {
                new int[] { 1, 2, 4, 5 },
                new int[] { 8, 13, 1, 9 },
                new int[] { 7, 12, 31 },
                new int[] { 35, 2, 2, 3, 2 }
            };

            BubbleSort.Sort(actual, new AscMaxComparer());

            Assert.AreEqual(expected, actual);
        }              

        [Test]
        public void Sort_PassedJaggedArrayAndDescMaxComparerObject_ExpectedDescSortedByMaxElementsOfRowsArray()
        {
            int[][] actual = {
                new int[] { 1, 2, 4, 5 },
                new int[] { 7, 12, 31 },
                new int[] { 35, 2, 2, 3, 2 },
                new int[] { 8, 13, 1, 9 }
            };
            int[][] expected = {
                new int[] { 35, 2, 2, 3, 2 },
                new int[] { 7, 12, 31 },
                new int[] { 8, 13, 1, 9 },
                new int[] { 1, 2, 4, 5 }
            };

            BubbleSort.Sort(actual, new DescMaxComparer());

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        public void Sort_PassedNullReference_ThrowsArgumentNullException(int[][] jaggedArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSort.Sort(jaggedArray, new AscSumComparer()));
        }
    }
}
