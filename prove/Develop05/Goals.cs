using System;

namespace EternalQuest
{
    abstract class Goal
    {
        public string Name { get; set; }
        public int Points { get; protected set; }
        public bool IsComplete { get; protected set; }

        public Goal(string name, int points)
        {
            Name = name;
            Points = points;
            IsComplete = false;
        }

        public abstract int RecordProgress();

        public abstract string GetStatus();

        public abstract string Serialize();

        public static Goal Deserialize(string data)
        {
            try
            {
                var parts = data.Split(':');
                if (parts.Length != 2)
                {
                    throw new FormatException("Invalid data format.");
                }

                var goalType = parts[0];
                var details = parts[1].Split(',');

                switch (goalType)
                {
                    case "SimpleGoal":
                        if (details.Length != 3) throw new FormatException("Invalid SimpleGoal format.");
                        return new SimpleGoal(details[0], int.Parse(details[1]), bool.Parse(details[2]));
                    case "EternalGoal":
                        if (details.Length != 3) throw new FormatException("Invalid EternalGoal format.");
                        return new EternalGoal(details[0], int.Parse(details[1]), int.Parse(details[2]));
                    case "ChecklistGoal":
                        if (details.Length != 5) throw new FormatException("Invalid ChecklistGoal format.");
                        return new ChecklistGoal(details[0], int.Parse(details[1]), int.Parse(details[2]), int.Parse(details[3]), int.Parse(details[4]));
                    default:
                        throw new Exception("Unknown goal type.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing data: {data}. Exception: {ex.Message}");
                throw;
            }
        }
    }
}
