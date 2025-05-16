// ✅ All using directives go at the top
using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            PromptGenerator promptGenerator = new PromptGenerator();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\nJournal Menu:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Quit");

                Console.Write("Enter your choice (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine($"\nPrompt: {prompt}");
                        Console.Write("Your response: ");
                        string response = Console.ReadLine();
                        string date = DateTime.Now.ToString("yyyy-MM-dd");
                        journal.AddEntry(new Entry(date, prompt, response));
                        break;

                    case "2":
                        journal.DisplayEntries();
                        break;

                    case "3":
                        Console.Write("Enter filename to save to: ");
                        string saveFile = Console.ReadLine();
                        journal.SaveToFile(saveFile);
                        break;

                    case "4":
                        Console.Write("Enter filename to load from: ");
                        string loadFile = Console.ReadLine();
                        journal.LoadFromFile(loadFile);
                        break;

                    case "5":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }

    class Entry
    {
        public string Date { get; }
        public string Prompt { get; }
        public string Response { get; }

        public Entry(string date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }

        public override string ToString()
        {
            return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
        }
    }

    class Journal
    {
        private List<Entry> entries = new List<Entry>();

        public void AddEntry(Entry entry)
        {
            entries.Add(entry);
        }

        public void DisplayEntries()
        {
            Console.WriteLine("\nJournal Entries:");
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }

            Console.WriteLine("Journal saved successfully.");
        }

        public void LoadFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                entries.Clear();
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        entries.Add(new Entry(parts[0], parts[1], parts[2]));
                    }
                }

                Console.WriteLine("Journal loaded successfully.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }

    class PromptGenerator
    {
        private List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        private Random rand = new Random();

        public string GetRandomPrompt()
        {
            int index = rand.Next(prompts.Count);
            return prompts[index];
        }
    }
}
