using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Tests
{    
    [TestFixture]
    public class BubbleSortUsingDelegateTests
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

            BubbleSortUsingDelegate.Sort(actual, new AscSumComparer());

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

            BubbleSortUsingDelegate.Sort(actual, new DescSumComparer());

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

            BubbleSortUsingDelegate.Sort(actual, new AscMaxComparer());

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

            BubbleSortUsingDelegate.Sort(actual, new DescMaxComparer());

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        public void Sort_PassedNullReference_ThrowsArgumentNullException(int[][] jaggedArray)
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSortUsingDelegate.Sort(jaggedArray, new AscSumComparer()));
        }
    }
}
