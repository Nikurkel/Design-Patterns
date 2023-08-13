namespace SortingCollection
{
    using System;

    public class MinimalisticConsoleExporter : IExporter
    {
        public void ExportData(int[] data)
        {
            Console.WriteLine($"size of array: {data.Length}");
        }
    }
}
