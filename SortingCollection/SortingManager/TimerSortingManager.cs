using System.Diagnostics;

namespace SortingCollection.SortingManager
{
    class TimerSortingManager : ISortingManager
    {
        private readonly Stopwatch stopwatch = new Stopwatch();

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
                $"elapsed time: {stopwatch.ElapsedMilliseconds}",
            };
        }

        public void Start()
        {
            stopwatch.Restart();
        }

        public void Stop()
        {
            stopwatch.Stop();
        }
    }
}
