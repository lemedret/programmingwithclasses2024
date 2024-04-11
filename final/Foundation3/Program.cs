using System;

public class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsUSAddress()
    {
        return country == "USA";
    }

    public string GetAddressDetails()
    {
        return $"{street}, {city}, {state}, {country}";
    }
}

public class Event
{
    private string title;
    private string description;
    private string date;
    private string time;
    private Address address;

    public Event(string title, string description, string date, string time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string GetEventDetails()
    {
        return $"Event Title: {title}\nDescription: {description}\nDate: {date}\nTime: {time}\nAddress: {address.GetAddressDetails()}";
    }

    public virtual string GetEventSpecificDetails()
    {
        return ""; // Base class has no specific details
    }

    public virtual string GenerateMarketingMessage()
    {
        return "Standard details - " + GetEventDetails();
    }
}

public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetEventSpecificDetails()
    {
        return $"Speaker: {speaker}\nCapacity: {capacity} attendees";
    }

    public override string GenerateMarketingMessage()
    {
        return "Full details - " + GetEventDetails() + "\n" + GetEventSpecificDetails();
    }
}

public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetEventSpecificDetails()
    {
        return "RSVP Email: " + rsvpEmail;
    }

    public override string GenerateMarketingMessage()
    {
        return "Full details - " + GetEventDetails() + "\n" + GetEventSpecificDetails();
    }
}

public class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GetEventSpecificDetails()
    {
        return "Weather Forecast: " + weatherForecast;
    }

    public override string GenerateMarketingMessage()
    {
        return "Full details - " + GetEventDetails() + "\n" + GetEventSpecificDetails();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Cityville", "CA", "USA");
        Address address2 = new Address("456 Elm St", "Townsville", "ON", "Canada");

        Event event1 = new Event("Lecture Event", "Exciting lecture", "2023-10-20", "10:00 AM", address1);
        Lecture lecture1 = new Lecture("Lecture Event", "Exciting lecture", "2023-10-20", "10:00 AM", address1, "John Smith", 50);

        Event event2 = new Event("Reception Event", "Networking reception", "2023-10-22", "6:00 PM", address2);
        Reception reception1 = new Reception("Reception Event", "Networking reception", "2023-10-22", "6:00 PM", address2, "rsvp@example.com");

        Event event3 = new Event("Outdoor Gathering", "Picnic in the park", "2023-10-25", "12:00 PM", address1);
        OutdoorGathering outdoorGathering1 = new OutdoorGathering("Outdoor Gathering", "Picnic in the park", "2023-10-25", "12:00 PM", address1, "Sunny");

        Event[] events = { event1, lecture1, event2, reception1, event3, outdoorGathering1 };

        foreach (Event ev in events)
        {
            Console.WriteLine(ev.GenerateMarketingMessage() + "\n\n");
        }
    }
}
