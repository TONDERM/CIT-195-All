class Program
{
    public const int Size = 15;  // global variable
    class ClubMembers
    {
        private string[] Members = new string[Size];
        public string Name { get; set; }
        public string ClubType { get; set; }
        public string ClubLocation { get; set; }
        public string MeetingDate { get; set; }

        // constructor
        public ClubMembers() 
        {
            Name = string.Empty;
            ClubType = string.Empty;
            ClubLocation = string.Empty;
            MeetingDate = string.Empty;

            for(int i = 0; i < Size; i++) 
            {
                Members[i] = string.Empty;
            }
        }

        //indexer get and set methods
        public string this[int index]
        {
            get
            {
                string tmp;

                if (index >= 0 && index <= Size - 1)
                {
                    tmp = Members[index];
                }
                else
                {
                    tmp = "";
                }

                return (tmp);
            }
            set
            {
                if (index >= 0 && index <= Size - 1)
                {
                    Members[index] = value;
                }
            }
        }

        static void Main(string[] args)
        {
            ClubMembers Member = new ClubMembers();
            bool end = false;
            int count = 0;

            while (!end)
            {
                int sub = 0;

                while (sub < 1 || sub > Size)
                {
                    Console.WriteLine($"Which new member do you want to enter (enter 1-{Size})?");
                    count ++;
                    while (!int.TryParse(Console.ReadLine(), out sub))
                        Console.WriteLine($"Enter a value between 1-{Size}");
                }

                Console.WriteLine("Enter the name of new member");
                Member[sub - 1] = Console.ReadLine();
                Member.Name = Member[sub - 1]; 

                Console.WriteLine($"What type of club does {Member.Name} belong to?");
                Member.ClubType = Console.ReadLine();

                Console.WriteLine($"Where is the {Member.ClubType} club located?");
                Member.ClubLocation = Console.ReadLine();

                Console.WriteLine("What is the meeting date?");
                Member.MeetingDate = Console.ReadLine();

                Console.WriteLine("Press any key to continue, q to stop");
                string stop = Console.ReadLine();

                if (stop == "q")
                    end = true;
            }

            Console.WriteLine($"\nHere is information on the new members ");
            Console.WriteLine($"Members:");

            for (int i = 0; i < count; i++)
            {
                if (Member[i] != string.Empty)
                    Console.WriteLine($"\nMember name: {Member[i]}");
                    Console.WriteLine($"Club type: {Member.ClubType}");
                    Console.WriteLine($"Club location: {Member.ClubLocation}");
                    Console.WriteLine($"Meeting date: {Member.MeetingDate}");
            }
        }
    }
}
