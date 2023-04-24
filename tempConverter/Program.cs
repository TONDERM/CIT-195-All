using System;

namespace tempConverter
{
    class temps
    {
        public static void Main(string[] args)
        {
            string numberType;
            int intNumToConvert;
            double dblNumToConvert;
            char type = menu();
            while (type != 'Q')
            {
                try
                {
                    Console.WriteLine("Do you want to enter a whole number or real number? (type 'whole' or 'real') ");
                    numberType = Console.ReadLine();
                    while (numberType != "whole" && numberType != "real")
                    {
                        Console.WriteLine("Please try again, type either 'whole' or 'real'");
                        numberType = Console.ReadLine();
                    }
                    Console.WriteLine("Enter the temp you want converted");
                    if (numberType == "whole")
                    {
                        intNumToConvert = int.Parse(Console.ReadLine());
                        convertTemp(type, intNumToConvert);
                    }
                    else
                    {
                        dblNumToConvert = double.Parse(Console.ReadLine());
                        convertTemp(type, dblNumToConvert);
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("You have entered bad data");
                    Console.WriteLine(e.Message);
                }
                catch
                {
                    Console.WriteLine("An error occurred, please try again.");
                }
                type = menu();

            }

        }

        static void convertTemp(char type,int intNumToConvert) 
        {
            int x = intNumToConvert;
            int convertedValue;
            char tempType = type;

            if (tempType == 'f' || tempType == 'F')
            {
                convertedValue = ((x * 9) / 5 + 32);
                Console.WriteLine("{0} degrees Celcius converted to Fahrenheit is {1}",x, convertedValue);

            }
            else
            {
                convertedValue = ((x - 32) * 5) / 9;
                Console.WriteLine("{0} degrees Fahrenheit converted to Celcius is {1}", x, convertedValue);
            }
        }

        static void convertTemp(char type, double dblNumToConvert)
        {
            double x = dblNumToConvert;
            double convertedValue;
            char tempType = type;

            if (tempType == 'f' || tempType == 'F')
            {
                convertedValue = ((x * 9) / 5 + 32);
                Console.WriteLine("{0} degrees Celcius converted to Fahrenheit is {1}", x, convertedValue);
            }
            else
            {
                convertedValue = ((x - 32) * 5) / 9;
                Console.WriteLine("{0} degrees Fahrenheit converted to Celcius is {1}", x, convertedValue);
            }
        }

        private static char menu()
        {
            Console.Write("What temperature are you converting to: ");
            Console.WriteLine("C=celsius, F=fahrenheit, Q=quit");
            int t = Console.Read();
            Console.ReadLine();
            char type = Convert.ToChar(t);
            type = char.ToUpper(type);
            while (type != 'C' && type != 'F' && type != 'Q')
            {
                Console.WriteLine("Try again, select C=celsius, F=fahrenheit, Q=quit");
                t = Console.Read();
                Console.ReadLine();
                type = Convert.ToChar(t);
                type = char.ToUpper(type);
            }
            return type;
        }

    }
}