namespace Design_Patterns.Builder
{
    public abstract class PizzaBuilder
    {
        protected Pizza pizza;

        public void CreatePizza()
        {
            pizza = new Pizza();
        }

        public abstract void SetDough();
        public abstract void SetSauce();
        public abstract void SetTopping();

        public Pizza GetPizza()
        {
            return pizza;
        }
    }
}
