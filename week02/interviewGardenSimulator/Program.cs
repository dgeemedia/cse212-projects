using System;
using System.Collections.Generic;

namespace GardenSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            SeedBasket basket = new SeedBasket();
            // LIFO: Tomato planted before Pumpkin
            basket.AddSeeds("Pumpkin", 10);
            basket.AddSeeds("Tomato", 15);
            basket.AddSeeds("Peas", 5);

            Console.WriteLine("Planting seeds in order:");
            while (!basket.IsEmpty())
            {
                var seed = basket.PlantSeed();
                Console.WriteLine($"Planted: {seed}");
            }
        }
    }

    public class SeedBasket
    {

        //Hi, my name is Lucky George Olumah, and i will be running you through GARDEN SIMULATOR GAME
        //Let build this game together
        //Players collect piles of seeds
        //Each player can only plant the most recently picked-up seed pile
        //Once a pile is depleted, the next most recent is used
        //This seeds are planted in LAST-IN, FIRST-OUT order
        private Stack<SeedPile> _stack = new(); //Chosen Data Structure - STACK

        public void AddSeeds(string type, int count) // Push () new pile to top and stores the Type and remaining Count.
        {
            _stack.Push(new SeedPile(type, count));
        }

        public string PlantSeed() // Peek () top pile and decrement
        {
            if (IsEmpty()) throw new InvalidOperationException("No seeds left to plant.");
            var top = _stack.Peek();
            string seedType = top.Type;
            top.Count--;
            if (top.Count == 0) // Pop () it
                _stack.Pop();
            return seedType;
        }

        public bool IsEmpty()
        {
            return _stack.Count == 0;
        }
    }

    public class SeedPile
    {
        public string Type { get; }
        public int Count { get; set; }

        public SeedPile(string type, int count)
        {
            Type = type;
            Count = count;
        }
    }
}
