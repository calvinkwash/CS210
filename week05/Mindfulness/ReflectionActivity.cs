using System;
using System.Collections.Generic;

class ReflectionActivity : ActivityBase
{
    private List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
        : base("Reflection Activity",
               "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    { }

    protected override void ExecuteActivity()
    {
        var rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("When you have an experience in mind, press enter.");
        Console.ReadLine();

        int duration = GetDuration();
        int elapsed = 0;

        while (elapsed < duration)
        {
            string q = _questions[rand.Next(_questions.Count)];
            Console.Write($"> {q} ");
            PauseWithSpinner(10);
            elapsed += 10;
        }
    }

    private int GetDuration()
    {
        var f = typeof(ActivityBase)
                .GetField("_duration", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        return (int)f.GetValue(this);
    }
}
