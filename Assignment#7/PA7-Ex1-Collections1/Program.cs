using System;
using System.Collections.Generic;
using System.Drawing;

namespace FunwithQueues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creates the cereal queue
            Queue<string> cereal = new Queue<string>();
            PriorityQueue<string, int> words = new PriorityQueue<string, int>();
            Stack<string> color = new Stack<string>();

            //adding cereals (queue)
            cereal.Enqueue("Fruit Loops");
            cereal.Enqueue("Captain Crunch");
            cereal.Enqueue("Cheerios");
            cereal.Enqueue("Frosted Flakes");
            cereal.Enqueue("Trix");

            //adding words (priority queue)
            words.Enqueue("Salad", 1);
            words.Enqueue("Beef", 3);
            words.Enqueue("Slug", 2);
            words.Enqueue("Bathroom", 1);
            words.Enqueue("Tire", 3);

            //adding colors (stack)
            color.Push("Red");
            color.Push("Purple");
            color.Push("Blue");
            color.Push("Yellow");
            color.Push("Green");

            // adding more cereals
            Console.WriteLine("How many other cereals would you like to add?");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Console.Write($"Cereal: ");
                cereal.Enqueue(Console.ReadLine());
            }

            Console.WriteLine();

            // adding more colors
            Console.WriteLine("How many other colors would you like to add?");
            int numC = int.Parse(Console.ReadLine());
            for (int i = 0; i < numC; i++)
            {
                Console.Write($"Color: ");
                color.Push(Console.ReadLine());
            }

            Console.WriteLine();

            // counts the words in the queue
            Console.WriteLine($"There are {words.Count} words in the queue");
            while (words.TryDequeue(out string item, out int priority))
            {
                Console.WriteLine($"Dequeued Item : {item} Priority Was : {priority}");
            }

            Console.WriteLine();

            // counts the cereals in the queue
            Console.WriteLine($"Here are your {cereal.Count()} cereals");

            // displays the queue contents without removing anything
            foreach (var m in cereal)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine();

            // counts the colors in the Stack
            Console.WriteLine($"Here are your {color.Count()} colors");

            // displays the Stack contents without removing anything
            foreach (var m in color)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine();

            // views the first item in the queue and displays it to determine if the user wants to remove it
            string firstCereal = cereal.Peek();
            Console.WriteLine($"Would you like to remove {firstCereal} from the beginning of the queue (yes or no)?");
            string answer = Console.ReadLine();
            while (answer == "yes")
            {
                cereal.Dequeue(); // removes cereal from the top of the queue
                firstCereal = cereal.Peek();
                Console.WriteLine($"Would you like to remove {firstCereal} from the beginning of the queue (yes or no)?");
                answer = Console.ReadLine();
            }

            if (cereal.Peek() == null)
                Console.WriteLine("The queue is empty");
            else
                Console.WriteLine($"You have {cereal.Count} left in the queue");

            Console.WriteLine();

            // Check for a color in the Stack
            Console.WriteLine("Would you like to look for a color (yes or no)");
            string answerC = Console.ReadLine();
            while (answerC == "yes")
            {
                Console.WriteLine("Enter the color you would like to search for");
                string colorName = Console.ReadLine();
                if (color.Contains(colorName))
                {
                    Console.WriteLine("That color is in the stack.");
                }
                else
                {
                    Console.WriteLine("I am sorry, that color is not in the stack.");
                }
                Console.WriteLine("Would you like to look for another color (yes or no)");
                answerC = Console.ReadLine();
            }

            Console.WriteLine();

            string lastColor = color.Peek();   // retrieves the LAST color
            Console.WriteLine($"Would you like to remove {lastColor} from the end of the Stack (yes or no)?");
            string answerB = Console.ReadLine();
            while (answerB == "yes")
            {
                color.Pop();  // Removes the LAST color
                lastColor = color.Peek();
                Console.WriteLine($"Would you like to remove {lastColor} from the end of the Stack (yes or no)?");
                answerB = Console.ReadLine();
            }

            if (color.Peek() == null)
                Console.WriteLine("The Stack is empty");
            else
                Console.WriteLine($"You have {color.Count} left in the Stack");

            //-----------------------LinkedList&LinkNodeList--------------------------------------------------------------------------------
            Console.WriteLine();

            // Create the link list.
            string[] states =
                { "Michigan", "California", "Maine", "Texas", "North Dakota", "Florida" };
            LinkedList<string> stateList = new LinkedList<string>(states);
            Console.WriteLine("Original list of states");
            foreach (string state in stateList)
            {
                Console.WriteLine(state);
            }
            Console.WriteLine();

            stateList.AddLast("Washington");
            stateList.AddFirst("West Virginia");

            //Retrieving the node associated with Maine
            LinkedListNode<string> targetLocation = stateList.Find("Maine");
            //Using the Next property of LinkedListNode < T > to display the value of the next state
            Console.WriteLine("The current state in the list after Maine is {0}", targetLocation.Next.Value);
            Console.WriteLine();
            stateList.AddAfter(targetLocation, "Utah");
            stateList.AddBefore(targetLocation, "Kentucky");
            Console.WriteLine("List of states with additions");
            foreach (string state in stateList)
            {
                Console.WriteLine(state);
            }
            Console.WriteLine();
            stateList.RemoveFirst();
            stateList.RemoveLast();
            Console.WriteLine("List of states after deletions");
            foreach (string state in stateList)
            {
                Console.WriteLine(state);
            }
            Console.WriteLine();

            // Create an array with the same number of
            // elements as the linked list.
            string[] stateArray = new string[stateList.Count];
            stateList.CopyTo(stateArray, 0);
            Console.WriteLine("stateList is now stateArray");
            foreach (string s in stateArray)
            {
                Console.WriteLine(s);
            }

            // Release all the nodes.
            stateList.Clear();

        }
    }
}