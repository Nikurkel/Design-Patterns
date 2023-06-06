namespace Design_Patterns_Test
{
    using NUnit.Framework;
    using Design_Patterns.Builder;
    using System.IO;
    using System;

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

        [Test]
        public void XmlPizzaBuilder_ThrowsWhenXmlFileDoesNotExist()
        {
            const string xmlFilePath = "nonexistent.xml";
            PizzaBuilder xmlPizzaBuilder = new XmlPizzaBuilder(xmlFilePath);
            PizzaDirector director = new PizzaDirector();

            Assert.Throws<FileNotFoundException>(() => director.Construct(xmlPizzaBuilder));
        }

        [Test]
        public void XmlPizzaBuilder_ThrowsWhenXmlFileHasInvalidFormat()
        {
            const string xmlFilePath = "invalid.xml";
            using (StreamWriter writer = new StreamWriter(xmlFilePath))
            {
                writer.WriteLine("InvalidFormat");
            }

            PizzaBuilder xmlPizzaBuilder = new XmlPizzaBuilder(xmlFilePath);
            PizzaDirector director = new PizzaDirector();

            Assert.Throws<System.Xml.XmlException>(() => director.Construct(xmlPizzaBuilder));

            File.Delete(xmlFilePath);
        }

        [Test]
        public void CsvPizzaBuilder_ThrowsWhenCsvFileDoesNotExist()
        {
            const string csvFilePath = "nonexistent.csv";
            var csvPizzaBuilder = new CsvPizzaBuilder(csvFilePath);
            var director = new PizzaDirector();

            Assert.Throws<FileNotFoundException>(() => director.Construct(csvPizzaBuilder));
        }

        [Test]
        public void CsvPizzaBuilder_ThrowsWhenCsvFileHasInvalidFormat()
        {
            const string csvFilePath = "invalid.csv";
            using (var writer = new StreamWriter(csvFilePath))
            {
                writer.WriteLine("InvalidFormat");
            }

            var csvPizzaBuilder = new CsvPizzaBuilder(csvFilePath);
            var director = new PizzaDirector();

            Assert.Throws<IndexOutOfRangeException>(() => director.Construct(csvPizzaBuilder));

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
