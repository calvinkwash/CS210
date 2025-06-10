using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public int TotalPoints { get; set; }
    public bool IsComplete { get; set; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        TotalPoints = 0;
        IsComplete = false;
    }

    public abstract void RecordEvent();
    public abstract void DisplayGoal();
    public abstract void SaveGoal(StreamWriter writer);
    public abstract void LoadGoal(StreamReader reader);
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            TotalPoints += Points;
            IsComplete = true;
        }
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"[ ] {Name}: {Description} - {TotalPoints} points");
    }

    public override void SaveGoal(StreamWriter writer)
    {
        writer.WriteLine($"SimpleGoal|{Name}|{Description}|{Points}|{TotalPoints}|{IsComplete}");
    }

    public override void LoadGoal(StreamReader reader)
    {
        var data = reader.ReadLine().Split('|');
        Name = data[1];
        Description = data[2];
        Points = int.Parse(data[3]);
        TotalPoints = int.Parse(data[4]);
        IsComplete = bool.Parse(data[5]);
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            TotalPoints += Points;
        }
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"[ ] {Name}: {Description} - {TotalPoints} points");
    }

    public override void SaveGoal(StreamWriter writer)
    {
        writer.WriteLine($"EternalGoal|{Name}|{Description}|{Points}|{TotalPoints}|{IsComplete}");
    }

    public override void LoadGoal(StreamReader reader)
    {
        var data = reader.ReadLine().Split('|');
        Name = data[1];
        Description = data[2];
        Points = int.Parse(data[3]);
        TotalPoints = int.Parse(data[4]);
        IsComplete = bool.Parse(data[5]);
    }
}

public class ChecklistGoal : Goal
{
    public int TimesCompleted { get; set; }
    public int Target { get; set; }
    public int Bonus { get; set; }

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        Target = target;
        Bonus = bonus;
        TimesCompleted = 0;
    }

    public override void RecordEvent()
    {
        if (TimesCompleted < Target)
        {
            TimesCompleted++;
            TotalPoints += Points;
            if (TimesCompleted == Target)
            {
                TotalPoints += Bonus;
                IsComplete = true;
            }
        }
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"[ ] {Name}: {Description} - {TimesCompleted}/{Target} completed - {TotalPoints} points");
    }

    public override void SaveGoal(StreamWriter writer)
    {
        writer.WriteLine($"ChecklistGoal|{Name}|{Description}|{Points}|{TotalPoints}|{IsComplete}|{TimesCompleted}|{Target}|{Bonus}");
    }

    public override void LoadGoal(StreamReader reader)
    {
        var data = reader.ReadLine().Split('|');
        Name = data[1];
        Description = data[2];
        Points = int.Parse(data[3]);
        TotalPoints = int.Parse(data[4]);
        IsComplete = bool.Parse(data[5]);
        TimesCompleted = int.Parse(data[6]);
        Target = int.Parse(data[7]);
        Bonus = int.Parse(data[8]);
    }
}

public class GoalManager
{
    public List<Goal> Goals { get; set; }
    public int TotalScore { get; set; }

    public GoalManager()
    {
        Goals = new List<Goal>();
        TotalScore = 0;
    }

    public void CreateGoal()
    {
        Console.WriteLine("Enter goal type (simple, eternal, checklist): ");
        string goalType = Console.ReadLine().ToLower();

        Console.WriteLine("Enter goal name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter goal description: ");
        string description = Console.ReadLine();

        Console.WriteLine("Enter points per completion: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;

        if (goalType == "simple")
        {
            goal = new SimpleGoal(name, description, points);
        }
        else if (goalType == "eternal")
        {
            goal = new EternalGoal(name, description, points);
        }
        else if (goalType == "checklist")
        {
            Console.WriteLine("Enter target number of completions: ");
            int target = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter bonus points upon completion: ");
            int bonus = int.Parse(Console.ReadLine());

            goal = new ChecklistGoal(name, description, points, target, bonus);
        }

        if (goal != null)
        {
            Goals.Add(goal);
            Console.WriteLine("Goal created successfully!");
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Enter goal index to record event: ");
        int index = int.Parse(Console.ReadLine());

        if (index >= 0 && index < Goals.Count)
        {
            Goals[index].RecordEvent();
            TotalScore += Goals[index].Points;
            Console.WriteLine("Event recorded successfully!");
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in Goals)
        {
            goal.DisplayGoal();
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var goal in Goals)
            {
                goal.SaveGoal(writer);
            }
            writer.WriteLine($"TotalScore|{TotalScore}");
        }
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals(string filename)
    {
        if (File.Exists(filename))
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var data = line.Split('|');
                    Goal goal = null;

                    if (data[0] == "SimpleGoal")
                    {
                        goal = new SimpleGoal(data[1], data[2], int.Parse(data[3]));
                    }
                    else if (data[0] == "EternalGoal")
                    {
                        goal = new EternalGoal(data[1], data[2], int.Parse(data[3]));
                    }
                    else if (data[0] == "ChecklistGoal")
                    {
                        goal = new ChecklistGoal(data[1], data[2], int.Parse(data[3]), int.Parse(data[7]), int.Parse(data[8]));
                    }

                    if (goal != null)
                    {
                        goal.LoadGoal(reader);
                        Goals.Add(goal);
                    }
                }
                TotalScore = int.Parse(reader.ReadLine().Split('|')[1]);
            }
            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("No saved data found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.LoadGoals("goals.txt");

        while (true)
        {
            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    manager.CreateGoal();

::contentReference[oaicite:0]{index=0}
 
