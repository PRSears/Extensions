namespace Extender.Units.Masses;

/// <summary>
/// Helper class for storing an converting a mass in Slugs, assuming standard gravity.
/// </summary>
public sealed class Slug : Mass
{
    /// <summary>
    /// Gets information pertaining to the units of this Measure.
    /// </summary>
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("slugs", "sl", slugs => slugs * 14.593903d, kilograms => kilograms / 14.593903d);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Slug() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Slug(double value) { Value = value; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Slug(Mass value) { SiValue = value.SiValue; }

    #region //Operator overloads

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static implicit operator Gram(Slug x) { return new Gram(x); }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static implicit operator MetricTonne(Slug x) { return new MetricTonne(x); }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static implicit operator Milligram(Slug x) { return new Milligram(x); }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static implicit operator Ounce(Slug x) { return new Ounce(x); }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static implicit operator Pound(Slug x) { return new Pound(x); }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static implicit operator Kilogram(Slug x) { return new Kilogram(x); }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static implicit operator SolarMass(Slug x) { return new SolarMass(x); }

    #endregion
}