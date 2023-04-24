using System;
using System.Diagnostics.Metrics;

namespace myProject
{
    class book
    {
        private int _Id;
        private string _Title;
        private string _Author;

        public book()
        {
            _Id = 0;
            _Title = "";
            _Author = "";
        }

        public book(int id, string title, string author)
        {
            _Id = id;
            _Title = title;
            _Author = author;
        }

        public int GetId()
        {
            return _Id;
        }

        public void SetId(int identification)
        {
            _Id = identification;
        }

        public string GetTitle()
        {
            return _Title;
        }

        public void SetTitle(string bookTitle)
        {
            _Title = bookTitle;
        }

        public string GetAuthor()
        {
            return _Author;
        }

        public void SetAuthor(string bookAuthor)
        {
            _Author = bookAuthor;
        }

    }

    class myStore
    {
        static void Main(string[] args)
        {
            book bookOne = new book();
            bookOne.SetId(1);
            bookOne.SetTitle("Drinking Tea in Style");
            bookOne.SetAuthor("Ingrid Livingston");

            book bookTwo = new book();
            Console.WriteLine("Please enter book Id: ");
            bookTwo.SetId(int.Parse(Console.ReadLine()));
            Console.WriteLine("Please enter book title: ");
            bookTwo.SetTitle(Console.ReadLine());
            Console.WriteLine("Please enter authors name: ");
            bookTwo.SetAuthor(Console.ReadLine());

            book bookThree = new book(3, "Fun with Rocks", "Jerry Dunvy");

            Console.WriteLine("Please enter book Id: ");
            int tempID = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter book title: ");
            string tempTitle = Console.ReadLine();
            Console.WriteLine("Please enter authors name: ");
            string tempAuthor = Console.ReadLine();
            book bookFour = new book(tempID, tempTitle, tempAuthor);

            displayBooks(bookOne);
            displayBooks(bookTwo);
            displayBooks(bookThree);
            displayBooks(bookFour);
        }
        static void displayBooks(book books)
        {
            Console.WriteLine("Book information");
            Console.WriteLine($"Book ID: {books.GetId()}");
            Console.WriteLine($"Book Title: {books.GetTitle()}");
            Console.WriteLine($"Book Author: {books.GetAuthor()}");
        }
    }
}