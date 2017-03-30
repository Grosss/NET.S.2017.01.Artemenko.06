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
        /// <param name = "comparator"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Sort(int[][] jaggedArray, ICustomComparer comparator)
        {
            if (jaggedArray == null)
                throw new ArgumentNullException();

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i - 1; j++)
                {
                    if (comparator.Compare(jaggedArray[i], jaggedArray[i + 1]) > 0)
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                }
            }
        }

        /// <summary>
        /// Sorts rows by ascending sum in jagged array
        /// </summary>
        /// <param name = "jaggedArray">Jagged array for sorting</param>
        public static void SortBySumAsc(int[][] jaggedArray)
        {
            if (jaggedArray == null)
                throw new ArgumentNullException();

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i - 1; j++)
                {
                    if (jaggedArray[j].Sum() > jaggedArray[j + 1].Sum())
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                }
            }
        }

        /// <summary>
        /// Sorts rows by ascending max elements in jagged array
        /// </summary>
        /// <param name = "jaggedArray">Jagged array for sorting</param>
        public static void SortByMaxAsc(int[][] jaggedArray)
        {
            if (jaggedArray == null)
                throw new ArgumentNullException();

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i - 1; j++)
                {
                    if (jaggedArray[j].Max() > jaggedArray[j + 1].Max())
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                }
            }
        }

        /// <summary>
        /// Sorts rows by ascending min elements in jagged array
        /// </summary>
        /// <param name = "jaggedArray">Jagged array for sorting</param>
        public static void SortByMinAsc(int[][] jaggedArray)
        {
            if (jaggedArray == null)
                throw new ArgumentNullException();

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i - 1; j++)
                {
                    if (jaggedArray[j].Min() > jaggedArray[j + 1].Min())
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                }
            }
        }

        /// <summary>
        /// Sorts rows by descending sum in jagged array
        /// </summary>
        /// <param name = "jaggedArray">Jagged array for sorting</param>
        public static void SortBySumDesc(int[][] jaggedArray)
        {
            if (jaggedArray == null)
                throw new ArgumentNullException();

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i - 1; j++)
                {
                    if (jaggedArray[j].Sum() < jaggedArray[j + 1].Sum())
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                }
            }
        }

        /// <summary>
        /// Sorts rows by descending max elements in jagged array
        /// </summary>
        /// <param name = "jaggedArray">Jagged array for sorting</param>
        public static void SortByMaxDesc(int[][] jaggedArray)
        {
            if (jaggedArray == null)
                throw new ArgumentNullException();

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i - 1; j++)
                {
                    if (jaggedArray[j].Max() < jaggedArray[j + 1].Max())
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                }
            }
        }

        /// <summary>
        /// Sorts rows by descending min elements in jagged array
        /// </summary>
        /// <param name = "jaggedArray">Jagged array for sorting</param>
        public static void SortByMinDesc(int[][] jaggedArray)
        {
            if (jaggedArray == null)
                throw new ArgumentNullException();

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray.Length - i - 1; j++)
                {
                    if (jaggedArray[j].Min() < jaggedArray[j + 1].Min())
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
