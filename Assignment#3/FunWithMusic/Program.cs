using System;
namespace music
{
    class Program
    {
        enum Genre 
        {
            Rock,
            Country,
            Jazz,
            Alternative,
            Folk
        }

        struct Music 
        {
            private string Title;
            private string Artist;
            private string Album;
            private double Length;
            private Genre? Genre;

            public Music(string title, string artist, string album, double length, Genre genre)
            {
                Title = title;
                Artist = artist;
                Album = album;
                Length = length;
                Genre = genre;
            }

            public string Display()
            {
                return "Title: " + Title + "\nArtist: " + Artist +
                    "\nAlbum: " + Album + "\nLength: " + Length + "\nGenre: " + Genre;
            }
        }
        static void Main(string[] args) 
        { 
            
            Console.WriteLine("What is the song title?");
            string tempTitle = Console.ReadLine();
            Console.WriteLine("Name of band/artist");
            string tempArtist = Console.ReadLine();
            Console.WriteLine("Name of album?");
            string tempAlbum = Console.ReadLine();
            Console.WriteLine("Song length?");
            double tempLength = double.Parse(Console.ReadLine());
            Console.WriteLine("What is the genre?");
            Console.WriteLine("R - rock\nC - country\nJ - jazz\nA - alternative\nF - folk");
            Genre tempGenre = Genre.Rock;
            char g = char.Parse(Console.ReadLine());
            switch (g)
            {
                case 'R':
                    tempGenre = Genre.Rock;
                    break;
                case 'C':
                    tempGenre = Genre.Country;
                    break;
                case 'J':
                    tempGenre = Genre.Jazz;
                    break;
                case 'A':
                    tempGenre = Genre.Alternative;
                    break;
                case 'F':
                    tempGenre = Genre.Folk;
                    break;
            }
            Music music = new Music(tempTitle, tempArtist, tempAlbum, tempLength, tempGenre);
            Console.WriteLine($"{music.Display()}");
        }
    }
}