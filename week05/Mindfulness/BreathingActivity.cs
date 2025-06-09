using System;

class BreathingActivity : ActivityBase
{
    public BreathingActivity()
        : base("Breathing Activity",
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    protected override void ExecuteActivity()
    {
        int elapsed = 0;
        while (elapsed < GetDuration())
        {
            Console.Write("Breathe in... ");
            PauseWithCountdown(4);
            elapsed += 4;
            if (elapsed >= GetDuration()) break;
            
            Console.WriteLine();
            Console.Write("Breathe out... ");
            PauseWithCountdown(6);
            elapsed += 6;
            Console.WriteLine();
        }
    }

    private int GetDuration()
    {
        // relies on protected member somehow; using reflection isn't great, better to store
        // For simplicity, keep _duration protected in base or add getter; here, assume protected getter:
        var durationField = typeof(ActivityBase)
                            .GetField("_duration", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        return (int)durationField.GetValue(this);
    }
}
