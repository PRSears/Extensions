namespace Extender.Units.FlowRates;

public sealed class LitresPerSecond : FlowRate
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo("litres per second", "L/s", to => to * 1e-3, from => from * 1e3);
        }
    }

    public LitresPerSecond() { }
    public LitresPerSecond(double   value) { Value   = value; }
    public LitresPerSecond(int      value) { Value   = value; }
    public LitresPerSecond(long     value) { Value   = value; }
    public LitresPerSecond(FlowRate value) { SiValue = value.SiValue; }

    public static implicit operator CubicFeetPerMinute(LitresPerSecond x)
    {
        return new CubicFeetPerMinute(x);
    }

    public static implicit operator CubicFeetPerSecond(LitresPerSecond x)
    {
        return new CubicFeetPerSecond(x);
    }

    public static implicit operator CubicMetresPerSecond(LitresPerSecond x)
    {
        return new CubicMetresPerSecond(x);
    }

    public static implicit operator GallonsPerMinute(LitresPerSecond x)
    {
        return new GallonsPerMinute(x);
    }

    public static implicit operator LitresPerMinute(LitresPerSecond x)
    {
        return new LitresPerMinute(x);
    }
}