﻿namespace SortingCollection.Exporter
{
    using System;
    using System.Collections.Generic;

    public class MinimalistArrayConsoleExporter : IExporter
    {
        public void ExportData(IEnumerable<string> data)
        {
            Console.WriteLine($"size of array: {((IReadOnlyCollection<string>)data).Count}");
        }
    }
}
