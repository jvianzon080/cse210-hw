using System;
using System.Collections.Generic;

public abstract class Activity
{
    public DateTime Date { get; set; }
    public int LengthInMinutes { get; set; }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public virtual string GetSummary()
    {
        return $"{Date.ToShortDateString()} {GetType().Name} ({LengthInMinutes} min): Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}

public class Running : Activity
{
    public double Distance { get; set; } // *miles

    public override double GetDistance() => Distance;
    public override double GetSpeed() => (Distance / LengthInMinutes) * 60;
    public override double GetPace() => LengthInMinutes / Distance;
}

public class Cycling : Activity
{
    public double Speed { get; set; } // *mph

    public override double GetDistance() => (Speed * LengthInMinutes) / 60;
    public override double GetSpeed() => Speed;
    public override double GetPace() => 60 / Speed;
}

public class Swimming : Activity
{
    public int Laps { get; set; } // each lap is 50 meters
    private const double LapLengthInMiles = 50 / 1609.34;

    public override double GetDistance() => Laps * LapLengthInMiles;
    public override double GetSpeed() => (GetDistance() / LengthInMinutes) * 60;
    public override double GetPace() => LengthInMinutes / GetDistance();
}

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<Activity>
        {
            new Running { Date = new DateTime(2024, 06, 05), LengthInMinutes = 35, Distance = 2.5 },
            new Cycling { Date = new DateTime(2024, 06, 05), LengthInMinutes = 30, Speed = 12.0 },
            new Swimming { Date = new DateTime(2024, 06, 05), LengthInMinutes = 35, Laps = 30 }
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}