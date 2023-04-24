interface IEmployee
{
    //Properties
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //Methods
    public string Fullname();
    public double Pay();
}

class Program
{
    class Employee : IEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Fullname()
        {
            return FirstName + " " + LastName;
        }
        public virtual double Pay()
        {
            double salary;
            Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
            salary = double.Parse(Console.ReadLine());
            return salary;
        }

    }

    sealed class Executive : Employee
    {
        public string Title { get; set; }
        public double Salary { get; set; }

        public Executive() : base()
        {

            Title = string.Empty;
            Salary = 0;
        }
        public Executive(int id, string firstName, string lastName, string title, double salary) : base(id, firstName, lastName)
        {

            Title = title;
            Salary = salary;
        }



        public override double Pay()
        {
            
            Console.WriteLine($"{this.Fullname()} is the {Title} and has a salary of {Salary} ");
            return Salary;
        }
    }
    static void Main(string[] args)
    {
        // Employee object
        Employee john = new Employee(213, "John", "Smith");
        john.Pay();

        // Worker object created using parameterized constructor
        Executive stan = new Executive(400, "Stan","TheMan", "Manager", 50000);
        Console.WriteLine(stan.Fullname());
        Console.WriteLine(stan.Pay());

        //Worker object created using the default constructor
        //values are assigned using properties
        Executive barney = new Executive();
        barney.Id = 20;
        barney.FirstName = "Barney";
        barney.LastName = "Rubble";
        barney.Title = "Foreman";
        barney.Salary = 75000;
        Console.WriteLine(barney.Fullname());
        Console.WriteLine(barney.Pay());
    }
}