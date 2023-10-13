namespace Extender.Units.FlowRates;

public sealed class CubicFeetPerSecond : FlowRate
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
            (
                "cubic feet per second",
                "ft\u00b3/s",
                to => to     * 2.8316831998814504e-2 ,
                from => from * 3.531468492103444e1
            );
        }
    }

    public CubicFeetPerSecond() { }
    public CubicFeetPerSecond(double   value) { Value   = value; }
    public CubicFeetPerSecond(int      value) { Value   = value; }
    public CubicFeetPerSecond(long     value) { Value   = value; }
    public CubicFeetPerSecond(FlowRate value) { SiValue = value.SiValue; }

    public static implicit operator CubicFeetPerMinute(CubicFeetPerSecond x)
    {
        return new CubicFeetPerMinute(x);
    }

    public static implicit operator CubicMetresPerSecond(CubicFeetPerSecond x)
    {
        return new CubicMetresPerSecond(x);
    }

    public static implicit operator GallonsPerMinute(CubicFeetPerSecond x)
    {
        return new GallonsPerMinute(x);
    }

    public static implicit operator LitresPerMinute(CubicFeetPerSecond x)
    {
        return new LitresPerMinute(x);
    }

    public static implicit operator LitresPerSecond(CubicFeetPerSecond x)
    {
        return new LitresPerSecond(x);
    }
}