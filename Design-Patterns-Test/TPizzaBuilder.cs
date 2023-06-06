namespace Design_Patterns_Test
{
    using NUnit.Framework;
    using Design_Patterns.Builder;
    using System.IO;

    [TestFixture]
    public class PizzaBuilderTests
    {
        [Test]
        public void MargheritaBuilder_ConstructPizza_ReturnsMargheritaPizza()
        {
            var director = new PizzaDirector();
            var margheritaBuilder = new MargheritaBuilder();
            var referencePizza = new Pizza
            {
                Dough = "Thin crust",
                Sauce = "Tomato",
                Topping = "Cheese"
            };

            director.Construct(margheritaBuilder);
            var margheritaPizza = margheritaBuilder.GetPizza();


            AssertPizza(referencePizza, margheritaPizza);
        }

        [Test]
        public void PepperoniBuilder_ConstructPizza_ReturnsPepperoniPizza()
        {
            var director = new PizzaDirector();
            var pepperoniBuilder = new PepperoniBuilder();
            var referencePizza = new Pizza
            {
                Dough = "Thick crust",
                Sauce = "Tomato",
                Topping = "Pepperoni"
            };

            director.Construct(pepperoniBuilder);
            var pepperoniPizza = pepperoniBuilder.GetPizza();

            AssertPizza(referencePizza, pepperoniPizza);
        }

        [Test]
        public void XmlPizzaBuilder_ConstructPizzaFromXml_ReturnsPizzaWithAttributes()
        {
            const string xmlFilePath = "pizza.xml";
            var referencePizza = new Pizza
            {
                Dough = "Thin crust",
                Sauce = "Tomato",
                Topping = "Cheese"
            };

            CreatePizzaXmlFile(xmlFilePath, referencePizza);

            var xmlPizzaBuilder = new XmlPizzaBuilder(xmlFilePath);
            var director = new PizzaDirector();

            director.Construct(xmlPizzaBuilder);
            var pizza = xmlPizzaBuilder.GetPizza();

            AssertPizza(referencePizza, pizza);

            File.Delete(xmlFilePath);
        }

        [Test]
        public void CsvPizzaBuilder_ConstructPizzaFromCsv_ReturnsPizzaWithAttributes()
        {
            const string csvFilePath = "pizza.csv";

            var referencePizza = new Pizza
            {
                Dough = "Thin crust",
                Sauce = "Tomato",
                Topping = "Cheese"
            };

            CreatePizzaCsvFile(csvFilePath, referencePizza);

            PizzaBuilder csvPizzaBuilder = new CsvPizzaBuilder(csvFilePath);
            PizzaDirector director = new PizzaDirector();

            director.Construct(csvPizzaBuilder);
            Pizza pizza = csvPizzaBuilder.GetPizza();

            AssertPizza(referencePizza, pizza);

            File.Delete(csvFilePath);
        }

        private static void AssertPizza(Pizza referencePizza, Pizza pizza)
        {
            Assert.AreEqual(referencePizza.Dough, pizza.Dough);
            Assert.AreEqual(referencePizza.Sauce, pizza.Sauce);
            Assert.AreEqual(referencePizza.Topping, pizza.Topping);
        }

        private void CreatePizzaXmlFile(string filePath, Pizza pizza)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("<Pizza>");
                writer.WriteLine($"  <Dough>{pizza.Dough}</Dough>");
                writer.WriteLine($"  <Sauce>{pizza.Sauce}</Sauce>");
                writer.WriteLine($"  <Topping>{pizza.Topping}</Topping>");
                writer.WriteLine("</Pizza>");
            }
        }

        private void CreatePizzaCsvFile(string filePath, Pizza pizza)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(
                    $"{pizza.Dough},{pizza.Sauce},{pizza.Topping}");
            }
        }
    }
}
