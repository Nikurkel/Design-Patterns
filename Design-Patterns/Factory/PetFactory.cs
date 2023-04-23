using System;

namespace Design_Patterns.Factory
{
    public class PetFactory : IFactory
    {
        public PetFactory()
        {

        }

        public IPet Create(string petType)
        {
            switch (petType.ToLower())
            {
                case "cat":
                    return new Cat();
                case "dog":
                    return new Dog();
                default:
                    throw new NotImplementedException("Invalid pet type");
            }
        }
    }
}
