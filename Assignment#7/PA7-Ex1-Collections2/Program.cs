using System.Collections.Generic;

namespace WorkingWithDictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> ProductList = new Dictionary<string, string>();

             //Adding Products
             ProductList.Add("Milk", "Dairy");
             ProductList.Add("Cheetos", "Snacks");
             ProductList.Add("Honey Ham", "Meat");
             ProductList.Add("Football", "Sports");
             ProductList.Add("Shampoo", "Bath");

            Console.WriteLine();
            Console.WriteLine("--------------Dictionary---------------");
            Console.WriteLine();

            Console.WriteLine("ProductList Keys");
             Dictionary<string, string>.KeyCollection keys = ProductList.Keys;
             foreach (string k in keys)
             {
                 Console.WriteLine("Key: {0}", k);
             }
             Console.WriteLine();

             Console.WriteLine("ProductList Values");
             Dictionary<string, string>.ValueCollection values = ProductList.Values;
             foreach (string v in values)
             {
                 Console.WriteLine("Value: {0}", v);
             }
             Console.WriteLine();

             Console.WriteLine("ProductsList Key/Value Pairs");
             foreach (KeyValuePair<string, string> kvp in ProductList)
             {
                 Console.WriteLine($"Key: {kvp.Key}  Value: {kvp.Value}");
             }
             Console.WriteLine();

             // Changing values
             ProductList["Honey Ham"] = "Deli";
             ProductList["Shampoo"] = "Beauty";
             ProductList.Remove("Football");

             Console.WriteLine("Revised ProductList Key/Value Pairs");
             foreach (KeyValuePair<string, string> kvp in ProductList)
             {
                 Console.WriteLine($"Key: {kvp.Key}  Value: {kvp.Value}");
             }
             Console.WriteLine();

            Console.WriteLine($"There are {ProductList.Count} products in your list");
            foreach (KeyValuePair<string, string> kvp in ProductList)
            {
                Console.WriteLine($"Product Type: {kvp.Key}   Department: {kvp.Value}");
            }
            Console.WriteLine();

            //---------------creation of sortedlist----------------------------------------  

            Console.WriteLine();
            Console.WriteLine("--------------sortedList---------------");
            Console.WriteLine();

            SortedList<string, string> capitalsList = new SortedList<string, string>();
            //add the elements in sortedlist  
            capitalsList.Add("Michigan", "Lansing");
            capitalsList.Add("Colorado", "Denver");
            capitalsList.Add("Kansas", "Topeka");
            capitalsList.Add("Oregon", "Salem");
            capitalsList.Add("Rhode Island", "Providence");
            bool addList = true;
            //display the elements of the sortedlist  

            Console.WriteLine("The cities in my sorted capitals list are:");
            foreach (KeyValuePair<string, string> cl in capitalsList)
            {
                Console.WriteLine($"Key = {cl.Key}  Value={cl.Value}");
            }

            Console.WriteLine();
            Console.WriteLine("What capital would you like to visit?");
            string city = Console.ReadLine();
            Console.WriteLine("What state is it in?");
            string state = Console.ReadLine();
            //check for value in list
            
            
                if (capitalsList.ContainsValue(city))
                    Console.WriteLine($"{city}, {state} is one of the capitals on your list");
                else
                {

                        // check for state key in list (can't have dups)
                        if (capitalsList.ContainsKey(state))
                        {
                            Console.WriteLine($"{city} is not the capitol of {state} ");
                            capitalsList.Remove(state);
                            capitalsList.Add(state, city);
                            Console.WriteLine($"Your current capital {city} has been removed and {city} has been added");
                        }

                        else
                        {

                            Console.WriteLine($"{city}, {state} is not on the list.  Do you want to add it? (y for yes, any key for no)");
                            string answer = Console.ReadLine();
                            if (answer == "y")
                            {
                                capitalsList.Add(state, city);
                                Console.WriteLine($"{city}, {state} was added to your list");


                            }
                            

                    }
                }
            
            Console.WriteLine("The cities in the new capitals list are:");
            foreach (KeyValuePair<string, string> cl in capitalsList)
            {
                Console.WriteLine($"Key = {cl.Key}  Value={cl.Value}");
            }
            

            //---------------creation of HashSet---------------------------------------- 

            HashSet<string> oddNumbers = new HashSet<string>();
            oddNumbers.Add("01");
            oddNumbers.Add("03");
            oddNumbers.Add("05");
            oddNumbers.Add("07");
            oddNumbers.Add("09");


            HashSet<string> evenNumbers = new HashSet<string>();
            evenNumbers.Add("02");
            evenNumbers.Add("04");
            evenNumbers.Add("06");
            evenNumbers.Add("08");
            evenNumbers.Add("10");


            HashSet<string> primeNumbers = new HashSet<string>();
            primeNumbers.Add("02");
            primeNumbers.Add("03");
            primeNumbers.Add("05");
            primeNumbers.Add("07");
            primeNumbers.Add("11");

            Console.WriteLine();
            Console.WriteLine("--------------HashSet---------------");
            Console.WriteLine();

            Console.WriteLine("Combined list of odds and evens");
            oddNumbers.UnionWith(evenNumbers);

            IEnumerable<string> sortAscendingQuery =
            from numbers in oddNumbers
            orderby numbers
            select numbers;

            //I know it was supposed to be (string numbers in oddNumbers)// 
            foreach (string numbers in sortAscendingQuery)
            {
                Console.WriteLine(numbers);
            }
            Console.WriteLine();

            Console.WriteLine("Numbers that are in both lists");
            HashSet<string> bothLists = new HashSet<string>();
            bothLists = oddNumbers;
            bothLists.IntersectWith(primeNumbers);
            //I know it was supposed to be (string numbers in bothLists)// 
            foreach (string numbers in sortAscendingQuery)
            {
                Console.WriteLine(numbers);
            }

            Console.WriteLine();
            Console.WriteLine("--------------List---------------");
            Console.WriteLine();

            List<string> simpsonsMain = new List<string> { "Homer", "Marge", "Lisa", "Bart", "Maggie" };
            string[] simpsonsSecondary = new string[] { "Flanders", "Apu", "Barney" };
            simpsonsMain.AddRange(simpsonsSecondary);

            simpsonsMain.Sort();
            Console.WriteLine("-------A-Z--------");
            foreach (string s in simpsonsMain)
            Console.WriteLine(s);

            simpsonsMain.Remove("Apu");
            //simpsonsMain.Remove(simpsonsMain[6]);

            simpsonsMain.Reverse();
            Console.WriteLine("-------Z-A--------");
            foreach (string s in simpsonsMain)
            Console.WriteLine(s);
        }

    }
}