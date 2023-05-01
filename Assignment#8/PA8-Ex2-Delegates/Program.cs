namespace Assignment8ex2
{
    public class MathSolutions
    {
        public delegate double Prod(double a, double b);
        public double GetSum(double x, double y)
        {
            return x + y;
        }
        public double GetProduct(double a, double b)
        {
            return a * b;
        }
        public void GetSmaller(double a, double b)
        {
            if (a < b)
                Console.WriteLine($"{a} is less than {b}");
            else if (b < a)
                Console.WriteLine($"{a} is greater than {b}");
            else
                Console.WriteLine($"{a} is equal to {b}");
        }
        static void Main(string[] args)
        {
            // create a class object
            MathSolutions answer = new MathSolutions();
            Random r = new Random();
            double num1 = Math.Round(r.NextDouble() * 100);
            double num2 = Math.Round(r.NextDouble() * 100);

            Action<double, double> numList = answer.GetSmaller;
            numList(num1, num2);

            Func<double, double, double> result = answer.GetSum;
            Console.WriteLine($"{num1} + {num2} = {result(num1, num2)}");

            Prod results  = new Prod(answer.GetProduct);
            Console.WriteLine($"{num1} * {num2} = {results(num1,num2)}");

        }
    }
}