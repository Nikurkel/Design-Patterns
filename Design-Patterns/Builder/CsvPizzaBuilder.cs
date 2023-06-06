namespace Design_Patterns.Builder
{
    using System.IO;

    public class CsvPizzaBuilder : PizzaBuilder
    {
        private string csvFilePath;

        public CsvPizzaBuilder(string filePath)
        {
            csvFilePath = filePath;
        }

        public override void SetDough()
        {
            string[] csvData = GetCsvData();
            pizza.Dough = csvData[0];
        }

        public override void SetSauce()
        {
            string[] csvData = GetCsvData();
            pizza.Sauce = csvData[1];
        }

        public override void SetTopping()
        {
            string[] csvData = GetCsvData();
            pizza.Topping = csvData[2];
        }

        private string[] GetCsvData()
        {
            using (StreamReader reader = new StreamReader(csvFilePath))
            {
                string csvLine = reader.ReadLine();
                string[] csvData = csvLine.Split(',');
                return csvData;
            }
        }
    }
}
