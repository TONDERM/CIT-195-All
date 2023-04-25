using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        /*
        Random r = new Random();
        int[] numbers = { r.Next(1, 10), r.Next(1, 10), r.Next(1, 10), r.Next(1, 10), r.Next(1, 10), r.Next(1, 10) };
        var numberSubset = numbers[1..4];
        Console.WriteLine($"Total of the numbers array={Add(numbers)}");
        Console.WriteLine($"Total of the subset array={Add(numberSubset)}");
        Console.WriteLine($"Total of 10,20,30,40,50 = {Add(10, 20, 30, 40, 50)}");
        */
       
        Console.WriteLine("How many numbers would you like to generate?");
        int size = int.Parse(Console.ReadLine());
        int[] numbers = new int[size];

        Console.WriteLine("\nRandom numbers:");
        for (int i = 0; i < size; i++)
        {
            Random r = new Random();
            int x = r.Next(1, 10);
            numbers[i] = x;
            Console.WriteLine(x);
        }

        Console.WriteLine($"\nTotal from adding = {Add(numbers)}");
        Console.WriteLine($"Total from multiplying = {Multiply(numbers)}");


    }
    static int Add(params int[] numbers)
    {
        int total = 0;
        foreach (int number in numbers)
        {
            total += number;
        }
        return total;
    }

    static int Multiply(params int[] numbers)
    {
        int total = 1;
        foreach (int number in numbers)
        {
            total *= number;
        }
        return total;
    }

}