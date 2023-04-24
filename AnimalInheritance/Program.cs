class Animal
{
    private string name; // only accessible within this class
    protected string type; //accessible from derived classes
    public string color;  // accessible from any class

    public void setName(string name)
    {
        this.name = name;
    }
    public virtual string getName()
    {
        return this.name;
    }
    public void setType(string type)
    {
        this.type = type;
    }
    public virtual string getType()
    {
        return this.type;
    }
}

class Dog : Animal 
{
    public string breed;
    protected int age;
    private double weight;

    public void setAge(int age)
    {
        this.age = age;
    }
    public virtual int getAge()
    {
        return age;
    }

    public void setWeight(double weight) 
    {
        this.weight = weight;
    }

    public virtual double getWeight()
    {
        return this.weight;
    }

    public override string getName()
    {
        return base.getName();
    }

    public override string getType()
    {
        return base.getType();
    }
}

class Program 
{
    static void Main(string[] args) 
    {
        Animal pet = new Animal();
        pet.setName("GlubGlub");
        pet.setType("Lizard");
        pet.color = "Green";

        Console.WriteLine($"{pet.getType()} Information...");
        Console.WriteLine($"Name = {pet.getName()}");
        Console.WriteLine($"Type = {pet.getType()}");
        Console.WriteLine($"Color = {pet.color}");
        Console.WriteLine();

        Dog doggy = new Dog();
        doggy.setName("Zeus");
        doggy.setType("Dog");
        doggy.color = "Light Brown";
        doggy.breed = "Pug";      
        doggy.setAge(4);

        Console.WriteLine("Dog Information...");
        Console.WriteLine($"Name = {doggy.getName()}");
        Console.WriteLine($"Type = {doggy.getType()}");
        Console.WriteLine($"Breed = {doggy.breed}");
        Console.WriteLine($"Color = {doggy.color}");
        Console.WriteLine($"Age = {doggy.getAge()}");
    }
}