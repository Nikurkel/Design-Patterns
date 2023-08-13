namespace SortingCollection.Sorters
{
    using SortingCollection.SortingManager;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class QuickSortAsync : Sorter
    {
        public QuickSortAsync(ISortingManager sortingManager = null) : base(sortingManager)
        {
        }

        protected override void SortArray()
        {
            SortPartitionAsync(0, array.Length - 1).Wait();
        }

        private async Task SortPartitionAsync(int leftIndex, int rightIndex)
        {
            await Task.Yield();
            var i = leftIndex;
            var j = rightIndex;
            var pivot = sortingManager.Read(array, (leftIndex + rightIndex) / 2);
            while (i <= j)
            {
                while (sortingManager.Read(array, i) < pivot)
                {
                    i++;
                }

                while (sortingManager.Read(array, j) > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    sortingManager.Swap(array, i++, j--);
                }
            }

            if (rightIndex - leftIndex > array.Length / 10)
            {
                var tasks = new List<Task>();

                if (leftIndex < j)
                {
                    tasks.Add(SortPartitionAsync(leftIndex, j));
                }

                if ( i < rightIndex)
                {
                    tasks.Add(SortPartitionAsync(i, rightIndex));
                }

                await Task.WhenAll(tasks.ToArray());
            }
            else
            {
                if ( leftIndex < j)
                {
                    SortPartition(leftIndex, j);
                }

                if ( i < rightIndex)
                {
                    SortPartition(i, rightIndex);
                }
            }
        }

        private void SortPartition(int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = sortingManager.Read(array, (leftIndex + rightIndex) / 2);
            while (i <= j)
            {
                while (sortingManager.Read(array, i) < pivot)
                {
                    i++;
                }

                while (sortingManager.Read(array, j) > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    sortingManager.Swap(array, i++, j--);
                }
            }

            if (leftIndex < j)
            {
                SortPartition(leftIndex, j);
            }

            if (i < rightIndex)
            {
                SortPartition(i, rightIndex);
            }
        }
    }
}
