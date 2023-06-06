namespace Design_Patterns.Factory
{
    public class Dog : IPet
    {
        public string Phrase { get => phrase; set => phrase = value; }
        public int LegCount { get => legCount; set => legCount = value; }

        private string phrase = "Woof";
        private int legCount = 4;

        public Dog()
        {
        }
    }
}
