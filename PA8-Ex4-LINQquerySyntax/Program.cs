public class Program
{
    class famousPeople
    {
        public string Name { get; set; }
        public int? BirthYear { get; set; } = null;
        public int? DeathYear { get; set; } = null;
    }
    public static void Main()
    {
        IList<famousPeople> stemPeople = new List<famousPeople>() {
                new famousPeople() { Name= "Michael Faraday", BirthYear=1791,DeathYear=1867 },
                new famousPeople() { Name= "James Clerk Maxwell", BirthYear=1831,DeathYear=1879 },
                new famousPeople() { Name= "Marie Skłodowska Curie", BirthYear=1867,DeathYear=1934 },
                new famousPeople() { Name= "Katherine Johnson", BirthYear=1918,DeathYear=2020 },
                new famousPeople() { Name= "Jane C. Wright", BirthYear=1919,DeathYear=2013 },
                new famousPeople() { Name = "Tu YouYou", BirthYear= 1930 },
                new famousPeople() { Name = "Françoise Barré-Sinoussi", BirthYear=1947 },
                new famousPeople() {Name = "Lydia Villa-Komaroff", BirthYear=1947},
                new famousPeople() {Name = "Mae C. Jemison", BirthYear=1956},
                new famousPeople() {Name = "Stephen Hawking", BirthYear=1942,DeathYear=2018 },
                new famousPeople() {Name = "Tim Berners-Lee", BirthYear=1955 },
                new famousPeople() {Name = "Terence Tao", BirthYear=1975 },
                new famousPeople() {Name = "Florence Nightingale", BirthYear=1820,DeathYear=1910 },
                new famousPeople() {Name = "George Washington Carver", DeathYear=1943 },
                new famousPeople() {Name = "Frances Allen", BirthYear=1932,DeathYear=2020 },
                new famousPeople() {Name = "Bill Gates", BirthYear=1955 }
        };

        IEnumerable<string> famousBirth = from name in stemPeople
                                          where name.BirthYear >= 1900
                                          select name.Name;

        IEnumerable<string> famousL = from name in stemPeople
                                          where name.Name.Contains("ll")
                                          select name.Name;

        var countAge = stemPeople.Count();
        countAge = stemPeople.Count(s => s.BirthYear >= 1950);

        IEnumerable<string> famousA = from name in stemPeople
                                        where name.BirthYear >= 1920
                                        where name.BirthYear <= 2000
                                        select name.Name;

        var countA = famousA.Count();

        var listBY = from name in stemPeople
                     orderby name.BirthYear
                     select name;
                     
        Console.WriteLine();
        //---------this only has one name, so an ascending order won't do anything----------//
        IEnumerable<string> famousDeath = from name in stemPeople
                                      where name.DeathYear >= 1960
                                      where name.DeathYear <= 2015                               
                                      select name.Name;
        
        foreach (var name in famousBirth)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine();

        Console.WriteLine("The number of famous people with birthdays after 1950 is " + countAge);
        foreach (var name in famousL)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine();

        Console.WriteLine("There are " + countA + " famous people with birthdays after 1920 and before 2000");
        foreach (var name in famousA)
        {
           
            Console.WriteLine(name);
        }
        Console.WriteLine();

        foreach (var name in famousDeath)
        {
            Console.WriteLine(name);
        }
        Console.WriteLine();

        foreach (famousPeople name in listBY)
        {
            Console.WriteLine("Name: " + name.Name +"   Birthyear:"+ name.BirthYear);
        }
        Console.WriteLine();
    }
}