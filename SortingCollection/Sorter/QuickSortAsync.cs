namespace SortingCollection
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class QuickSortAsync : ISorter
    {
        public int[] Sort(int[] toSort)
        {
            var array = (int[])toSort.Clone();

            SortArrayAsync(array, 0, array.Length - 1).Wait();
            return array;
        }

        private async Task SortArrayAsync(int[] array, int leftIndex, int rightIndex)
        {
            await Task.Yield();
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

            if (rightIndex - leftIndex > array.Length / 10)
            {
                var tasks = new List<Task>();

                if (leftIndex < j)
                {
                    tasks.Add(SortArrayAsync(array, leftIndex, j));
                }

                if ( i < rightIndex)
                {
                    tasks.Add(SortArrayAsync(array, i, rightIndex));
                }

                await Task.WhenAll(tasks.ToArray());
            }
            else
            {
                if ( leftIndex < j)
                {
                    SortArray(array, leftIndex, j);
                }

                if ( i < rightIndex)
                {
                    SortArray(array, i, rightIndex);
                }
            }
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
