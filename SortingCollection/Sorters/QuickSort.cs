namespace SortingCollection.Sorters
{
    using SortingCollection.SortingManager;

    public class QuickSort : Sorter
    {
        public QuickSort(ISortingManager sortingManager = null) : base(sortingManager)
        {
        }

        protected override void SortArray()
        {
            SortPartition(0, array.Length - 1);
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
