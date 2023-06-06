namespace Design_Patterns.Builder
{
    public class PizzaDirector
    {
        public void Construct(PizzaBuilder builder)
        {
            builder.CreatePizza();
            builder.SetDough();
            builder.SetSauce();
            builder.SetTopping();
        }
    }
}
