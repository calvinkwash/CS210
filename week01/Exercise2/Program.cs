using System;

class Program
{
    static void Main()
    {
        // Ask user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int gradePercentage = int.Parse(input);

        string letter = "";
        string sign = "";

        // Determine the letter grade
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign (+ or -)
        int lastDigit = gradePercentage % 10;
        bool isExceptional = letter == "A" || letter == "F";

        if (!isExceptional)
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A" && gradePercentage < 93)
        {
            // A- is allowed, but no A+
            sign = "-";
        }

        // Display the full grade
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Determine and print pass/fail message
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class.");
        }
        else
        {
            Console.WriteLine("Don't give up! Better luck next time.");
        }
    }
}
