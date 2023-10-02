namespace Extender.Units.Lengths;

/// <summary>
/// Helper class for storing and converting a length/distance in inches.
/// </summary>
public sealed class Inch : Length
{
    /// <summary>
    /// Gets information pertaining to the units of this Length.
    /// </summary>
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("inch", "in", inches => inches * 0.0254d, meters => meters / 0.0254d);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Inch() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Inch(double value) { Value = value; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Inch(int value) { Value = value; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Inch(Length value) { SiValue = value.SiValue; }

    public static explicit operator Kilometer(Inch  x) { return new Kilometer(x); }
    public static explicit operator Centimeter(Inch x) { return new Centimeter(x); }
    public static explicit operator Millimeter(Inch x) { return new Millimeter(x); }
    public static explicit operator Meter(Inch      x) { return new Meter(x); }
    public static explicit operator Micron(Inch     x) { return new Micron(x); }
    public static implicit operator Mile(Inch       x) { return new Mile(x); }
    public static implicit operator Thou(Inch       x) { return new Thou(x); }
    public static implicit operator Yard(Inch       x) { return new Yard(x); }
    public static implicit operator Foot(Inch       x) { return new Foot(x); }
}