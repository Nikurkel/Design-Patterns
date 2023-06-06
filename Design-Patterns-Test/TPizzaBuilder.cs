namespace Design_Patterns_Test
{
    using NUnit.Framework;
    using Design_Patterns.Builder;

    [TestFixture]
    public class PizzaBuilderTests
    {
        [Test]
        public void MargheritaBuilder_ConstructPizza_ReturnsMargheritaPizza()
        {
            var director = new PizzaDirector();
            var margheritaBuilder = new MargheritaBuilder();

            director.Construct(margheritaBuilder);
            var margheritaPizza = margheritaBuilder.GetPizza();

            Assert.AreEqual("Thin crust", margheritaPizza.Dough);
            Assert.AreEqual("Tomato", margheritaPizza.Sauce);
            Assert.AreEqual("Cheese", margheritaPizza.Topping);
        }

        [Test]
        public void PepperoniBuilder_ConstructPizza_ReturnsPepperoniPizza()
        {
            var director = new PizzaDirector();
            var pepperoniBuilder = new PepperoniBuilder();

            director.Construct(pepperoniBuilder);
            var pepperoniPizza = pepperoniBuilder.GetPizza();

            Assert.AreEqual("Thick crust", pepperoniPizza.Dough);
            Assert.AreEqual("Tomato", pepperoniPizza.Sauce);
            Assert.AreEqual("Pepperoni", pepperoniPizza.Topping);
        }
    }
}
