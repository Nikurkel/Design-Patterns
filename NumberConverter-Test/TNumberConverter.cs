namespace NumberConverter_Test
{
    using NumberConverter;
    using NUnit.Framework;

    public class TNumberConverter
    {
        [TestCase(10, 2, "16", "10000")]
        [TestCase(2, -2, "1000", "1000")]
        [TestCase(-10, 10, "11000", "9000")]
        [TestCase(10, -10, "100", "9000")]
        public void INumberConverter_ConvertsCorrectly(
            int startBase,
            int targetBase,
            string startNumber,
            string referenceTargetNumber)
        {
            INumberConverter converter = new OopNumberConverter();
            var target = converter.Convert(startNumber, startBase, targetBase);

            Assert.That(target, Is.EqualTo(referenceTargetNumber));
        }
    }
}