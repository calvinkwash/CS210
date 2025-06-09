using System;
using System.Threading;

abstract class ActivityBase
{
    private string _name;
    private string _description;
    private int _duration; // in seconds

    protected ActivityBase(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Run()
    {
        Console.Clear();
        StartMessage();
        ExecuteActivity();
        EndMessage();
    }

    private void StartMessage()
    {
        Console.WriteLine($"### {_name} ###");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready...");
        PauseWithSpinner(3);
    }

    protected void PauseWithSpinner(int seconds)
    {
        var spinner = new[] { '|', '/', '-', '\\' };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write('\b');
        }
    }

    protected void PauseWithCountdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    private void EndMessage()
    {
        Console.WriteLine("\nWell done!");
        PauseWithSpinner(3);
        Console.WriteLine($"\nYou have completed {_name} for {_duration} seconds.");
        PauseWithSpinner(3);
    }

    protected abstract void ExecuteActivity();
}
