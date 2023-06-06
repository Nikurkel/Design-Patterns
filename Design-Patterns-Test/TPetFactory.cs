namespace Design_Patterns_Test
{
    using System;
    using NUnit.Framework;
    using Design_Patterns.Factory;

    public class TPetFactory
    {
        [Test]
        public void CreateFactory()
        {
            var petFactory = new PetFactory();

            Assert.IsInstanceOf<PetFactory>(petFactory);
        }

        [TestCase("cat", typeof(Cat))]
        [TestCase("dog", typeof(Dog))]
        public void Create_ReturnsPetObject_WhenGivenValidString(
            string creationInput,
            Type expectedPet)
        {
            var petFactory = new PetFactory();

            IPet pet = petFactory.Create(creationInput);

            Assert.IsInstanceOf(expectedPet, pet);
        }

        [Test]
        public void Create_Throws_WhenGivenInvalidString()
        {
            var petFactory = new PetFactory();

            Assert.Throws<NotImplementedException>(
                () => petFactory.Create("turtle"));
        }
    }
}
