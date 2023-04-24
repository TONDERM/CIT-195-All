public class Program
{
    static void Main(string[] args)
    {
        double a;
        double b;

        Console.WriteLine("Enter first number");
        a = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter second number");
        b = Convert.ToDouble(Console.ReadLine());

        var x = (double a, double b) => a + b;
        
        var y = (double a, double b) => a * b;

        var smallest = (double a, double b) =>
        {
            if (a < b)
                return a;
            else
                return b;
        };

        Console.WriteLine($"{a} + {b} = " + x(a,b));
        Console.WriteLine($"{a} * {b} = "+ y(a,b));
        Console.WriteLine($"The smaller number is " + smallest(a, b));
        Console.WriteLine();

    }
}