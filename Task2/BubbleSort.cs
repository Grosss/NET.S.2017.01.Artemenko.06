using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{    
    public static class BubbleSort
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
                        
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i - 1; j++)
                {
                    if (comparator.Compare(jaggedArray[j], jaggedArray[j + 1]) > 0)
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                }
            }
        }

        /// <summary>
        /// Sorts rows by defined order
        /// </summary>
        /// <param name = "jaggedArray">Jagged array for sorting</param>
        /// <param name = "compareDelegate">Delegate that takes method for comparing rows</param>
        /// <exception cref="ArgumentNullException">
        /// array or compareDelegate is null
        /// </exception>
        public static void Sort(int[][] jaggedArray, Comparison<int[]> compareDelegate)
        {
            if (ReferenceEquals(null, jaggedArray) || ReferenceEquals(null, compareDelegate))
                throw new ArgumentNullException();

            DelegateAdapter compareDelegateAdapter = new DelegateAdapter(compareDelegate);

            Sort(jaggedArray, compareDelegateAdapter);
        }

        #region Adapter of delegate

        private class DelegateAdapter : IComparer<int[]>
        {
            /// <summary>
            /// delegate hendler
            /// </summary>
            private Comparison<int[]> compareDelegate;

            /// <summary>
            /// Constructs delegate adapter
            /// </summary>
            /// <param name = "comparer">Delegate method</param>
            public DelegateAdapter(Comparison<int[]> comparer)
            {
                compareDelegate = comparer;
            }

            /// <summary>
            /// Compares two rows of jagged array
            /// </summary>
            /// <param name = "firstRow"></param>
            /// <param name = "secondRow"></param>
            /// <returns>Difference between rows</returns>
            public int Compare(int[] firstRow, int[] secondRow)
            {
                return compareDelegate(firstRow, secondRow);
            }
        }

        #endregion

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
