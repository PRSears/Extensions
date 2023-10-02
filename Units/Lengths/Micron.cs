namespace Extender.Units.Lengths;

/// <summary>
/// Helper class for storing and converting a length/distance in microns.
/// </summary>
public sealed class Micron : Length
{
    /// <summary>
    /// Gets information pertaining to the units of this Length.
    /// </summary>
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("Micron", "\u00B5m", microns => microns * 0.000001d, meters => meters / 0.000001d);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Micron() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Micron(double value) { Value = value; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Micron(int value) { Value = value; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Micron(Length value) { SiValue = value.SiValue; }

    public static implicit operator Meter(Micron      x) { return new Meter(x); }
    public static implicit operator Centimeter(Micron x) { return new Centimeter(x); }
    public static implicit operator Millimeter(Micron x) { return new Millimeter(x); }
    public static implicit operator Kilometer(Micron  x) { return new Kilometer(x); }
    public static explicit operator Inch(Micron       x) { return new Inch(x); }
    public static explicit operator Thou(Micron       x) { return new Thou(x); }
    public static explicit operator Foot(Micron       x) { return new Foot(x); }
    public static explicit operator Mile(Micron       x) { return new Mile(x); }
    public static explicit operator Yard(Micron       x) { return new Yard(x); }
}