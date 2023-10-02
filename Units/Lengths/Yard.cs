namespace Extender.Units.Lengths;

/// <summary>
/// Helper class for storing and converting a length/distance in yards.
/// </summary>
public sealed class Yard : Length
{
    /// <summary>
    /// Gets information pertaining to the units of this Length.
    /// </summary>
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo("Yard", "yd", yards => yards * 0.9144d, meters => meters / 0.9144d);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Yard() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Yard(double value) { Value = value; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Yard(int value) { Value = value; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Yard(Length value) { SiValue = value.SiValue; }

    public static explicit operator Kilometer(Yard  x) { return new Kilometer(x); }
    public static explicit operator Centimeter(Yard x) { return new Centimeter(x); }
    public static explicit operator Millimeter(Yard x) { return new Millimeter(x); }
    public static explicit operator Meter(Yard      x) { return new Meter(x); }
    public static explicit operator Micron(Yard     x) { return new Micron(x); }
    public static implicit operator Inch(Yard       x) { return new Inch(x); }
    public static implicit operator Thou(Yard       x) { return new Thou(x); }
    public static implicit operator Foot(Yard       x) { return new Foot(x); }
    public static implicit operator Mile(Yard       x) { return new Mile(x); }
}