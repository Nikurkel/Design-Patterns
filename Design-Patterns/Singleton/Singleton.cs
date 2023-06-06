namespace Design_Patterns.Singleton
{
    public sealed class Singleton
    {
        private static Singleton instance = null;
        private static readonly object lockObject = new object();

        private Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }

        public string GetInfo()
        {
            return "This is some Singleton information.";
        }
    }
}
