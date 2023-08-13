namespace SortingCollection
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using SortingManager;
    using Sorters;
    using Importer;
    using Exporter;

    public class SortingPlayground
    {
        public void Start()
        {
            IImporter importer = new RandomNumberImporter(10000);
            IExporter exporter = new ConsoleInfoExporter();
            ISortingManager sortingManager = new CounterSortingManager();

            List<Sorter> sorters = new List<Sorter>()
            {
                new BubbleSort(sortingManager),
                new SelectionSort(sortingManager),
                new QuickSort(sortingManager),
                new QuickSortAsync(sortingManager),
            };

            var toSort = importer.GetData();

            foreach(var sorter in sorters)
            {
                ExecuteSort(toSort, exporter, sorter);
            }

        }

        private static void ExecuteSort(int[] toSort, IExporter exporter, Sorter sorter)
        {
            sorter.Sort(toSort);
            var infos = new List<string>();
            infos.Add($"sorter: {sorter.GetType().Name}");
            infos.AddRange(sorter.SortingManager.GetInfo());
            infos.Add(string.Empty);

            exporter.ExportData(infos);
        }
    }
}