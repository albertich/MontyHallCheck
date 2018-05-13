using System;
using System.Linq;

namespace MontyHallCheck
{
    internal class Program
    {
        private static readonly Random Rnd = new Random((int)DateTime.Now.Ticks);

        private static void Main(string[] args)
        {
            Console.WriteLine("Start application");

            var count = GetIterationCount();

            float winCounter = 0;

            for (var i = 0; i < count; i++)
            {
                var prizeDoor = GetRandomDoor();

                var playerDoor = GetRandomDoor();

                if (prizeDoor == playerDoor)
                    winCounter++;
            }

            Console.WriteLine($"If did't change choice: {winCounter}/{count} ({winCounter/count:0.00}%)");

            winCounter = 0;

            for (var i = 0; i < count; i++)
            {
                var prizeDoor = GetRandomDoor();

                var playerDoor = GetRandomDoor();

                //  showman select not player and not prize door (they can be equal)
                var showmanDoor = GetRandomDoor(prizeDoor, playerDoor);

                //  player change his choice
                var newPlayerDoor = 3 - playerDoor - showmanDoor;

                if (prizeDoor == newPlayerDoor)
                    winCounter++;
            }

            Console.WriteLine($"If choice has changed: {winCounter}/{count} ({winCounter / count:0.00}%)");

            Console.WriteLine("Application complete");
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }

        /// <summary>
        /// Return the number of one of three doors
        /// </summary>
        /// <param name="except">Skipped numbers</param>
        /// <returns></returns>
        private static int GetRandomDoor(params int[] except)
        {
            int door;
            do
            {
                door = Rnd.Next(3);
            } while (except.Contains(door));

            return door;
        }

        /// <summary>
        /// Return number of iterations
        /// </summary>
        /// <returns></returns>
        private static int GetIterationCount()
        {
            Console.WriteLine("Enter number of iterations...");

            while (true)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine($"String is null or whitespace, try again...");
                    continue;
                }

                int count;

                if (!int.TryParse(line, out count))
                {
                    Console.WriteLine($"{count} is not a number, try again...");
                    continue;
                }

                if (count <= 0)
                {
                    Console.WriteLine($"{count} is invalid. Number must be greater than zero, try again...");
                    continue;
                }

                return count;
            }
        }
    }
}
