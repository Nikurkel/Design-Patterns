namespace SortingCollection.Sorters
{
    using System.Linq;

    using SortingManager;

    public class Sorter
    {
        protected ISortingManager sortingManager;
        protected int[] array;

        public ISortingManager SortingManager
        {
            get
            {
                return sortingManager;
            }
        }

        public Sorter(ISortingManager sortingManager = null)
        {
            this.sortingManager = sortingManager ?? new DefaultSortingManager();
        }

        public virtual int[] Sort(int[] toSort)
        {
            array = (int[])toSort.Clone();
            sortingManager.Start();
            SortArray();
            sortingManager.Stop();
            return array;
        }

        protected virtual void SortArray()
        {
            array = array.OrderBy(x => x).ToArray();
        }
    }
}