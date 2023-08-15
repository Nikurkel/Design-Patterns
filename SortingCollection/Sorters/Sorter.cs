namespace SortingCollection.Sorters
{
    using System.Diagnostics;
    using System.Linq;

    public class Sorter : ISorter
    {
        private int readCounter = 0;
        private int writeCounter = 0;
        private Stopwatch stopwatch = new Stopwatch();

        public string[] GetLastSortInfos()
        {
            return new string[]
            {
                $"Name: {GetType().Name}",
                $"Reads: {readCounter}",
                $"Writes: {writeCounter}",
                $"Time elapsed (ms): {stopwatch.ElapsedMilliseconds}",
                "",
            };
        }

        public int[] Sort(int[] toSort)
        {
            var array = (int[])toSort.Clone();
            Start();
            SortArray(array);
            Stop();
            return array;
        }

        protected virtual void SortArray(int[] array)
        {
            var sorted = array.OrderBy(x => x);
            for (int i = 0; i < sorted.Count(); i++)
            {
                array[i] = sorted.ToArray()[i];
            }
            array = sorted.ToList().ToArray();
        }

        protected int Read(int[] array, int index)
        {
            readCounter++;
            return array[index];
        }

        protected void Swap(int[] array, int firstIndex, int secondIndex)
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

        protected bool IsBigger(int[] array, int firstIndex, int secondIndex)
        {
            readCounter += 2;
            return array[firstIndex] > array[secondIndex];
        }

        private void Start()
        {
            writeCounter = 0;
            readCounter = 0;
            stopwatch.Restart();
        }

        private void Stop()
        {
            stopwatch.Stop();
        }
    }
}