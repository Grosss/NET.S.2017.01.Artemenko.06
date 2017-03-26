using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class BubbleSort
    {
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
        private static void Swap(ref int[] firstRow, ref int[] secondRow)
        {
            int[] temp = firstRow;
            firstRow = secondRow;
            secondRow = temp;
        }
        #endregion
    }
}
