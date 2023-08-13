namespace SortingCollection.SortingManager
{
    public class DefaultSortingManager : ISortingManager
    {
        public int Read(int[] array, int index)
        {
            return array[index];
        }

        public void Swap(int[] array, int firstIndex, int secondIndex)
        {
            if (firstIndex != secondIndex)
            {
                var temp = array[firstIndex];
                array[firstIndex] = array[secondIndex];
                array[secondIndex] = temp;
            }
        }

        public bool IsBigger(int[] array, int firstIndex, int secondIndex)
        {
            return array[firstIndex] > array[secondIndex];
        }

        public string[] GetInfo()
        {
            return new string[]
            {
                "No infos available",
            };
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }
    }
}
