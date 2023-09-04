namespace NumberConverter
{
    public class OopNumberConverter : INumberConverter
    {
        public string Convert(string startNumber, int startBase, int targetBase)
        {
            var start = new Number(startBase, startNumber);
            var target = new Number(targetBase, start.DecimalValue);
            return target.Value;
        }
    }
}
