namespace SortingCollection.Sorters
{
    public class BubbleSort : Sorter
    {
        protected override void SortArray(int[] array)
        {
            for (int outer = 0; outer < array.Length; outer++)
            {
                for (int inner = 0; inner < (array.Length - 1) - outer; inner++)
                {
                    if (IsBigger(array, inner, inner + 1))
                    {
                        Swap(array, inner, inner + 1);
                    }
                }
            }
        }
    }
}