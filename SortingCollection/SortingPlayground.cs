namespace SortingCollection
{
    using System.Collections.Generic;

    using Sorters;
    using Importer;
    using Exporter;

    public class SortingPlayground
    {
        public void Start()
        {
            IImporter importer = new RandomNumberImporter(100000);
            IExporter exporter = new ConsoleInfoExporter();

            var sorters = new List<ISorter>()
            {
                new Sorter(),
                new BubbleSort(),
                new SelectionSort(),
                new QuickSort(),
                new QuickSortAsync(),
            };

            var toSort = importer.GetData();

            foreach(var sorter in sorters)
            {
                ExecuteSort(toSort, exporter, sorter);
            }

        }

        private static void ExecuteSort(int[] toSort, IExporter exporter, ISorter sorter)
        {
            sorter.Sort(toSort);
            var infos = sorter.GetLastSortInfos();
            exporter.ExportData(infos);
        }
    }
}