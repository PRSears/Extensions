namespace Extender.Units.FlowRates;

public sealed class GallonsPerMinute : FlowRate
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
            (
                "gallons per minute",
                "gal/m",
                to => to     * 6.309019640343866e-5,
                from => from * 1.5850323140625002e4
            );
        }
    }

    public GallonsPerMinute() { }
    public GallonsPerMinute(double   value) { Value   = value; }
    public GallonsPerMinute(int      value) { Value   = value; }
    public GallonsPerMinute(long     value) { Value   = value; }
    public GallonsPerMinute(FlowRate value) { SiValue = value.SiValue; }

    public static implicit operator CubicFeetPerMinute(GallonsPerMinute x)
    {
        return new CubicFeetPerMinute(x);
    }

    public static implicit operator CubicFeetPerSecond(GallonsPerMinute x)
    {
        return new CubicFeetPerSecond(x);
    }

    public static implicit operator CubicMetresPerSecond(GallonsPerMinute x)
    {
        return new CubicMetresPerSecond(x);
    }

    public static implicit operator LitresPerMinute(GallonsPerMinute x)
    {
        return new LitresPerMinute(x);
    }

    public static implicit operator LitresPerSecond(GallonsPerMinute x)
    {
        return new LitresPerSecond(x);
    }
}