namespace Extender.Units.FlowRates;

public sealed class CubicMetresPerSecond : FlowRate
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("cubic metres per second", "m\u00b3/s", to => to, from => from); }
    }

    public CubicMetresPerSecond() { }
    public CubicMetresPerSecond(double   value) { Value   = value; }
    public CubicMetresPerSecond(int      value) { Value   = value; }
    public CubicMetresPerSecond(long     value) { Value   = value; }
    public CubicMetresPerSecond(FlowRate value) { SiValue = value.SiValue; }

    public static implicit operator CubicFeetPerMinute(CubicMetresPerSecond x)
    {
        return new CubicFeetPerMinute(x);
    }

    public static implicit operator CubicFeetPerSecond(CubicMetresPerSecond x)
    {
        return new CubicFeetPerSecond(x);
    }

    public static implicit operator GallonsPerMinute(CubicMetresPerSecond x)
    {
        return new GallonsPerMinute(x);
    }

    public static implicit operator LitresPerMinute(CubicMetresPerSecond x)
    {
        return new LitresPerMinute(x);
    }

    public static implicit operator LitresPerSecond(CubicMetresPerSecond x)
    {
        return new LitresPerSecond(x);
    }
}