using System;
using System.Collections.Generic;
using System.Text;

namespace DB4_DiceRolling
{
    class DiceRollerApp
    {
        private static Random generator;

        public static void Start()
        {
            //initialize the random number generator
            generator = new Random();

            int rollCount = 1;
            int dieSides;
            
            Console.WriteLine("Welcome to the GC Casino!");
            Console.Write("How many sides should each die have? ");
            
            //die side validation, no less than 2 sides are allowed.
            while(!int.TryParse(Console.ReadLine(), out dieSides) || dieSides <= 1)
            {
                Console.Write("\nThat was invalid, how many sides should each die have? ");
            }

            //Main loop, Roll the dice, print the results to the console.
            do
            {
                PrintResults(rollCount, dieSides, RollDie(dieSides), RollDie(dieSides));
                Console.WriteLine();
                rollCount++;
            } while (RollAgain());
            Console.WriteLine("Thanks for playing!!");
        }

        static int RollDie(int dieSides)
        {
            return generator.Next(dieSides) + 1;
        }

        static void PrintResults(int rollNumber, int dieSides, int resultOne, int resultTwo)
        {
            int total = resultOne + resultTwo;
            Console.WriteLine($"Roll {rollNumber}:");
            Console.WriteLine($"You rolled a {resultOne} and a {resultTwo} ({total} total)");
            if(dieSides == 6)
            {
                //known combinations on 6 sided die
                if(total == 2)
                {
                    Console.WriteLine("Snake Eyes");
                }
                else if (total == 3)
                {
                    Console.WriteLine("Ace Deuce");
                }
                else if (total == 12)
                {
                    Console.WriteLine("Box Cars");
                }
                else if (total == 7 || total == 11)
                {
                    Console.WriteLine("Win!");
                }
                //possible with above combination.
                if (total == 2 || total == 3 || total == 12)
                {
                    Console.WriteLine("Craps!");
                }
            }
        }

        static bool RollAgain()
        {
            Console.Write("Roll again? (y/n): ");
            ConsoleKey choice = Console.ReadKey().Key;
            Console.WriteLine();
            if(choice == ConsoleKey.Y)
            {
                return true;
            }
            else if (choice == ConsoleKey.N)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid Entry.");
                return RollAgain(); //call back to prompt again.
            }
        }
    }
}
