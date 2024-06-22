namespace Sorting_Collection_Test
{
    using NUnit.Framework;
    using System.Collections.Generic;

    using SortingCollection;
    using SortingCollection.Sorters;
    using SortingCollection.Importer;

    public class TISorter
    {
        private static readonly List<Sorter> Sorters = new List<Sorter>
        {
            new Sorter(),
            new BubbleSort(),
            new SelectionSort(),
            new QuickSort(),
            new QuickSortAsync(),
        };

        private static readonly int[] toSort = new RandomNumberImporter(1000).GetData();

        [TestCaseSource(nameof(Sorters))]
        public void ISort_SortSortsArrayCorrectly(Sorter sorter)
        {
            var sortedArray = sorter.Sort(toSort);
            Assert.IsTrue(CheckIsSorted(sortedArray));
        }

        private static bool CheckIsSorted(int[] data)
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                if (data[i] > data[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}