using System;

namespace NumberConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            INumberConverter numberConverter = null;
            var targetNumber = numberConverter.Convert("100", 10, 12);
        }
    }
}
