using System;
using System.Drawing;
using System.Xml.Linq;

namespace Inheritance
{

    // base class
    class Animal
    {
        public string name;
        public string type;
        public string toy;
       

        // constructor
        public Animal()
        {
            name = "";
            type = "";
            toy = "";

        }
        //parameterized constructor
        public Animal(string name, string type, string toy)
        {
            this.name = name;
            this.type = type;
            this.toy = toy;
        }

        public void display()
        {
            Console.WriteLine($"I am an animal, my name is {name}\n");
        }

    }

    // derived class of Animal 
    class Dog : Animal
    {
        public double age;
        public double weight;
        public string color;

        public Dog() : base() 
        {
            age = 0;
            weight = 0;
            color = "";
        }

        public Dog(string name, string type, string toy, double age, double weight, string color) : base(name, type, toy)
        {
            this.age = age;
            this.weight = weight;
            this.color = color;
        }

        public void getName()
        {

            Console.WriteLine($"Name: {name}");
        }

        public void getType()
        {         
            Console.WriteLine($"Breed: {type}");
        }

        public void getToy()
        {
            Console.WriteLine($"Their favorite toy is: {toy}");
        }
        public void getColor()
        {
            Console.WriteLine($"Color: {color}");
        }
        public void getAge()
        {
            Console.WriteLine($"Age: {age}");
        }
        public void getWeight()
        {
            Console.WriteLine($"Weight: {weight}\n");
        }


    }

    class Cat : Animal
    {

        public double age;
        public double weight;
        public string color;

        public Cat() : base()
        {
            age = 0;
            weight = 0;
            color = "";
        }

        public Cat(string name, string type, string toy, double age, double weight, string color) : base(name, type, toy)
        {
            this.age = age;
            this.weight = weight;
            this.color = color;
        }
        public void getName()
    {

        Console.WriteLine($"Name: {name}");
    }

    public void getType()
    {
        Console.WriteLine($"Breed: {type}");
    }

    public void getToy()
    {
        Console.WriteLine($"Their favorite toy is: {toy}");
    }

    public void sound()
    {
        Console.WriteLine($"I like to meow");
    }
        public void getColor()
    {
        Console.WriteLine($"Color: {color}");
    }
    public void getAge()
    {
        Console.WriteLine($"Age: {age}");
    }
    public void getWeight()
    {
        Console.WriteLine($"Weight: {weight}\n");
    }
}

    class Program
    {
        static void Main(string[] args)
        {
            // object of base class
            Dog myDog = new Dog();
            myDog.name = "Sparky";
            myDog.type = "Brittany Spaniel";
            myDog.toy = "Bone";
            myDog.display();

            myDog.age = 4;
            myDog.weight = 31.4;
            myDog.color = "Brown and White";
            myDog.getName();
            myDog.getType();
            myDog.getToy();
            myDog.getColor();
            myDog.getAge();
            myDog.getWeight();
            

            Dog stan = new Dog("Stan", "Lab", "Stuffed Bunny", 48.3, 10, "black");
            //stan.display();
            stan.getName();
            stan.getType();
            stan.getToy();
            stan.getColor();
            stan.getAge();
            stan.getWeight();


            Cat myCat = new Cat();
            myCat.name = "FishSticks";
            myCat.type = "Siberian";
            myCat.toy = "Rubber Mouse";
            myCat.display();

            myCat.age = 2;
            myCat.weight = 6.4;
            myCat.color = "White";
            myCat.getName();
            myCat.getType();
            myCat.sound();
            myCat.getToy();
            myCat.getColor();
            myCat.getAge();
            myCat.getWeight();


            Cat whiskers = new Cat("Whiskers", "Persian", "Yarn Ball", 8.3, 6, "Golden Brown");
            //stan.display();
            whiskers.getName();
            whiskers.getType();
            whiskers.sound();
            whiskers.getToy();
            whiskers.getColor();
            whiskers.getAge();
            whiskers.getWeight();
            // derived class object using default constructor


            //derived class object using parameterized constructor

        }

    }
}