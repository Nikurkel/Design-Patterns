namespace Design_Patterns.Builder
{
    using System.Xml;

    public class XmlPizzaBuilder : PizzaBuilder
    {
        private string xmlFilePath;

        public XmlPizzaBuilder(string filePath)
        {
            xmlFilePath = filePath;
        }

        public override void SetDough()
        {
            string dough = GetXmlAttribute("Dough");
            pizza.Dough = dough;
        }

        public override void SetSauce()
        {
            string sauce = GetXmlAttribute("Sauce");
            pizza.Sauce = sauce;
        }

        public override void SetTopping()
        {
            string topping = GetXmlAttribute("Topping");
            pizza.Topping = topping;
        }

        private string GetXmlAttribute(string attributeName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);
            XmlNode rootNode = xmlDoc.SelectSingleNode("Pizza");
            XmlNode attributeNode = rootNode.SelectSingleNode(attributeName);
            return attributeNode.InnerText;
        }
    }
}
