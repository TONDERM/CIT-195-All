using System;
using System.ComponentModel;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TheMaze
{
    class playerOne
    {
        static void Main(string[] args)
        {
            int health = 0, hunger = 0, direction = 0, turn = 0;
            Random r = new Random();
            bool win = false;
            Console.Write("Who enters the Maze? ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Welcome " + name + "! Let your journey into the maze begin!\n");
            initValues(ref health, ref hunger, r);

            while (health > 0 && win == false)
            {
                direction = chooseDirection(direction);
                /* the direction impacts the number passed to the actions method
                 * if they choose left, they will only receive bad outcomes
                 * if they choose right, they have a better chance of receiving 
                 * good outcomes along with the bad outcomes */
                if (direction == 1)
                    actions(r.Next(0, 4), ref health, ref hunger);
                else if (direction == 2)
                    actions(r.Next(4, 8), ref health, ref hunger);
                else
                    actions(r.Next(8, 12), ref health, ref hunger);

                checkResults(ref turn, ref health, ref hunger, ref win);
            }
            if (win == true && health > 0)
            {
                Console.WriteLine("Congratulations! You've successfully navigated the maze and made it out alive!");
                Console.WriteLine("~~~~~~~~~~~~~~~~~ The End ~~~~~~~~~~~~~~~\n");
            }

            if (health <= 0 && hunger <= 0)
            {
                Console.WriteLine("Hunger has withered you away.  You are to week to move and perish in the maze.");
                Console.WriteLine("~~~~~~~~~~~~~~~~ GameOver ~~~~~~~~~~~~~~~\n");
            }

            if (health <= 0 && hunger > 0)
            {
                Console.WriteLine("You're body has taken to much punishment. You fall to the floor, lost to the maze.");
                Console.WriteLine("~~~~~~~~~~~~~~~~ GameOver ~~~~~~~~~~~~~~~\n");
            }
        }
        static void initValues(ref int health, ref int hunger, Random r)
        {
            health = r.Next(60, 100) ;
            hunger = r.Next(20,50);

            Console.WriteLine("Your health is at " + health);
            Console.WriteLine("If it reaches zero, you die. \n");
            Console.WriteLine("Your hunger is at " + hunger);
            Console.WriteLine("If it reaches zero, you will lose 10 health every turn. \n");
        }

        static int chooseDirection(int direction)
        {
            Console.WriteLine("You go further into the maze, enter 1 to travel left, 2 to go straight or 3 for right");
            Console.WriteLine();
            direction = int.Parse(Console.ReadLine());


            while (direction != 1 && direction != 2 && direction != 3)
            {
                Console.WriteLine("You entered an invalid number, please enter a 1 for left, 2 to go straight or 3 for right");
                direction = int.Parse(Console.ReadLine());
                Console.WriteLine();

            }
            return direction;
        }

        static void actions(int x,ref int health, ref int hunger)
        {

            int stats = x;

            switch (stats)
            {
                case 0:
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("You come across some delicious looking berries and eat a few.");
                    Console.WriteLine("The berries make you very ill.\n");
                    Console.WriteLine("Health -10");
                    Console.WriteLine("Hunger -30\n");
                    
                    health -= 10;
                    hunger -= 30;
                    break;

                case 1:
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("A giant nest of hornets sits in front of you. At the same time, a huge scorpion comes up from behind!");
                    Console.WriteLine("You have no choice but to pass the hornets nest as fast as possible.\n");
                    Console.WriteLine("Health -25");
                    Console.WriteLine("Hunger -15\n");
                    
                    health -= 25;
                    hunger -= 15;
                    break;

                case 2:
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("You find a friendly gnome, He offers you food and water!");
                    Console.WriteLine("After a delicious meal, you feel great!\n");
                    Console.WriteLine("Health +20");
                    Console.WriteLine("Hunger +30\n");

                    health += 20;
                    hunger += 30;
                    
                    break;

                case 3:
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("You find a forgotten pack with some rations inside!");
                    Console.WriteLine("You have a nice snack and are ready to move on.\n");
                    Console.WriteLine("Health +5");
                    Console.WriteLine("Hunger +10\n");
                    
                    health += 5;
                    hunger += 10;
                    break;
            //-----------------------------------------------------------------------------------------------------------------------------
                case 4:
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("You run into a bramble of sharp, thorny vines.  From behind you hear the growls of some unkown beast and have no choice!");
                    Console.WriteLine("You huridly stomp through the bramble, facing the wrath of many thorns.\n");
                    Console.WriteLine("Health -30");
                    Console.WriteLine("Hunger -10\n");

                    health -= 30;
                    hunger -= 10;
                    break;

                case 5:
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("You see a blinding light that floods the area!");
                    Console.WriteLine("Waking up on the floor, you are now very hungry and sore.\n");
                    Console.WriteLine("Health -15");
                    Console.WriteLine("Hunger -30\n");

                    health -= 15;
                    hunger -= 30;
                    break;

                case 6:
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("You find a box.  On the lid reads 'You are Welcome'. Inside is a warm meal!");
                    Console.WriteLine("The mysterious meal leaves you full and energized!\n");
                    Console.WriteLine("Health +20");
                    Console.WriteLine("Hunger +30\n");

                    health += 20;
                    hunger += 30;
                    break;

                case 7:
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("You see a rat and manage to kill it.  Hungry, you cook it up and eat.");
                    Console.WriteLine("Later on you suffer great vomiting and stomach pain.\n");
                    Console.WriteLine("Health -5");
                    Console.WriteLine("Hunger -20\n");

                    health -= 5;
                    hunger -= 20;
                    break;
                //-----------------------------------------------------------------------------------------------------------------------------
                case 8:
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("You suddenly feel a stab but do not know where it cames from! I feel another, then many more!");
                    Console.WriteLine(" There are no wounds but you are left very weak.  You hear a ghostly voice whisper 'REVENGE'.\n");
                    Console.WriteLine("Health -20");
                    Console.WriteLine("Hunger -10\n");

                    health -= 20;
                    hunger -= 10;
                    break;

                case 9:
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("A swarm of gnats follow you around, swirling around your head");
                    Console.WriteLine("You are annoyed.\n");
                    Console.WriteLine("Health -2");
                    Console.WriteLine("Hunger -2\n");

                    health -= 2;
                    hunger -= 2;
                    break;

                case 10:
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("Something smells good.  You track the scent to a crack in the wall and break it open.  Inside is a big turkey leg!");
                    Console.WriteLine("You've heard of this before... wall food!  You eat the turkey and feel refreashed.\n");
                    Console.WriteLine("Health +20");
                    Console.WriteLine("Hunger +30\n");

                    health += 20;
                    hunger += 30;
                    break;

                case 11:
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("You come across an apple on the floor. A sign besides it says 'One bite' you decide to take the offer and bite into the apple.");
                    Console.WriteLine("It's amazing and fills you up!  You take another bite and immediately feel terrible but still full.  You decide not to take anymore bites.\n");
                    Console.WriteLine("Health -30");
                    Console.WriteLine("Hunger +20\n");

                    health -= 30;
                    hunger += 20;
                    break;

                default:
                    Console.WriteLine("You continue.");
                    Console.WriteLine();

                    break;
            }

        }

        static void checkResults(ref int turn, ref int health, ref int hunger, ref bool win)
        {


            if (turn < 30 && health > 0)
            {
                turn += 1;

                Console.WriteLine("---------------------");
                Console.WriteLine("|  Total Health: " + health);
                Console.WriteLine("|  Total Hunger: " + hunger);
                Console.WriteLine("---------------------");
                Console.WriteLine("~~~~~~~~~~~~~ End of Turn " + turn + " ~~~~~~~~~~~~~\n");
            }

            else if (turn < 30 && hunger <= 0)
            {
                turn += 1;
                health -= 10;
               
                Console.WriteLine("***You are very hungry and need food!*** \n");
                Console.WriteLine("---------------------");
                Console.WriteLine("|  Total Health: " + health);
                Console.WriteLine("|  Total Hunger: " + hunger);
                Console.WriteLine("---------------------");
                Console.WriteLine("~~~~~~~~~~~~~ End of Turn " + turn + " ~~~~~~~~~~~~~\n");
            }

            else if (turn < 30 && health <=0)
            {
                Console.WriteLine("***You are Dead*** \n");
                Console.WriteLine("---------------------");
                Console.WriteLine("|  Total Health: " + health);
                Console.WriteLine("|  Total Hunger: " + hunger);
                Console.WriteLine("---------------------");
            }
            else
                win = true;

            return;
        }
    }
}
