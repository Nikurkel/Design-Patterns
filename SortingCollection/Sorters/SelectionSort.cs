namespace SortingCollection.Sorters
{
    using SortingCollection.SortingManager;

    public class SelectionSort : Sorter
    {
        public SelectionSort(ISortingManager sortingManager = null) : base(sortingManager)
        {
        }

        protected override void SortArray()
        {
            for (int outer = 0; outer < array.Length; outer++)
            {
                int highestIndex = 0;
                int lastIndex = (array.Length - 1) - outer;

                for (int inner = 0; inner <= lastIndex; inner++)
                {
                    if (sortingManager.IsBigger(array, inner, highestIndex))
                    {
                        highestIndex = inner;
                    }
                }

                sortingManager.Swap(array, highestIndex, lastIndex);
            }
        }
    }
}