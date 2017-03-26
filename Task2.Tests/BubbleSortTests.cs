using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Tests
{
    [TestFixture]
    public class BubbleSortTests
    {
        [Test]
        public void SortBySumAsc_PassedJaggedArray_ExpectedSortedBySumOfRowsArray()
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

            BubbleSort.SortBySumAsc(actual);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortByMaxAsc_PassedJaggedArray_ExpectedSortedByMaxElementsOfRowsArray()
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

            BubbleSort.SortByMaxAsc(actual);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortByMinAsc_PassedJaggedArray_ExpectedSortedByMinElementsOfRowsArray()
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

            BubbleSort.SortByMinAsc(actual);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortBySumDesc_PassedJaggedArray_ExpectedSortedBySumOfRowsArray()
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

            BubbleSort.SortBySumDesc(actual);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortByMaxDesc_PassedJaggedArray_ExpectedSortedByMaxElementsOfRowsArray()
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
                new int[] { 1, 2, 4, 5 },         
            };

            BubbleSort.SortByMaxDesc(actual);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortByMinDesc_PassedJaggedArray_ExpectedSortedByMinElementsOfRowsArray()
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
                new int[] { 1, 2, 4, 5 },
                new int[] { 8, 13, 1, 9 }
            };

            BubbleSort.SortByMinDesc(actual);

            Assert.AreEqual(expected, actual);
        }
    }
}
