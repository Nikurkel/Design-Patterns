namespace SortingCollection.SortingManager
{
    public class CounterSortingManager : ISortingManager
    {
        private int readCounter;
        private int writeCounter;

        public CounterSortingManager()
        {
            readCounter = 0;
            writeCounter = 0;
        }

        public int Read(int[] array, int index)
        {
            readCounter++;
            return array[index];
        }

        public void Swap(int[] array, int firstIndex, int secondIndex)
        {
            if (firstIndex != secondIndex)
            {
                var temp = array[firstIndex];
                array[firstIndex] = array[secondIndex];
                array[secondIndex] = temp;

                readCounter += 2;
                writeCounter += 2;
            }
        }

        public string[] GetInfo()
        {
            return new string[]
            {
                $"reading actions: {readCounter}",
                $"writing actions: {writeCounter}",
            };
        }

        public bool IsBigger(int[] array, int firstIndex, int secondIndex)
        {
            readCounter += 2;
            return array[firstIndex] > array[secondIndex];
        }

        public void Start()
        {
            readCounter = 0;
            writeCounter = 0;
        }

        public void Stop()
        {
        }
    }
}
