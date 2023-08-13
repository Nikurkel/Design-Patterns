using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingCollection
{
    public class QuickSort : ISorter
    {
        public int[] Sort(int[] toSort)
        {
            var array = (int[]) toSort.Clone();

            SortArray(array, 0, array.Length - 1);

            return array;
        }

        private void SortArray(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[(leftIndex + rightIndex) / 2];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
            {
                SortArray(array, leftIndex, j);
            }

            if (i < rightIndex)
            {
                SortArray(array, i, rightIndex);
            }
        }
    }
}
