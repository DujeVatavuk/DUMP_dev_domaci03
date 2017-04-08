using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak02
{
    class Zad02
    {
        static void Main(string[] args)
        {
            Animal Puma = new Animal("Sd.Kfz 234", Animals.Puma, 10500, new DateTime(1943, 11, 10, 13, 25, 45));
            Animal Tiger = new Animal("Panzerkampfwagen VI", Animals.Tiger, 55000, new DateTime(1942, 3, 5, 8, 15, 0));
            Animal Leopard = new Animal("Leopard 2A6M", Animals.Leopard, 62300, new DateTime(2016, 5, 5, 8, 15, 0));


            Zoo ZooVrt = new Zoo()
            {
                Name = "Kubinka Zooloski Vrt",
                Food = 1939,
                Animals = new List<Animal>()
                {
                    Puma,
                    Tiger,
                    Leopard
                }
            };

            foreach(Animal animal in ZooVrt.Animals)
            {
                Console.WriteLine(animal.Print());
                Console.WriteLine("Je li zvijer gladna: " + animal.IsHungry());
            }

            ZooVrt.FeedAnimals();
            Console.WriteLine();
            Console.WriteLine();

            foreach (Animal animal in ZooVrt.Animals)
            {
                Console.WriteLine(animal.Print());
                Console.WriteLine("Je li zvijer gladna: " + animal.IsHungry());
            }

            Console.WriteLine();
        }

        enum Animals
        {
            Girrafe,
            Lion,
            Crocodile,
            Rihno,
            Elephant,
            Zebra,
            Hippo,
            Cheetah,
            Tiger,
            Puma,
            Python,
            Grizzly,
            Kangaroo,
            Koala,
            Leopard,
            Penguin,
            Fish
        }

        class Animal
        {
            public string Name;
            public Animals Animal_;
            public int Weight;
            public DateTime LastFed;

            public Animal(string name, Animals animal, int weight, DateTime lastfed)
            {
                Name = name;
                Animal_ = animal;
                Weight = weight;
                LastFed = lastfed;
            }

            public int Feed()
            {
                LastFed = DateTime.Now;
                int FoodDevoured = Weight / 20;
                if (FoodDevoured<1)
                {
                    FoodDevoured = 1;
                }
                return FoodDevoured;
            }

            public bool IsHungry()
            {
                if (((DateTime.Now - LastFed).Days > (Weight / 10)) && (DateTime.Now - LastFed).TotalHours > 24) 
                {
                    return true;
                }
                return false;
            }

            public string Print()
            {
                return $"{Name} {Animal_} {Weight} --> {LastFed}";
            }

        }

        class Zoo
        {
            public string Name;
            public double Food;
            public List<Animal> Animals;

            public void FeedAnimals()
            {
                foreach(Animal animal in Animals)
                {
                    Food -= animal.Feed();
                }
            }
        }
    }
}
