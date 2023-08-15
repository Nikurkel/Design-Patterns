namespace SortingCollection.Sorters
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class QuickSortAsync : Sorter
    {

        protected override void SortArray(int[] array)
        {
            SortPartitionAsync(array, 0, array.Length - 1).Wait();
        }

        private async Task SortPartitionAsync(int[] array, int leftIndex, int rightIndex)
        {
            await Task.Yield();
            var i = leftIndex;
            var j = rightIndex;
            var pivot = Read(array, (leftIndex + rightIndex) / 2);
            while (i <= j)
            {
                while (Read(array, i) < pivot)
                {
                    i++;
                }

                while (Read(array, j) > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(array, i++, j--);
                }
            }

            if (rightIndex - leftIndex > array.Length / 10)
            {
                var tasks = new List<Task>();

                if (leftIndex < j)
                {
                    tasks.Add(SortPartitionAsync(array, leftIndex, j));
                }

                if ( i < rightIndex)
                {
                    tasks.Add(SortPartitionAsync(array, i, rightIndex));
                }

                await Task.WhenAll(tasks.ToArray());
            }
            else
            {
                if ( leftIndex < j)
                {
                    SortPartition(array, leftIndex, j);
                }

                if ( i < rightIndex)
                {
                    SortPartition(array, i, rightIndex);
                }
            }
        }

        private void SortPartition(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = Read(array, (leftIndex + rightIndex) / 2);
            while (i <= j)
            {
                while (Read(array, i) < pivot)
                {
                    i++;
                }

                while (Read(array, j) > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(array, i++, j--);
                }
            }

            if (leftIndex < j)
            {
                SortPartition(array, leftIndex, j);
            }

            if (i < rightIndex)
            {
                SortPartition(array, i, rightIndex);
            }
        }
    }
}
