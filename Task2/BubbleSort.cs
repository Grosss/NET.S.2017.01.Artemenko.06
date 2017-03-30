using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public interface ICustomComparer
    {
        int Compare(int[] array1, int[] array2);
    }

    public static class BubbleSort
    {
        /// <summary>
        /// Sorts rows by defined order
        /// </summary>
        /// <param name = "jaggedArray">Jagged array for sorting</param>
        /// <param name = "comparator">comparator for comparing rows</param>
        /// <exception cref="ArgumentNullException">
        /// array or comparator is null
        /// </exception>
        public static void Sort(int[][] jaggedArray, ICustomComparer comparator)
        {
            if (ReferenceEquals(null, jaggedArray) || ReferenceEquals(null, comparator))
                throw new ArgumentNullException();
                        
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i - 1; j++)
                {
                    if (comparator.Compare(jaggedArray[j], jaggedArray[j + 1]) > 0)
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
