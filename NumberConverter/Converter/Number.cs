namespace NumberConverter
{
    class Number
    {
        private readonly int numberBase;
        private readonly int decimalValue;
        private readonly string value;

        public int NumberBase => numberBase;
        public int DecimalValue => decimalValue;
        public string Value => value;

        public Number(int numberBase, int decimalValue)
        {
            this.numberBase = numberBase;
            this.decimalValue = decimalValue;
            value = ConverterHelper.Convert(numberBase, decimalValue);
        }

        public Number(int numberBase, string value)
        {
            this.numberBase = numberBase;
            this.value = value;
            decimalValue = ConverterHelper.Convert(numberBase, value);
        }
    }
}
