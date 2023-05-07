using System;
using System.Runtime.CompilerServices;

namespace Capitalism
{

    class Price
    {

        public double number { get; set; }

        // Overloading of  ">" operator
        public static bool operator >(Price cost, Price cash)
        {
            bool afford = true;
            if (cost.number > cash.number)
                afford = false;
            return afford;
        }
        // Overloading of  "<" operator
        public static bool operator < (Price cost, Price cash)
        {
            bool afford = false;
            if (cost.number < cash.number)
                afford = true;
            return afford;
        }

        public static Price operator *(Price cost, Price cash)
        {
            Price cashDouble = new Price();
            cashDouble.number = cash.number * 2;
            Price enough = new Price();
            enough.number = cashDouble.number - cost.number;
            return enough;
        }

        public static Price operator -(Price cost, Price cash)
        {
            Price diff = new Price();
            diff.number = cost.number - cash.number;
            return diff;
        }

    }

    class Program
    {

        static void Main(String[] args)
        {
            
            

            Random r = new Random();
            Price cost = new Price();
            cost.number = r.Next(1, 2000);
            Price cash = new Price();
            cash.number = r.Next(1, 2000);
            Console.WriteLine("Do you have enough cash to buy item?");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine($"Cost = {cost.number} your cash = {cash.number}");

            if (cost.number < cash.number)
                Console.WriteLine($"Yes you do! :)");
            else
                Console.WriteLine($"No you don't. :(");

            Console.WriteLine();
            Console.WriteLine("Would you have money left over?");
            Console.WriteLine("--------------------------------------------------------------------------");
            Price num = new Price();
            num.number = cash.number - cost.number;

            if (num.number < 0)
                Console.WriteLine($"No. You would owe ${num.number * -1}");
            else
                Console.WriteLine($"Yes! You would have ${num.number} left over");

            Console.WriteLine();
            Console.WriteLine("What if we double your cash?");
            Console.WriteLine("--------------------------------------------------------------------------");
            Price num2 = new Price();
            num2.number = cash.number * 2;
            Console.WriteLine($"You're new cash amount is {num2.number}");
            


        }
    }
}
