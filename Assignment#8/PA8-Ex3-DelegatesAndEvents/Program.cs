﻿using System;

namespace delegatesAndEvents
{
    // create a delegate
    public delegate void Result(int n);
    public class Race
    {
        // create a delegate event object
        public event Result RaceOver;
        public void Racing(int contestants, int laps)
        {
            Console.WriteLine("Ready\nSet\nGo!");
            Random r = new Random();
            int[] participants = new int[contestants];
            bool done = false;
            int champ = -1;
            // first to finish specified number of laps wins
            while (!done)
            {
                for (int i = 0; i < contestants; i++)
                {

                    if (participants[i] <= laps)
                    {
                        participants[i] += r.Next(1, 5);
                    }
                    else
                    {
                        champ = i;
                        done = true;
                        continue;
                    }
                }

            }

            TheWinner(champ);
        }
        private void TheWinner(int champ)
        {
            Console.WriteLine("We have a winner!");
            // invoke the delegate event object and pass champ to the method
            RaceOver(champ);

        }
    }
    class Program
    {
        public static void Main()
        {
            // create a class object
            Race round1 = new Race();
            // register with the footRace event
            round1.RaceOver += footRace_raceOver;

            // trigger the event
            round1.Racing(20, 3);
            // register with the carRace event
            round1.RaceOver -= footRace_raceOver;
            round1.RaceOver += carRace_raceOver;
            //trigger the event
            round1.Racing(20,3);
            // register a bike race event using a lambda expression
            round1.RaceOver -= carRace_raceOver;
            //round1.RaceOver += bikeRace_raceOver;
            round1.RaceOver += (winner) => Console.WriteLine($"Biker number {winner} is the bike race winner");
            // trigger the event
            round1.Racing(20,3);
        }

        // event handlers
        public static void carRace_raceOver(int winner)
        {
            Console.WriteLine($"Car number {winner} is the car race winner.");
        }
        public static void footRace_raceOver(int winner)
        {
            Console.WriteLine($"Runner number {winner} is the foot race winner.");
        }
    }
}