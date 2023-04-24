namespace PrivateMultipleObjects 
{
    class Menu 
    {
        private string _type;
        private string _size;
        private double _price;

        public Menu() 
        {
            _type = string.Empty;
            _size = string.Empty;
            _price = 0;
        }

        public Menu(string type, string size, double price)
        {
            _type = type;
            _size = size;
            _price = price;
        }

        public string getType() { return _type; }
        public void setType(string type) { _type = type; }
        public string getSize() { return _size; }
        public void setSize(string size) { _size = size; }
        public double getPrice() { return _price; }
        public void setPrice(double price) { _price = price; }

        public virtual void addChange() 
        {
            Console.WriteLine("Type =");
            setType(Console.ReadLine());

            Console.WriteLine("Size =");
            setSize(Console.ReadLine());

            Console.WriteLine("Price =");
            setPrice(double.Parse(Console.ReadLine()));
        }

        public virtual void display() 
        {
            Console.WriteLine();
            Console.WriteLine($"Type:  {getType()}");
            Console.WriteLine($"Size:  {getSize()}");
            Console.WriteLine($"Price: {getPrice()}");
        }
    }

    class Extra : Menu 
    {
        private string _side;
        private string _drink;
        private string _dessert;

        public Extra() : base()
        {
            _side = string.Empty;
            _drink = string.Empty;
            _dessert = string.Empty;
        }

        public Extra(string type, string size, double price, string side, string drink, string dessert) : base(type, size, price)
        {
            _side = side;
            _drink = drink;
            _dessert = dessert;
        }

        public string getSide() { return _side; }
        public void setSide(string side) { _side = side; }
        public string getDrink() { return _drink; }
        public void setDrink(string drink) { _drink = drink; }
        public string getDessert() { return _dessert; }
        public void setDessert(string dessert) { _dessert = dessert; }

        public override void addChange()
        {
            base.addChange();

            Console.WriteLine("Side =");
            setSide(Console.ReadLine());

            Console.WriteLine("Drink =");
            setDrink(Console.ReadLine());

            Console.WriteLine("Dessert =");
            setDessert(Console.ReadLine());
        }
        public override void display()
        {
            base.display();
            Console.WriteLine($"Side:  {getSide()}");
            Console.WriteLine($"Drink:  {getDrink()}");
            Console.WriteLine($"Dessert: {getDessert()}");
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Numbers of meals?");
            int maxMeal;
            while (!int.TryParse(Console.ReadLine(), out maxMeal))
                Console.WriteLine("Please enter a whole number");
            Menu[] meal = new Menu[maxMeal];

            int maxExtra;
            while (!int.TryParse(Console.ReadLine(), out maxExtra))
                Console.WriteLine("Please enter a whole number");
            Extra[] bonus = new Extra[maxExtra];

            int choice, rec, select;
            int mealCount = 0, bonusCount = 0;
            choice = Order();

            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for Meal or 2 for Extra");
                while (!int.TryParse(Console.ReadLine(), out select))
                    Console.WriteLine("1 for Meal or 2 for Extra");
                try
                {
                    switch (choice)
                    {
                        case 1: // Add
                            if (select == 1) //Menu
                            {
                                if (mealCount <= maxMeal)
                                {
                                    meal[mealCount] = new Menu(); // places an object in the array instead of null
                                    meal[mealCount].addChange();
                                    mealCount++;
                                }
                                else
                                    Console.WriteLine("The order limit for meals has been reached");

                            }
                            else //Extra
                            {
                                if (bonusCount <= maxExtra)
                                {
                                    bonus[bonusCount] = new Extra(); // places an object in the array instead of null
                                    bonus[bonusCount].addChange();
                                    bonusCount++;
                                }
                                else
                                    Console.WriteLine("The order limit for extras has been reached");
                            }

                            break;
                        case 2: //Change
                            Console.Write("Enter the record number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter the record number you want to change: ");
                            rec--;  // subtract 1 because array index begins at 0
                            if (select == 1) //Menu
                            {
                                while (rec > mealCount - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                meal[rec].addChange();
                            }
                            else // Extra
                            {
                                while (rec > bonusCount - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                bonus[rec].addChange();
                            }
                            break;
                        case 3: // Display All
                            if (select == 1) //Menu
                            {
                                for (int i = 0; i < mealCount; i++)
                                    meal[i].display();
                            }
                            else // Extra
                            {
                                for (int i = 0; i < bonusCount; i++)
                                    bonus[i].display();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }

                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Order();
            }
        }
        private static int Order()
        {
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1-Add  2-Change  3-Display  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Display  4-Quit");
            return selection;
        }
    }
}