namespace SortingCollection
{
    public class SimpleImporter : IImporter
    {
        public int[] GetData()
        {
            return new int[]
            {
                10, 5, 32, 104, 2, 99, 2023, 69420,
            };
        }
    }
}