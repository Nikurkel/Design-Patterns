namespace SortingCollection.SortingManager
{
    public interface ISortingManager
    {
        public void Start();
        public void Stop();
        public void Swap(int[] array, int first, int second);
        public int Read(int[] array, int index);
        public bool IsBigger(int[] array, int first, int second);
        public string[] GetInfo();
    }
}