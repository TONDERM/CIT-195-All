using System;
using System.ComponentModel;
using System.Reflection.PortableExecutable;
using System.Text;

namespace greatAdventure
{
    class versionOne
    {
        static void Main(string[] args)
        {
            int lives = 0, magic = 0, health = 0, direction = 0, round = 0;
            Random r = new Random();
            bool win = false;
            Console.Write("What is the name of your character? ");
            string name = Console.ReadLine();
            Console.WriteLine("Welcome " + name);
            initValues(ref lives, ref magic, ref health, r);
            
            while (lives > 0 && magic > 0 && health > 0 && win == false)
            {
                direction = chooseDirection(direction);
                /* the direction impacts the number passed to the actions method
                 * if they choose left, they will only receive bad outcomes
                 * if they choose right, they have a better chance of receiving 
                 * good outcomes along with the bad outcomes */
                if (direction == 1)
                    actions(r.Next(4), ref lives, ref magic, ref health);
                else
                    actions(r.Next(10), ref lives, ref magic, ref health);

                checkResults(ref round, ref lives, ref magic, ref health, ref win);
            }
            if (win)
                Console.WriteLine("Congratulations on successfully completing your journey!");
            else if (lives <= 0)
                Console.WriteLine("You lost too many lives and did not complete your journey");
            else if (magic <= 0)
                Console.WriteLine("You don't have any magic left and cannot complete your journey");
            else
                Console.WriteLine("You are in poor health and had to stop your journey before it's completion");

        }
        static void initValues(ref int lives,ref int magic,ref int health, Random r) 
        {
            lives = r.Next(10) + 1;
            magic = r.Next(15) + 5;
            health = r.Next(14) + 5;
            Console.WriteLine("You have " + lives + " Lives");
            Console.WriteLine("You have " + magic + " Magic");
            Console.WriteLine("You have " + health + " Health");
        }

        static int chooseDirection(int direction) 
        {
            Console.WriteLine("You have come to a crossroad, enter 1 to travel left or enter 2 for right");
            Console.WriteLine();
            direction = int.Parse(Console.ReadLine());

            while (direction != 1 && direction != 2)
            {
                Console.WriteLine("You entered an invalid number, please enter a 1 for left or a 2 for right");
                direction = int.Parse(Console.ReadLine());
                Console.WriteLine();
                
            }
            return direction;
        }

        static void actions(int x, ref int lives, ref int magic, ref int health) 
        {
            int num = x;

            switch (num)
            {
                case 0:
                    Console.WriteLine("You met three bears who were not happy that their porridge was gone.");
                    Console.WriteLine("You lose 1 unit of health and 1 unit of magic");
                    Console.WriteLine();
                    health -= 1;
                    magic -= 1;
                    break;
                case 1:
                    Console.WriteLine("You were abducted by flying monkeys and had to be rescued by a young girl and a dog");
                    Console.WriteLine("You lost 2 units of health and magic and 1 life");
                    Console.WriteLine();
                    health -= 2;
                    magic -= 2;
                    lives -= 1;
                    break;
                case 2:
                    Console.WriteLine("You fell into a bottemless pit!");
                    Console.WriteLine("You are never heard or seen again");
                    Console.WriteLine();
                    health -= 1000;
                    magic -= 1000;
                    lives -= 1000;
                    break;
                case 3:
                    Console.WriteLine("You come across a giant spider.");
                    Console.WriteLine("You lost 4 units of health, 6 magic and 4 life");
                    Console.WriteLine();
                    health -= 4;
                    magic -= 6;
                    lives -= 4;
                    break;
                case 4:
                    Console.WriteLine("You arrive at an Inn");
                    Console.WriteLine("You gain 3 units of health, magic and life");
                    Console.WriteLine();
                    health += 3;
                    magic += 3;
                    lives += 3;
                    break;
                case 5:
                    Console.WriteLine("You saved a fellow traveler from a headless horseman.");
                    Console.WriteLine("The traveler granted you 2 units of health, magic and lives");
                    Console.WriteLine();
                    health += 2;
                    magic += 2;
                    lives += 2;
                    break;
                case 6:
                    Console.WriteLine("You babysat for a women who lived in a house that resembled a shoe (she had a lot of kids).");
                    Console.WriteLine("You gain 3 units of health and magic");
                    Console.WriteLine();
                    health += 3;
                    magic += 3;
                    break;
                case 7:
                    Console.WriteLine("You continue down the road");
                    Console.WriteLine();
                    break;
                case 8:
                    Console.WriteLine("You come across a fairy. She offers to help you on your journey!");
                    Console.WriteLine("You gain 1 units of health, 2 units magic");
                    Console.WriteLine();
                    health += 1;
                    magic += 2;
                    break;
                case 9:
                    Console.WriteLine("You find a mysterious gem");
                    Console.WriteLine("You gain 10 units of health, magic and life!");
                    Console.WriteLine();
                    health += 10;
                    magic += 10;
                    lives += 10;
                    break;
                default:
                    Console.WriteLine("You saved a unicorn from a mean wizard.");
                    Console.WriteLine("You gain 2 lives and 2 units of magic");
                    Console.WriteLine();
                    magic += 2;
                    lives += 2;
                    break;
            }
        }

        static void checkResults(ref int round, ref int lives, ref int magic, ref int health, ref bool win) 
        {


            if (round < 25)
            {
                round += 1;
                Console.WriteLine("~~~~~~~~~~~~~Round" + round + "~~~~~~~~~~~~~");
                Console.WriteLine("Lives: " + lives);
                Console.WriteLine("Magic: " + magic);
                Console.WriteLine("Health: " + health);
                Console.WriteLine();
            }
            else
                win = true;
   
            return;
        }
    }
}