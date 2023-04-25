namespace pizzas 
{
    interface IPizza 
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Crust { get; set; }

        string Display();
        string orderName();
    }

    class Program
    {
        struct Toppings : IPizza 
        {
            public string Name { get; set; }
            public string Size { get; set; }
            public string Crust { get; set; }
            public string ToppingOne { get; set; }
            public string ToppingTwo { get; set; }
            public double Price { get; set; }


            public Toppings(string name,string size, string crust, string toppingOne, string toppingTwo, double price)
            {
                Name = name;
                Size = size;
                Crust = crust;
                ToppingOne = toppingOne;
                ToppingTwo = toppingTwo;
                Price = price;
            }

            public void setValues(string name, string size, string crust, string toppingOne, string toppingTwo, double price)
            {
                Name = name;
                Size = size;
                Crust = crust;
                ToppingOne = toppingOne;
                ToppingTwo = toppingTwo;
                Price = price;
            }

            public string orderName() 
            {

                return "Order for "+Name+":";
            }
             public string Display() 
            {
                return "Order is a "+ Size + " " + Crust + "crust pizza with " + ToppingOne + " and " + ToppingTwo + ".  Amount due is $" + Price+".\n";
            }
        }

        static void Main(string[] args) 
        {
            Toppings order = new Toppings();

            Console.WriteLine("Name for order?");
            string tempName = Console.ReadLine();

            Console.WriteLine("What size pizza?");
            string tempSize = Console.ReadLine();

            Console.WriteLine("Type of crust?");
            string tempCrust = Console.ReadLine();

            Console.WriteLine("First topping?");
            string tempToppingOne = Console.ReadLine();

            Console.WriteLine("Second topping?");
            string tempToppingTwo = Console.ReadLine();

            Console.WriteLine("Amount due is ");
            double tempPrice = double.Parse(Console.ReadLine());

            order.setValues(tempName,tempSize, tempCrust, tempToppingOne, tempToppingTwo, tempPrice);
            Console.WriteLine($"{order.orderName()}");
            Console.WriteLine($"{order.Display()}");

            Toppings toppings = new Toppings();
            toppings.Name = "Cindy Lorper";
            toppings.Size = "Large";
            toppings.Crust = "Thin";
            toppings.ToppingOne = "Ham";
            toppings.ToppingTwo = "Pineapple";
            toppings.Price = 15.25;
            Console.WriteLine(toppings.orderName());
            Console.WriteLine(toppings.Display());

            Toppings another = new Toppings("Jordy","Small","Stuffed","Pickles","Pepperoni", 10.34);
            Console.WriteLine(another.orderName());
            Console.WriteLine(another.Display());

        }
    }
}
