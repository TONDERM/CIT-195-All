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

            public void setTitle(string title)
            {
                Title = title;
            }
            public void setArtist(string artist)
            {
                Artist = artist;
            }

            public void setAlbum(string album)
            {
                Album = album;
            }

            public void setLength(double length)
            {
                Length = length;
            }

            public void setGenre(Genre genre)
            {
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
            Console.WriteLine("How many songs would you like to enter?");
            int size = int.Parse(Console.ReadLine());
            Music[] collection = new Music[size];

            try
            {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine("What is the song title?");
                    collection[i].setTitle(Console.ReadLine());

                    Console.WriteLine("Name of band/artist?");
                    collection[i].setArtist(Console.ReadLine());

                    Console.WriteLine("Name of album?");
                    collection[i].setAlbum(Console.ReadLine());

                    Console.WriteLine("Song Length?");
                    collection[i].setLength(double.Parse(Console.ReadLine()));

                    Console.WriteLine("What is the genre?");
                    Console.WriteLine("R - rock\nC - country\nJ - jazz\nA - alternative\nF - folk");
                    collection[i].setGenre(Genre.Rock);

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
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally 
            {
                for (int i = 0; i < size; i++) 
                {
                    Console.WriteLine($"{collection[i].Display()}");
                }
            }
        }
    }
}