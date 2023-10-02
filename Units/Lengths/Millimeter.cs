namespace Extender.Units.Lengths;

/// <summary>
/// Helper class for storing and converting a length/distance in millimeters.
/// </summary>
public sealed class Millimeter : Length
{
    /// <summary>
    /// Gets information pertaining to the units of this Length.
    /// </summary>
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
            (
                "Millimeter",
                "mm",
                millimeters => millimeters * 0.001d,
                meters => meters           / 0.001d
            );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Millimeter() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Millimeter(double value) { Value = value; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Millimeter(int value) { Value = value; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Millimeter(Length value) { SiValue = value.SiValue; }

    public static implicit operator Meter(Millimeter      x) { return new Meter(x); }
    public static implicit operator Kilometer(Millimeter  x) { return new Kilometer(x); }
    public static implicit operator Centimeter(Millimeter x) { return new Centimeter(x); }
    public static implicit operator Micron(Millimeter     x) { return new Micron(x); }
    public static explicit operator Inch(Millimeter       x) { return new Inch(x); }
    public static explicit operator Thou(Millimeter       x) { return new Thou(x); }
    public static explicit operator Foot(Millimeter       x) { return new Foot(x); }
    public static explicit operator Mile(Millimeter       x) { return new Mile(x); }
    public static explicit operator Yard(Millimeter       x) { return new Yard(x); }
}