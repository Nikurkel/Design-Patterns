namespace NumberConverter
{
    using System;
    using System.Linq;
    using System.Text;

    static class ConverterHelper
    {
        public static readonly string AllBaseCharacters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string BaseCharacters(int numberBase)
        {
            var absoluteBase = Math.Abs(numberBase);
            return AllBaseCharacters[..absoluteBase];
        }

        public static string Convert(int numberBase, int decimalValue)
        {
            var stringBuilder = new StringBuilder();
            var validChars = BaseCharacters(numberBase);

            do
            {
                var remainder = decimalValue % numberBase;
                var currentCharacter = validChars.ElementAt(Math.Abs(remainder));
                stringBuilder.Insert(0, currentCharacter);
                decimalValue /= numberBase;
            }
            while (decimalValue != 0);

            return stringBuilder.ToString();
        }

        public static int Convert(int numberBase, string basedValue)
        {
            var decimalValue = 0;
            var validChars = BaseCharacters(numberBase);

            for (int i = 0; i < basedValue.Length; i++)
            {
                var power = (int)Math.Pow(numberBase, basedValue.Length - i - 1);
                var charValue = validChars.IndexOf(basedValue[i]);
                decimalValue += charValue * power;
            }

            return decimalValue;
        }
    }
}
