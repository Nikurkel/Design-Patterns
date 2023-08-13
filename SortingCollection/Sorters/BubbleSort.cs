namespace SortingCollection.Sorters
{
    using SortingCollection.SortingManager;

    public class BubbleSort : Sorter
    {
        public BubbleSort(ISortingManager sortingManager = null) : base(sortingManager)
        {
        }

        protected override void SortArray()
        {
            for (int outer = 0; outer < array.Length; outer++)
            {
                for (int inner = 0; inner < (array.Length - 1) - outer; inner++)
                {
                    if (sortingManager.IsBigger(array, inner, inner + 1))
                    {
                        sortingManager.Swap(array, inner, inner + 1);
                    }
                }
            }
        }
    }
}