using System.Security.Cryptography;

namespace ProtectedMultipleObjects
{
    class Menu
    {
        protected string _type;
        protected string _size;
        protected double _price;

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

        public virtual void addChange()
        {
            Console.Write($"Type=");
            _type = Console.ReadLine();

            Console.Write("Size=");
            _size = Console.ReadLine();

            Console.Write("Price=");
            _price = double.Parse(Console.ReadLine());
        }

        public virtual void display()
        {
            Console.WriteLine();
            Console.WriteLine($"Type:  {_type}");
            Console.WriteLine($"Size:  {_size}");
            Console.WriteLine($"Price: {_price}");
        }
    }

    class Extra : Menu
    {
        protected string _side;
        protected string _drink;
        protected string _dessert;

        public Extra()
        {
            _type = string.Empty;
            _size = string.Empty;
            _price = 0;
            _side = string.Empty;
            _drink = string.Empty;
            _dessert = string.Empty;
        }

        public Extra(string type, string size, double price, string side, string drink, string dessert)
        {
            _type = string.Empty;
            _size = string.Empty;
            _price = 0;
            _side = side;
            _drink = drink;
            _dessert = dessert;
        }

        public override void addChange()
        {
            Console.Write($"Type=");
            _type = Console.ReadLine();

            Console.Write("Size=");
            _size = Console.ReadLine();

            Console.Write("Price=");
            _price = double.Parse(Console.ReadLine());

            Console.WriteLine("Side =");
            _side = Console.ReadLine();

            Console.WriteLine("Drink =");
            _drink = Console.ReadLine();

            Console.WriteLine("Dessert =");
            _dessert = Console.ReadLine();
        }
        public override void display()
        {
            Console.WriteLine($"Type:  {_type}");
            Console.WriteLine($"Size:  {_size}");
            Console.WriteLine($"Price: {_price}");
            Console.WriteLine($"Side:  {_side}");
            Console.WriteLine($"Drink:  {_drink}");
            Console.WriteLine($"Dessert: {_dessert}");
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