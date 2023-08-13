namespace SortingCollection.Exporter
{
    using System.Collections.Generic;

    public interface IExporter
    {
        public void ExportData(IEnumerable<string> data);
    }
}