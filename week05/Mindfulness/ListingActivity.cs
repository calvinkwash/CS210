using System;
using System.Collections.Generic;

class ListingActivity : ActivityBase
{
    private List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing Activity",
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    { }

    protected override void ExecuteActivity()
    {
        var rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Console.Write("You may begin listing in: ");
        PauseWithCountdown(5);
        Console.WriteLine();

        int duration = GetDuration();
        var items = new List<string>();
        var timer = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < timer)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
                items.Add(item);
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
    }

    private int GetDuration()
    {
        var f = typeof(ActivityBase)
                .GetField("_duration", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        return (int)f.GetValue(this);
    }
}
