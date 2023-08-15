namespace SortingCollection.Sorters
{
    public class QuickSort : Sorter
    {
        protected override void SortArray(int[] array)
        {
            SortPartition(array, 0, array.Length - 1);
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
