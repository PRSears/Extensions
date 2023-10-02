namespace Extender.Units.Lengths;

/// <summary>
/// Helper class for storing and converting a length/distance in feet.
/// </summary>
public sealed class Foot : Length
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
                "foot",
                "ft",
                feet => { return feet     * 0.3048d; },
                meters => { return meters / 0.3048d; }
            );
        }
    }

    public Foot() { }

    public Foot(double value) { Value = value; }

    public Foot(int value) { Value = value; }

    public Foot(Length value) { SiValue = value.SiValue; }

    public static explicit operator Kilometer(Foot  x) { return new Kilometer(x); }
    public static explicit operator Centimeter(Foot x) { return new Centimeter(x); }
    public static explicit operator Millimeter(Foot x) { return new Millimeter(x); }
    public static explicit operator Meter(Foot      x) { return new Meter(x); }
    public static explicit operator Micron(Foot     x) { return new Micron(x); }
    public static implicit operator Inch(Foot       x) { return new Inch(x); }
    public static implicit operator Thou(Foot       x) { return new Thou(x); }
    public static implicit operator Yard(Foot       x) { return new Yard(x); }
    public static implicit operator Mile(Foot       x) { return new Mile(x); }
}