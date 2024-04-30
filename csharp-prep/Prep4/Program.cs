using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int input;
        do
        {
            Console.Write("Enter number: ");
            input = Convert.ToInt32(Console.ReadLine());

            if(input !=0)
                numbers.Add(input);
        } while (input !=0);

        if (numbers.Count > 0)
        {
            int sum = numbers.Sum();
            double average = numbers.Average();
            int max = numbers.Max();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");
            
            List<int> positiveNumbers = numbers.Where(n => n > 0).ToList();
            int smallestPositive = positiveNumbers.Count() > 0 ? positiveNumbers.Min() : 0;
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");

            List<int> sortedNumbers = numbers.OrderBy (n=> n). ToList();
            Console.WriteLine("The sorted list is:");
            foreach (int num in sortedNumbers)
            {
                Console.WriteLine(num);
            }
        }
        else
        {
            Console.WriteLine("No numbers entered.");
        }
    
    }
}