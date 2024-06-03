using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class Program
    {
        static List<Goal> goals = new List<Goal>();
        static int totalPoints = 0;

        static void Main(string[] args)
        {
            LoadGoals();
            ShowMenu();
        }

        static void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Eternal Quest");
                Console.WriteLine("1. View Goals");
                Console.WriteLine("2. Add Goal");
                Console.WriteLine("3. Record Progress");
                Console.WriteLine("4. View Score");
                Console.WriteLine("5. Save and Exit");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ViewGoals();
                        break;
                    case "2":
                        AddGoal();
                        break;
                    case "3":
                        RecordProgress();
                        break;
                    case "4":
                        ViewScore();
                        break;
                    case "5":
                        SaveGoals();
                        return;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }

        static void ViewGoals()
        {
            Console.Clear();
            Console.WriteLine("Goals:");
            foreach (var goal in goals)
            {
                Console.WriteLine(goal.GetStatus());
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        static void AddGoal()
        {
            Console.Clear();
            Console.WriteLine("Select Goal Type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");

            var choice = Console.ReadLine();
            Console.WriteLine("Enter Goal Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Points:");
            if (!int.TryParse(Console.ReadLine(), out var points))
            {
                Console.WriteLine("Invalid points value. Goal not added.");
                return;
            }

            switch (choice)
            {
                case "1":
                    goals.Add(new SimpleGoal(name, points));
                    break;
                case "2":
                    goals.Add(new EternalGoal(name, points));
                    break;
                case "3":
                    Console.WriteLine("Enter Target Count:");
                    if (!int.TryParse(Console.ReadLine(), out var targetCount))
                    {
                        Console.WriteLine("Invalid target count value. Goal not added.");
                        return;
                    }
                    Console.WriteLine("Enter Bonus Points:");
                    if (!int.TryParse(Console.ReadLine(), out var bonusPoints))
                    {
                        Console.WriteLine("Invalid bonus points value. Goal not added.");
                        return;
                    }
                    goals.Add(new ChecklistGoal(name, points, targetCount, 0, bonusPoints));
                    break;
                default:
                    Console.WriteLine("Invalid choice, goal not added.");
                    break;
            }
        }

        static void RecordProgress()
        {
            Console.Clear();
            Console.WriteLine("Select Goal to Record Progress:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].Name}");
            }

            if (!int.TryParse(Console.ReadLine(), out var choice) || choice < 1 || choice > goals.Count)
            {
                Console.WriteLine("Invalid choice.");
            }
            else
            {
                var pointsEarned = goals[choice - 1].RecordProgress();
                totalPoints += pointsEarned;
                Console.WriteLine($"Progress recorded! Points earned: {pointsEarned}");
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        static void ViewScore()
        {
            Console.Clear();
            Console.WriteLine($"Total Points: {totalPoints}");
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        static void SaveGoals()
        {
            using (StreamWriter outputFile = new StreamWriter("goals.txt"))
            {
                foreach (var goal in goals)
                {
                    outputFile.WriteLine(goal.Serialize());
                }
                outputFile.WriteLine($"TotalPoints:{totalPoints}");
            }
        }

        static void LoadGoals()
        {
            if (File.Exists("goals.txt"))
            {
                var lines = File.ReadAllLines("goals.txt");
                foreach (var line in lines)
                {
                    if (line.StartsWith("TotalPoints:"))
                    {
                        totalPoints = int.Parse(line.Split(':')[1]);
                    }
                    else
                    {
                        try
                        {
                            goals.Add(Goal.Deserialize(line));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Failed to load goal: {ex.Message}");
                        }
                    }
                }
            }
        }
    }
}
