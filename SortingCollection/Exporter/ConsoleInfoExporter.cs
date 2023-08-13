namespace SortingCollection.Exporter
{
    using System;
    using System.Collections.Generic;

    class ConsoleInfoExporter : IExporter
    {
        public void ExportData(IEnumerable<string> data)
        {
            foreach (var infoRow in data)
            {
                Console.WriteLine(infoRow);
            }
        }
    }
}
