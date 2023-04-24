namespace OperatorOverloadingEx1
{
    public class Calculator
    {
        public int number { get; set; }

        // Overload unary operators ++ and -- 
        // Code goes here
        public static Calculator operator ++(Calculator PlusPlus)
        {
            ++PlusPlus.number;
            return PlusPlus;
        }

        public static Calculator operator --(Calculator MinusMinus)
        {
            --MinusMinus.number;
            return MinusMinus;
        }

        // Overload Comparison Operators > and <
        // Code goes here
        public static bool operator >(Calculator left, Calculator right)
        {
            bool larger = false;
            if (left.number > right.number)
                larger = true;
            return larger;
        }

        public static bool operator <(Calculator left, Calculator right)
        {
            bool smaller = false;
            if (left.number < right.number)
                smaller = true;
            return smaller;
        }

        // Overload Binary Operators + and -
        // Code goes here
        public static Calculator operator +(Calculator num1, Calculator num2) { 
            Calculator num = new Calculator();
            num.number = num1.number + num2.number;
            return num;
        }

        public static Calculator operator -(Calculator num)
        {
            num.number = -num.number;
            return num;
        }

        static void Main(string[] args)
        {
            Random r = new Random();
            // create object array
            Calculator[] numbers = new Calculator[10];
            // place random numbers into array and print values
            Console.Write("Original Numbers= ");
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = new Calculator(); // creates the object
                numbers[i].number = r.Next(1, 100);  // places a value in the object
                Console.Write(" " + numbers[i].number);
            }
            Console.WriteLine();
            // if divisible by 2, add 1 to value using operator ++ method
            // otherwise subtract 1 from value using operator -- method
            Console.Write("New Numbers +1 or -1= ");
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].number % 2 == 0)
                {

                    numbers[i]++;
                
                }
                else
                {
                    numbers[i]--;
                }
                Console.Write(" " + numbers[i].number);
            }
            Console.WriteLine();

            // random Calculator object to add
            Calculator numToAdd = new Calculator();
            numToAdd.number = r.Next(1, 20);
            // Using operator +, add numToAdd.number to each element in the array
            // Print the results
            for (int i = 0; i < numbers.Length; i++)
            {
                Calculator n3 = numbers[i] + numToAdd;

                Console.Write($" {numbers[i].number} + {numToAdd.number} = {n3.number}");
                Console.WriteLine();
            }

            Console.WriteLine();

            // random Calculator object to subtract
            Calculator numToSub = new Calculator();
            numToSub.number = r.Next(1, 20);
            // Using operator -, subtract numToSub.number from each element in the array
            // Print the results

            for (int i = 0; i < numbers.Length; i++)
            {
                numToSub = numbers[i];
               
                Console.Write($"Negation value of {numToSub.number} is {-numToSub.number}");
      
                Console.WriteLine();
            }

            Console.WriteLine();

            // random Calculator object for comparison
            Calculator numToCompare = new Calculator();
            numToCompare.number = r.Next(1, 100);
            var butter = "";
           
            for (int i = 0; i < numbers.Length; i++)
            {

                if (numToCompare > numbers[i])
                {
                    butter = " greater than ";
                }

                if (numToCompare < numbers[i])
                {
                    butter = " less than ";
                }

                if (numToCompare == numbers[i])
                {
                    butter = " equals ";
                }
            
                Console.WriteLine($"{numToCompare.number} is {butter} {numbers[i].number}");
                
            }
            Console.WriteLine();
            // Using operator > and operator <, compare each element to numToCompare.number
            // print if the element is higher, lower or equal to the number you are comparing to


            // Code goes here
        }
    }
}