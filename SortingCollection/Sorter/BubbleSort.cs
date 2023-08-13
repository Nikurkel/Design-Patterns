namespace SortingCollection
{
    public class BubbleSort : ISorter
    {
        public int[] Sort(int[] toSort)
        {
            var array = (int[])toSort.Clone();

            for (int outer = 0; outer < array.Length; outer++)
            {
                for (int inner = 0; inner < (array.Length - 1) - outer; inner++)
                {
                    if (array[inner] > array[inner + 1])
                    {
                        var temp = array[inner];
                        array[inner] = array[inner + 1];
                        array[inner + 1] = temp;
                    }
                }
            }

            return array;
        }
    }
}