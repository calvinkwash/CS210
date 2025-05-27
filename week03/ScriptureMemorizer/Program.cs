using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a scripture reference

            Reference reference = new Reference("Proverbs", 3, 5, 6);

            // Scripture text
            string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";

            // Create a scripture object
            Scripture scripture = new Scripture(reference, text);

            // Main loop
            while (true)
            {
                // Display the scripture
                scripture.Display();

                // Check if all words are hidden
                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("\nAll words have been hidden. Press any key to exit.");
                    Console.ReadKey();
                    break;
                }

                // Prompt user
                Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "quit")
                {
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                }

                // Hide random words
                scripture.HideRandomWords();
            }
        }
    }
}

