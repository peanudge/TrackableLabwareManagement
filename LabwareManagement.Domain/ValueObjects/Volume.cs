using LabwareManagement.Domain;

namespace LabwareManagementa.Domain;

public record class Volume
{
    private const string DefaultUnit = "MICROLITER";
    public static Volume FromString(string text, string unit = DefaultUnit) => new Volume(double.Parse(text), unit);
    public static Volume FromDouble(double value, string unit = DefaultUnit) => new Volume(value, unit);

    public double Value { get; }
    public string UnitCode { get; }

    protected Volume(double value, string unitCode = DefaultUnit)
    {
        Value = value;
        UnitCode = unitCode;
    }

    public Volume Add(Volume summand)
    {
        if (UnitCode != summand.UnitCode)
        {
            throw new VolumeUnitMismatchException("Cannot sum volumes with difference units");
        }

        return new Volume(Value + summand.Value);
    }

    public Volume Substract(Volume subtrahend)
    {
        if (UnitCode != subtrahend.UnitCode)
        {
            throw new VolumeUnitMismatchException("Cannot subtract volumes with difference units");
        }

        return new Volume(Value - subtrahend.Value);
    }

    public static Volume operator +(Volume summand1, Volume summand2) => summand1.Add(summand2);
    public static Volume operator -(Volume minuend, Volume subtrahend) => minuend.Substract(subtrahend);
}

public record class LiquidVolume : Volume
{
    private const int ONE_MILIITER = 1000;
    public static Volume FromMicroliter(double microliter) => new LiquidVolume(microliter);
    public static Volume FromMililiter(double mililiter) => new LiquidVolume(mililiter * ONE_MILIITER);

    protected LiquidVolume(double microliter) : base(microliter)
    {
        if (microliter < 0)
        {
            throw new ArgumentException("LiquidVolume cannot be negative.", nameof(microliter));
        }

        if (double.Round(microliter, 2) != microliter)
        {
            throw new ArgumentOutOfRangeException(nameof(microliter), "Liquid Volume cannot have more than two decimals.");
        }
    }
}
