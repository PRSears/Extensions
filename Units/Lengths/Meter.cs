namespace Extender.Units.Lengths;

/// <summary>
/// Helper class for storing and converting a length/distance in meters.
/// </summary>
public sealed class Meter : Length
{
    /// <summary>
    /// Gets information pertaining to the units of this Length.
    /// </summary>
    public override UnitInfo Unit
    {
        get { return new UnitInfo("meter", "m", si => si, meters => meters); }
    }

    /// <summary>
    /// 
    /// </summary>
    public Meter() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Meter(double value) { Value = value; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Meter(int value) { Value = value; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Meter(Length value) { SiValue = value.SiValue; }

    public static implicit operator Kilometer(Meter  x) { return new Kilometer(x); }
    public static implicit operator Centimeter(Meter x) { return new Centimeter(x); }
    public static implicit operator Millimeter(Meter x) { return new Millimeter(x); }
    public static implicit operator Micron(Meter     x) { return new Micron(x); }
    public static explicit operator Inch(Meter       x) { return new Inch(x); }
    public static explicit operator Thou(Meter       x) { return new Thou(x); }
    public static explicit operator Foot(Meter       x) { return new Foot(x); }
    public static explicit operator Mile(Meter       x) { return new Mile(x); }
    public static explicit operator Yard(Meter       x) { return new Yard(x); }
}