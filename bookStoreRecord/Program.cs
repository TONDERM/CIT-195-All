
class Program
{
    public record Bookstore(int ID, string Title, string Author, double Price);

    public static void Main()
    {
        Bookstore book = new(23, "Days of Pudding", "Thomas Pudding", 24.99);
        Console.WriteLine(book);

        Bookstore name = new(43, "My Name", "Dennis Menace", 15.79);
        Console.WriteLine($"\nBook title is {name.Title}");
        Console.WriteLine($"Book author is {name.Author}");
        Console.WriteLine($"Book price is ${name.Price}");
        Console.WriteLine($"Book ID is {name.ID}");
        Console.WriteLine(name);

        Bookstore store = new(252,"How to Read","Jim Read",10.24);
        Console.WriteLine($"\nThis store is selling '{store.Title}' written by {store.Author} for ${store.Price}.");
        Console.WriteLine($"It's book ID is {store.ID}.");
        Console.WriteLine(store);
    }
}