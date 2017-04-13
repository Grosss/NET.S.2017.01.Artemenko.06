using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class BubbleSortUsingDelegate
    {
        /// <summary>
        /// Sorts rows by defined order
        /// </summary>
        /// <param name = "jaggedArray">Jagged array for sorting</param>
        /// <param name = "comparator">Comparator for comparing rows</param>
        /// <exception cref="ArgumentNullException">
        /// array or comparator is null
        /// </exception>
        public static void Sort(int[][] jaggedArray, IComparer<int[]> comparator)
        {
            if (ReferenceEquals(null, jaggedArray) || ReferenceEquals(null, comparator))
                throw new ArgumentNullException();

            Sort(jaggedArray, comparator.Compare);
        }

        /// <summary>
        /// Sorts rows by defined order
        /// </summary>
        /// <param name = "jaggedArray">Jagged array for sorting</param>
        /// <param name = "compareDelegate">Delegate that takes method for comparing rows</param>
        /// <exception cref="ArgumentNullException">
        /// array or compareDelegate is null
        /// </exception>
        public static void Sort(int[][] jaggedArray, Func<int[], int[], int> compareDelegate)
        {
            if (ReferenceEquals(null, jaggedArray) || ReferenceEquals(null, compareDelegate))
                throw new ArgumentNullException();

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i - 1; j++)
                {
                    if (compareDelegate(jaggedArray[j], jaggedArray[j + 1]) > 0)
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                }
            }
        }
        
        #region Private methods

        /// <summary>
        /// Swaps two rows of jagged array
        /// </summary>
        /// <param name = "firstRow"></param>
        /// <param name = "secondRow"></param>
        private static void Swap(ref int[] firstRow, ref int[] secondRow)
        {
            int[] temp = firstRow;
            firstRow = secondRow;
            secondRow = temp;
        }

        #endregion
    }
}
