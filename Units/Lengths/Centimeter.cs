namespace Extender.Units.Lengths;

/// <summary>
/// Helper class for storing and converting a length/distance in centimeters.
/// </summary>
public sealed class Centimeter : Length
{
    /// <summary>
    /// Gets information pertaining to the units of this Length.
    /// </summary>
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("Centimeter", "cm", centimeters => centimeters * 0.01d, meters => meters / 0.01d);
        }
    }

    public Centimeter() { }

    public Centimeter(double value) { Value = value; }

    public Centimeter(int value) { Value = value; }

    public Centimeter(Length value) { SiValue = value.SiValue; }

    public static implicit operator Meter(Centimeter      x) { return new Meter(x); }
    public static implicit operator Kilometer(Centimeter  x) { return new Kilometer(x); }
    public static implicit operator Millimeter(Centimeter x) { return new Millimeter(x); }
    public static implicit operator Micron(Centimeter     x) { return new Micron(x); }
    public static explicit operator Inch(Centimeter       x) { return new Inch(x); }
    public static explicit operator Thou(Centimeter       x) { return new Thou(x); }
    public static explicit operator Foot(Centimeter       x) { return new Foot(x); }
    public static explicit operator Mile(Centimeter       x) { return new Mile(x); }
    public static explicit operator Yard(Centimeter       x) { return new Yard(x); }
}