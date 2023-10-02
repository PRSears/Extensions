namespace Extender.Units.Masses;

/// <summary>
/// 
/// </summary>
public sealed class Kilogram : Mass
{
    /// <summary>
    /// Gets information pertaining to the units of this Measure.
    /// </summary>
    public override UnitInfo Unit
    {
        get { return new UnitInfo("kilogram", "kg", si => si, kilograms => kilograms); }
    }

    /// <summary>
    /// 
    /// </summary>
    public Kilogram() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Kilogram(double value) { Value = value; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public Kilogram(Mass value) { SiValue = value.SiValue; }

    #region //Operator overloads

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static implicit operator Gram(Kilogram x) { return new Gram(x); }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static implicit operator MetricTonne(Kilogram x) { return new MetricTonne(x); }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static implicit operator Milligram(Kilogram x) { return new Milligram(x); }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static implicit operator Ounce(Kilogram x) { return new Ounce(x); }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static implicit operator Pound(Kilogram x) { return new Pound(x); }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static implicit operator Slug(Kilogram x) { return new Slug(x); }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static implicit operator SolarMass(Kilogram x) { return new SolarMass(x); }

    #endregion
}