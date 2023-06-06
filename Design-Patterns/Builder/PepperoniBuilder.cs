namespace Design_Patterns.Builder
{
    public class PepperoniBuilder : PizzaBuilder
    {
        public override void SetDough()
        {
            pizza.Dough = "Thick crust";
        }

        public override void SetSauce()
        {
            pizza.Sauce = "Tomato";
        }

        public override void SetTopping()
        {
            pizza.Topping = "Pepperoni";
        }
    }
}
