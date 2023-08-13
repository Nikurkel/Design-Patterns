namespace SortingCollection.Exporter
{
    using System;
    using System.Collections.Generic;

    class ConsoleArrayExporter : IExporter
    {
        public void ExportData(IEnumerable<string> data)
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