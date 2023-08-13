using System;
using System.Collections.Generic;

namespace SortingCollection
{
    public class BigSimpleImporter : IImporter
    {
        public int[] GetData()
        {
            List<int> l = new List<int>();
            var random = new Random();

            for (int i = 0; i < 100000; i++)
            {
                l.Add(random.Next());
            }

            return l.ToArray();
        }
    }
}
