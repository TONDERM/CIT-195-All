using System;
namespace JellyClub
{
    interface IClub
    {
        //Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Methods
        public string Fullname();
        public double Cost();
    }

    class Program
    {
        class Member : IClub
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int JarCount { get; set; }
            public int Subscription { get; set; }
            public double Rate { get; set; }

            public Member()
            {
                Id = 0;
                FirstName = string.Empty;
                LastName = string.Empty;
                JarCount = 0;
                Subscription = 1;
                Rate = 1;
            }

            public Member(int id, string firstName, string lastName, int jarCount, int subscription, double rate)
            {
                Id = id;
                FirstName = firstName;
                LastName = lastName;
                JarCount = jarCount;
                Subscription = subscription;
                Rate = rate;
            }

            public string Fullname()
            {
                return FirstName + " " + LastName;
            }

            public double Cost() 
            {
                if (JarCount == 6)
                    return (Rate * 6) * Subscription;

                else if (JarCount == 12)
                    return (Rate * 12) * Subscription;

                else
                    return (Rate * 24) * Subscription;
            }
        }

        static void Main(string[] args) 
        {
            Member June = new Member(1203, "June", "Hayworth", 24, 12, 1);
            Console.WriteLine(June.Fullname());
            Console.WriteLine(June.Cost());

            Member Tony = new Member();
            Tony.Id = 0448;
            Tony.FirstName = "Tony";
            Tony.LastName = "Foster";
            Tony.Subscription = 6;
            Tony.JarCount = 12;
            Tony.Rate = 1.5;
            Console.WriteLine(Tony.Fullname());
            Console.WriteLine(Tony.Cost());
        }
    }
}