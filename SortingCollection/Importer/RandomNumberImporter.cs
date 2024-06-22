namespace SortingCollection.Importer
{
    using System;
    using System.Collections.Generic;

    public class RandomNumberImporter : IImporter
    {
        private readonly int size;

        public RandomNumberImporter(int size)
        {
            this.size = size;
        }

        public int[] GetData()
        {
            var l = new List<int>();
            var random = new Random();

            for (int i = 0; i < size; i++)
            {
                l.Add(random.Next(size));
            }

            return l.ToArray();
        }
    }
}
