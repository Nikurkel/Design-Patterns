namespace SortingCollection
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class SortingPlayground
    {
        public void Start()
        {
            IImporter importer = new BigSimpleImporter();
            IExporter exporter = new MinimalisticConsoleExporter();
            var array = importer.GetData();


            var sorters = new List<ISorter>()
            {
                new BubbleSort(),
                new SelectionSort(),
                new QuickSortAsync(),
                new QuickSort(),
            };

            foreach (var sorter in sorters)
            {
                OutputMillisecondsNeededToSort(sorter, array, exporter);
            }
        }

        private void OutputMillisecondsNeededToSort(
            ISorter sorter,
            int[] toSort,
            IExporter exporter)
        {
            var stopWatch = new Stopwatch();

            Console.WriteLine($"Sorter: {sorter.GetType().Name}");

            stopWatch.Start();
            var sortedArray = sorter.Sort(toSort);
            stopWatch.Stop();
            //exporter.ExportData(sortedArray);
            Console.WriteLine($"time needed: {stopWatch.ElapsedMilliseconds} ms\n");
        }
    }
}