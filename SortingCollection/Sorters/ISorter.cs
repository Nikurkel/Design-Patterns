using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingCollection.Sorters
{
    interface ISorter
    {
        public int[] Sort(int[] array);
        public string[] GetLastSortInfos();
    }
}
