public abstract class Activity
{
    private string _date;
    private int _lengthMinutes;

    public Activity(string date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    public int GetLengthMinutes()
    {
        return _lengthMinutes;
    }

    public string GetDate()
    {
        return _date;
    }

    public abstract double GetDistance();  // in miles
    public abstract double GetSpeed();     // in mph
    public abstract double GetPace();      // in min/mile

    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_lengthMinutes} min) - Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}
