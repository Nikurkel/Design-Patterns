namespace Design_Patterns.Builder
{
    public class MargheritaBuilder : PizzaBuilder
    {
        public override void SetDough()
        {
            pizza.Dough = "Thin crust";
        }

        public override void SetSauce()
        {
            pizza.Sauce = "Tomato";
        }

        public override void SetTopping()
        {
            pizza.Topping = "Cheese";
        }
    }
}
