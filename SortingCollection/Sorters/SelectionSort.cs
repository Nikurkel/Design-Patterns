namespace SortingCollection.Sorters
{
    public class SelectionSort : Sorter
    {
        protected override void SortArray(int[] array)
        {
            for (int outer = 0; outer < array.Length; outer++)
            {
                int highestIndex = 0;
                int lastIndex = (array.Length - 1) - outer;

                for (int inner = 0; inner <= lastIndex; inner++)
                {
                    if (IsBigger(array, inner, highestIndex))
                    {
                        highestIndex = inner;
                    }
                }

                Swap(array, highestIndex, lastIndex);
            }
        }
    }
}