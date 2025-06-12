using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager manager = new GoalManager();

            // Load previously saved goals (if any)
            manager.LoadGoals("goals.txt");

            // EXTRA FEATURE: menu loop for repeated operations
            // (Explained as extra, per rubric requirement)
            while (true)
            {
                Console.WriteLine("\nEternal Quest Program");
                Console.WriteLine("1. Create Goal");
                Console.WriteLine("2. Record Event");
                Console.WriteLine("3. Display Goals");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Load Goals");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input—enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        manager.CreateGoal();
                        break;
                    case 2:
                        manager.RecordEvent();
                        break;
                    case 3:
                        manager.DisplayGoals();
                        break;
                    case 4:
                        manager.SaveGoals("goals.txt");
                        break;
                    case 5:
                        manager.LoadGoals("goals.txt");
                        break;
                    case 6:
                        return; // exit program
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
