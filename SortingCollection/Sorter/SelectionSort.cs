namespace SortingCollection
{
    public class SelectionSort : ISorter
    {
        public int[] Sort(int[] toSort)
        {
            var array = (int[])toSort.Clone();

            for (int outer = 0; outer < array.Length; outer++)
            {
                int highestIndex = 0;
                int lastIndex = (array.Length - 1) - outer;

                for (int inner = 0; inner <= lastIndex; inner++)
                {
                    if (array[inner] > array[highestIndex])
                    {
                        highestIndex = inner;
                    }
                }

                var temp = array[highestIndex];
                array[highestIndex] = array[lastIndex];
                array[lastIndex] = temp;
            }

            return array;
        }
    }
}