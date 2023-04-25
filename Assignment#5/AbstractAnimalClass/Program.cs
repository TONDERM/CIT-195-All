namespace Animals
{
    abstract class Animal
    {
        // Property
        public abstract string Name { get; set; }
        // Methods
        public abstract string Describe();
        public string whatAmI()
        {
            return "I am an animal";
        }
    }

    class Program 
    {
        class Whale : Animal 
        {
            public override string Name { get; set; }
            public string Type { get; set; }
            public double Length { get; set; }
            public double Weight { get; set; }

            public Whale() 
            {
                Type = string.Empty;
                Length = 0;
                Weight = 0;
            }

            public Whale(string name, string type, double length, double weight)
            {
                Name = name;
                Type = type;
                Length = length;
                Weight = weight;
            }

            public override string Describe()
            {
                return "I am a "+ Type + " whale" + "\nMy name is "+ Name + "\nI am "+Length+"ft long"+ "\nI weigh "+Weight +" tons";
            }
        }

        static void Main(string[] args) 
        {
            Whale wally = new Whale("Wally", "Blue", 90, 169);
            Console.WriteLine(wally.whatAmI());
            Console.WriteLine(wally.Describe());

            Whale andrea = new Whale();
            andrea.Name = "Andrea";
            andrea.Type = "Humpback";
            andrea.Length = 50;
            andrea.Weight = 30;
            Console.WriteLine(andrea.whatAmI());
            Console.WriteLine(andrea.Describe());

        }
    }
}