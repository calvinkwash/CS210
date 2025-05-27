using System;
using System.Collections.Generic;
using System.IO;

// Entry class definition
public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine();
    }
}

// Journal class definition
public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            entry.Display();
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
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entry entry = new Entry(parts[1], parts[2], parts[0]);
                entries.Add(entry);
            }
        }
    }
}

// Main method to run the program
public class Program
{
    public static void Main()
    {
        Journal journal = new Journal();

        // Adding sample entries
        journal.AddEntry(new Entry("What did you learn today?", "I learned about file I/O in C#.", DateTime.Now.ToShortDateString()));
        journal.AddEntry(new Entry("What made you smile today?", "Seeing my dog play in the yard.", DateTime.Now.ToShortDateString()));

        // Displaying journal
        Console.WriteLine("Journal Entries:");
        journal.DisplayJournal();

        // Saving to file
        string filename = "journal.txt";
        journal.SaveToFile(filename);
        Console.WriteLine($"Journal saved to {filename}");

        // Loading from file
        Journal loadedJournal = new Journal();
        loadedJournal.LoadFromFile(filename);
        Console.WriteLine("\nLoaded Journal Entries:");
        loadedJournal.DisplayJournal();
    }
}
