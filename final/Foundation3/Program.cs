using System;
using System.Collections.Generic;

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public string GetFullAddress()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}

public abstract class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Time { get; set; }
    public Address Address { get; set; }

    public virtual string GetStandardDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nAddress: {Address.GetFullAddress()}";
    }

    public abstract string GetFullDetails();
    public virtual string GetShortDescription()
    {
        return $"Type: {GetType().Name}\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
    }
}

public class Lecture : Event
{
    public string Speaker { get; set; }
    public int Capacity { get; set; }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }
}

public class Reception : Event
{
    public string RSVPEmail { get; set; }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Reception\nRSVP Email: {RSVPEmail}";
    }
}

public class OutdoorGathering : Event
{
    public string WeatherForecast { get; set; }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather Forecast: {WeatherForecast}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        var address1 = new Address { Street = "123 Apple St", City = "San Francisco", State = "CA", Country = "USA" };
        var address2 = new Address { Street = "456 Banana St", City = "Brooklyn", State = "NY", Country = "USA" };
        var address3 = new Address { Street = "789 Star Apple St", City = "Austin", State = "TX", Country = "USA" };

        var lecture = new Lecture
        {
            Title = "Advanced Fishing",
            Description = "Learn advanced fishing.",
            Date = new DateTime(2024, 06, 05),
            Time = "10:00 AM",
            Address = address1,
            Speaker = "Ezra Vianzon",
            Capacity = 100
        };

        var reception = new Reception
        {
            Title = "Career Workshop",
            Description = "An opportunity to network with industry professionals.",
            Date = new DateTime(2024, 06, 05),
            Time = "6:00 PM",
            Address = address2,
            RSVPEmail = "rsvp@example.com"
        };

        var outdoorGathering = new OutdoorGathering
        {
            Title = "Family Day",
            Description = "Join us for a family day in the park.",
            Date = new DateTime(2024, 06, 05),
            Time = "12:00 PM",
            Address = address3,
            WeatherForecast = "Cloudy"
        };

        var events = new List<Event> { lecture, reception, outdoorGathering };

        foreach (var eventItem in events)
        {
            Console.WriteLine(eventItem.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(eventItem.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(eventItem.GetShortDescription());
            Console.WriteLine();
        }
    }
}
