using System;

namespace FitnessCenterApp
{
    // Base Activity class
    public abstract class Activity
    {
        protected DateTime _date;
        protected int _length;

        public Activity(DateTime date, int length)
        {
            _date = date;
            _length = length;
        }

        // Virtual methods to be overridden by derived classes
        public virtual double GetDistance()
        {
            return 0;
        }

        public virtual double GetSpeed()
        {
            return 0;
        }

        public virtual double GetPace()
        {
            return 0;
        }

        public virtual string GetActivityType()
        {
            return "Activity";
        }

        // Get summary method
        public virtual string GetSummary()
        {
            return $"{_date:dd MMM yyyy} {GetActivityType()}({_length} min)";
        }
    }

    // Running class derived from Activity
    public class Running : Activity
    {
        private double _distance;

        public Running(DateTime date, int length, double distance) : base(date, length)
        {
            _distance = distance;
        }

        // Override methods
        public override double GetDistance()
        {
            return _distance;
        }

        public override double GetSpeed()
        {
            return _distance / (_length / 60.0) * 60 / 1.609; // speed in km/h
        }

        public override double GetPace()
        {
            return (_length / 60.0) / (_distance / 1.609); // pace in min/mile
        }

        public override string GetActivityType()
        {
            return "Running";
        }

        // Override GetSummary method to include running-specific information
        public override string GetSummary()
        {
            return $"{base.GetSummary()} - Distance {_distance:F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
        }
    }

    // Stationary Bicycle class derived from Activity
    public class StationaryBicycle : Activity
    {
        private double _speed;

        public StationaryBicycle(DateTime date, int length, double speed) : base(date, length)
        {
            _speed = speed;
        }

        // Override methods
        public override double GetSpeed()
        {
            return _speed;
        }

        public override double GetPace()
        {
            return 60.0 / _speed; // pace in min/km
        }

        public override string GetActivityType()
        {
            return "Stationary Bicycle";
        }

        // Override GetSummary method to include stationary bicycle-specific information
        public override string GetSummary()
        {
            return $"{base.GetSummary()} - Speed {_speed:F1} km/h, Pace: {GetPace():F1} min per km";
        }
    }

    // Swimming class derived from Activity
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, int length, int laps) : base(date, length)
        {
            _laps = laps;
        }

        // Override methods
        public override double GetDistance()
        {
            return _laps * 50 / 1000.0; // distance in kilometers
        }

        public override double GetSpeed()
        {
            return GetDistance() / (_length / 60.0) * 60 / 1.609; // speed in km/h
        }

        public override double GetPace()
        {
            return (_length / 60.0) / GetDistance(); // pace in min/km
        }

        public override string GetActivityType()
        {
            return "Swimming";
        }
    }
}
