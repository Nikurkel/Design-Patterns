namespace Design_Patterns.Builder
{
    using System;

    public class Pizza
    {
        public string Dough { get; set; }
        public string Sauce { get; set; }
        public string Topping { get; set; }

        public void Display()
        {
            Console.WriteLine($"Pizza with {Dough} dough, " +
                $"{Sauce} sauce, and {Topping} topping.");
        }
    }
}

