namespace Extender.Units.Lengths;

/// <summary>
/// Helper class for storing and converting a length/distance in miles.
/// </summary>
public sealed class Mile : Length
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
                "mile",
                "mi",
                miles => { return miles   * 1609.344d; },
                meters => { return meters / 1609.344d; }
            );
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Mile() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Mile(double value) { Value = value; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Mile(int value) { Value = value; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Mile(Length value) { SiValue = value.SiValue; }

    public static explicit operator Kilometer(Mile  x) { return new Kilometer(x); }
    public static explicit operator Centimeter(Mile x) { return new Centimeter(x); }
    public static explicit operator Millimeter(Mile x) { return new Millimeter(x); }
    public static explicit operator Meter(Mile      x) { return new Meter(x); }
    public static explicit operator Micron(Mile     x) { return new Micron(x); }
    public static implicit operator Inch(Mile       x) { return new Inch(x); }
    public static implicit operator Thou(Mile       x) { return new Thou(x); }
    public static implicit operator Yard(Mile       x) { return new Yard(x); }
    public static implicit operator Foot(Mile       x) { return new Foot(x); }
}