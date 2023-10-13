namespace Extender.Units.FlowRates;

public sealed class CubicFeetPerMinute : FlowRate
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
            (
                "cubic feet per minute",
                "cfm",
                to => to     * 4.719471999802417e-4,
                from => from * 2.118881095262066e3
            );
        }
    }

    public CubicFeetPerMinute() { }
    public CubicFeetPerMinute(double   value) { Value   = value; }
    public CubicFeetPerMinute(int      value) { Value   = value; }
    public CubicFeetPerMinute(long     value) { Value   = value; }
    public CubicFeetPerMinute(FlowRate value) { SiValue = value.SiValue; }

    public static implicit operator CubicFeetPerSecond(CubicFeetPerMinute x)
    {
        return new CubicFeetPerSecond(x);
    }

    public static implicit operator CubicMetresPerSecond(CubicFeetPerMinute x)
    {
        return new CubicMetresPerSecond(x);
    }

    public static implicit operator GallonsPerMinute(CubicFeetPerMinute x)
    {
        return new GallonsPerMinute(x);
    }

    public static implicit operator LitresPerMinute(CubicFeetPerMinute x)
    {
        return new LitresPerMinute(x);
    }

    public static implicit operator LitresPerSecond(CubicFeetPerMinute x)
    {
        return new LitresPerSecond(x);
    }
}