using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your grade percentage: ");
        string answer = Console.ReadLine();
        int gradePercentage = int.Parse(answer);

        char letter;
        if (gradePercentage >= 90)
        {
            letter = 'A';
        }
        else if (gradePercentage >=80)
        {
            letter = 'B';
        }
        else if (gradePercentage >=70)
        {
            letter = 'C';
        }
        else if (gradePercentage >=60)
        {
            letter = 'D';
        }
        else
        {
            letter = 'F';
        }
        bool passed = gradePercentage >= 70;

        Console.WriteLine($"Your letter grade is: {letter}");

        if (passed)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep working hard! You'll do better next time.");
        }

        char sign = DetermineSign(gradePercentage, letter);

        if (sign !='\0')
        {
            Console.WriteLine($"Your letter grade with sign is: {letter}{sign}");
        }
    }
    static char DetermineSign(int percentage, char grade)
{
    if (grade != 'A' && grade != 'F')
    {
        int lastDigit = percentage % 10;
        if (lastDigit >= 7)
        {
            return '+';
        }
        else if (lastDigit < 3)
        {
            return '-';
        }
    }
    else if (grade == 'A')
    {
        if (percentage == 100)
        {
            return '-';
        }
        else if (percentage >= 97)
        {
            return '+';
        }
    }

    return '\0';
}
}