namespace SortingCollection.Sorters
{
    using System.Linq;
    using System.Threading.Tasks;

    public class QuickSortAsync : Sorter
    {

        protected override void SortArray(int[] array)
        {
            var x = SortPartitionAsync(array).GetAwaiter().GetResult();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = x[i];
            }
        }

        private async Task<int[]> SortPartitionAsync(int[] array)
        {
            var leftIndex = 0;
            var rightIndex = array.Length - 1;

            if (leftIndex >= rightIndex)
            {
                return array;
            }

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

            //Parallel.Invoke(
            //    async () => await SortPartitionAsync(array, leftIndex, j),
            //    async () => await SortPartitionAsync(array, i, rightIndex));

            var leftArray = array[leftIndex..(j+1)];
            var rightArray = array[i..(rightIndex+1)];

            var arrays = await Task.WhenAll(
                new[]
                {
                    SortPartitionAsync(leftArray),
                    SortPartitionAsync(rightArray),
                });

            var newArray = arrays.SelectMany(x => x).ToArray();

             return newArray;
        }
    }
}
