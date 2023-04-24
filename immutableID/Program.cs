class Program
{
    class Student
    {
        // auto-implemented properties
        public int Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // default constructor
        public Student()
        {
            Id = 0;
            FirstName = "";
            LastName = "";
        }
        // parameterized constructor
        public Student(int i, string First, string Last)
        {
            Id = i;
            FirstName = First;
            LastName = Last;
        }

        public Student(int i)
        {
            Id = i;
            FirstName = "";
            LastName = "";
        }
    }

    public void Main() 
    {
        Student studentID = new Student(111);            
        studentID.FirstName = "Hank";
        studentID.LastName = "Hill";
        Console.WriteLine(studentID.Id);
        Console.WriteLine(studentID.FirstName);
        Console.WriteLine(studentID.LastName);
        Console.WriteLine();

        Student student = new Student(222,"Stan","Smith");
        Console.WriteLine(student.Id);
        Console.WriteLine(student.FirstName);
        Console.WriteLine(student.LastName);
    }
}