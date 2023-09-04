namespace NumberConverter
{
    public interface INumberConverter
    {
        public string Convert(string startNumber, int startBase, int targetBase);
    }
}