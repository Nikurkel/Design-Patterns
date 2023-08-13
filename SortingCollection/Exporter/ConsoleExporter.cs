namespace SortingCollection
{
    using System;

    class ConsoleExporter : IExporter
    {
        public void ExportData(int[] data)
        {
            Console.WriteLine("Start of array");

            foreach (var item in data)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("End of array");
        }
    }
}