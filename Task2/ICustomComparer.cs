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
}
