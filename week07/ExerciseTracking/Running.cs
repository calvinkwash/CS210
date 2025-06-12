public class Running : Activity
{
    private double _distance;

    public Running(string date, int lengthMinutes, double distance) : base(date, lengthMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed()
    {
        return (_distance / GetLengthMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthMinutes() / _distance;
    }
}
