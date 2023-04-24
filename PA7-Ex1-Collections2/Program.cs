using System.Collections.Generic;

namespace WorkingWithDictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Dictionary<string, string> EmployeeList = new Dictionary<string, string>();
             Dictionary<string, Int16> DepartmentList = new Dictionary<string, Int16>();
             Dictionary<string, float> SalaryList = new Dictionary<string, float>(5);

             //Adding Employees
             EmployeeList.Add("Jo Schmoo", "Programmer");
             EmployeeList.Add("Ro Schmoo", "Project Manager");
             EmployeeList.Add("Flo Schmoo", "Architect");
             EmployeeList.Add("Mo Schmoo", "Asst. Project Manager");
             EmployeeList.Add("Bo Schmoo", "Manager");

             Console.WriteLine("EmployeeList Keys");
             Dictionary<string, string>.KeyCollection keys = EmployeeList.Keys;
             foreach (string k in keys)
             {
                 Console.WriteLine("Key: {0}", k);
             }
             Console.WriteLine();

             Console.WriteLine("EmployeeList Values");
             Dictionary<string, string>.ValueCollection values = EmployeeList.Values;
             foreach (string v in values)
             {
                 Console.WriteLine("Value: {0}", v);
             }
             Console.WriteLine();

             Console.WriteLine("EmployeeList Key/Value Pairs");
             foreach (KeyValuePair<string, string> kvp in EmployeeList)
             {
                 Console.WriteLine($"Key: {kvp.Key}  Value: {kvp.Value}");
             }
             Console.WriteLine();
             // Changing values
             EmployeeList["Jo Schmoo"] = "Sr. Programmer";
             EmployeeList["Ro Schmoo"] = "Programmer";
             EmployeeList.Remove("Flo Schmoo");

             Console.WriteLine("Revised EmployeeList Key/Value Pairs");
             foreach (KeyValuePair<string, string> kvp in EmployeeList)
             {
                 Console.WriteLine($"Key: {kvp.Key}  Value: {kvp.Value}");
             }
             Console.WriteLine();

             //Adding Departments
             DepartmentList.Add("IT", 2);
             DepartmentList.Add("Management", 1);
             DepartmentList.Add("Construction", 3);
             DepartmentList.Add("Sales", 4);
             bool addDept = true;
             while (addDept)
             {
                 Console.WriteLine("Enter the name of the department you wish to add");
                 string deptName = Console.ReadLine();
                 if (DepartmentList.ContainsKey(deptName))
                 {
                     DepartmentList.Remove(deptName);
                 }
                 Console.WriteLine("Enter the department number you wish to add");
                 Int16 deptNum = Int16.Parse(Console.ReadLine());
                 DepartmentList.Add(deptName, deptNum);
                 Console.WriteLine("The department has been added");
                 Console.WriteLine("Add another? (y for yes, any key for no)");
                 string answer = Console.ReadLine();
                 if (answer == "y")
                     continue;
                 else
                     addDept = false;

             }
             Console.WriteLine($"There are {DepartmentList.Count} departments in your list");
             foreach (KeyValuePair<string, Int16> kvp in DepartmentList)
             {
                 Console.WriteLine($"Department Name: {kvp.Key}   Number: {kvp.Value}");
             }
             Console.WriteLine();

             //Adding Salaries
             SalaryList.Add("Programmer", 80000f);
             SalaryList.Add("Architect", 75000f);
             SalaryList.Add("Sales", 50000f);
             SalaryList.Add("Manager", 65000f);
             SalaryList.Add("Asst Manager", 40000f);

             // Salary list with formatted output
             Console.WriteLine("Salaries for different positions");
             foreach (KeyValuePair<string, float> kvp in SalaryList)
             {
                 Console.WriteLine($"Position: {kvp.Key}   Salary: " + String.Format("{0:C}", kvp.Value));
             }
             Console.WriteLine();
            */

            //---------------creation of sortedlist----------------------------------------  

            /*SortedList<string, string> bucketList = new SortedList<string, string>();
            //add the elements in sortedlist  
            bucketList.Add("Italy", "Venice");
            bucketList.Add("UK", "England");
            bucketList.Add("France", "Cannes");
            bucketList.Add("Greece", "Athens");
            bucketList.Add("Spain", "Barcelona");
            bool addList = true;
            //display the elements of the sortedlist  
            Console.WriteLine("The items in my sorted bucket list are:");
            foreach (KeyValuePair<string, string> bl in bucketList)
            {
                Console.WriteLine($"Key = {bl.Key}  Value={bl.Value}");
            }


            Console.WriteLine("What city would you like to go to?");
            string city = Console.ReadLine();
            Console.WriteLine("What country is it in?");
            string country = Console.ReadLine();
            //check for value in list
            
            
                if (bucketList.ContainsValue(city))
                    Console.WriteLine($"{city} is one of the values in your list");
                else
                {
                    while (addList)
                    {
                        // check for country key in list (can't have dups)
                        if (bucketList.ContainsKey(country))
                        {
                            Console.WriteLine($"You can only visit 1 city from {country} ");
                            bucketList.Remove(country);
                            bucketList.Add(country, city);
                            Console.WriteLine($"Your current city in {country} has been removed and {city} has been added");
                        }
                        else
                        {

                            Console.WriteLine($"{city} {country} is not on the list.  Do you want to add it? (y for yes, any key for no)");
                            string answer = Console.ReadLine();
                            if (answer == "y")
                            {
                                bucketList.Add(country, city);
                                Console.WriteLine($"{city} {country} was added to your list");


                            }
                            
                            addList = false;
                        }
                    }
                }
            
            Console.WriteLine("The items in my new bucket list are:");
            foreach (KeyValuePair<string, string> bl in bucketList)
            {
                Console.WriteLine($"Key = {bl.Key}  Value={bl.Value}");
            }
            */

            //---------------creation of HashSet---------------------------------------- 

            HashSet<string> languages = new HashSet<string>();
            languages.Add("C#");
            languages.Add(".NET");
            languages.Add("Java");
            languages.Add("Python");

            HashSet<string> olderLanguages = new HashSet<string>();
            olderLanguages.Add("C");
            olderLanguages.Add("C++");
            olderLanguages.Add("PHP");

            HashSet<string> webLanguages = new HashSet<string>();
            webLanguages.Add("JavaScript");
            webLanguages.Add(".NET");
            webLanguages.Add("PHP");

            Console.WriteLine("Combined list of older and newer languages");
            languages.UnionWith(olderLanguages);
            foreach (string language in languages)
            {
                Console.WriteLine(language);
            }
            Console.WriteLine();

            Console.WriteLine("Languages that are in both lists");
            HashSet<string> bothLists = new HashSet<string>();
            bothLists = languages;
            bothLists.IntersectWith(webLanguages);
            foreach (string language in bothLists)
            {
                Console.WriteLine(language);
            }
        }

    }
}