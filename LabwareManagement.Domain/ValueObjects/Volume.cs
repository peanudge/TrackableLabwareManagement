namespace LabwareManagementa.Domain;

public record class Volume
{
    public double Value { get; }
    public Volume(double value)
    {
        Value = value;
    }

    public Volume Add(Volume summand) => new Volume(Value + summand.Value);
    public Volume Substract(Volume subtrahend) => new Volume(Value - subtrahend.Value);
    public static Volume operator +(Volume summand1, Volume summand2) => summand1.Add(summand2);
    public static Volume operator -(Volume minuend, Volume subtrahend) => minuend.Substract(subtrahend);
}

public record class LiquidVolume : Volume
{
    protected LiquidVolume(double value) : base(value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Price cannot be negative.", nameof(value));
        }
    }
}
