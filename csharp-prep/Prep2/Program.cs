using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your grade percentage:");
        double gradePercentage = Convert.ToDouble(Console.ReadLine());

        char letter;
        string sign = "";

        if (gradePercentage >= 90)
        {
            letter = 'A';
        }
        else if (gradePercentage >= 80)
        {
            letter = 'B';
        }
        else if (gradePercentage >= 70)
        {
            letter = 'C';
        }
        else if (gradePercentage >= 60)
        {
            letter = 'D';
        }
        else
        {
            letter = 'F';
        }

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't worry, keep working hard for next time.");
        }

        // Stretch Challenge: Determine the sign
        int lastDigit = (int)(gradePercentage % 10);

        if (letter == 'A' && lastDigit >= 7)
        {
            sign = "+";
        }
        else if (letter == 'B' && lastDigit >= 7)
        {
            sign = "+";
        }
        else if (letter == 'A' && lastDigit < 3)
        {
            letter = 'A'; // Handling case of A-
            sign = "-";
        }
        else if (letter == 'B' && lastDigit < 3)
        {
            letter = 'B'; // Handling case of B-
            sign = "-";
        }

        // Print the grade with sign
        Console.WriteLine("Your grade: " + letter + sign);
    }
}
