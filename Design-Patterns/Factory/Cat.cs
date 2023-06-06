namespace Design_Patterns.Factory
{
    public class Cat : IPet
    {
        public string Phrase { get => phrase; set => phrase = value; }
        public int LegCount { get => legCount; set => legCount = value; }

        private string phrase = "Meow";
        private int legCount = 4;

        public Cat()
        {
        }
    }
}
