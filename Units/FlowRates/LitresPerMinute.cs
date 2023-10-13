namespace Extender.Units.FlowRates;

public sealed class LitresPerMinute : FlowRate
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("litre per minute", "L/m", to => to * 1.6666666666666667e-5, from => from * 6e4);
        }
    }

    public LitresPerMinute() { }
    public LitresPerMinute(double   value) { Value   = value; }
    public LitresPerMinute(int      value) { Value   = value; }
    public LitresPerMinute(long     value) { Value   = value; }
    public LitresPerMinute(FlowRate value) { SiValue = value.SiValue; }

    public static implicit operator CubicFeetPerMinute(LitresPerMinute x)
    {
        return new CubicFeetPerMinute(x);
    }

    public static implicit operator CubicFeetPerSecond(LitresPerMinute x)
    {
        return new CubicFeetPerSecond(x);
    }

    public static implicit operator CubicMetresPerSecond(LitresPerMinute x)
    {
        return new CubicMetresPerSecond(x);
    }

    public static implicit operator GallonsPerMinute(LitresPerMinute x)
    {
        return new GallonsPerMinute(x);
    }

    public static implicit operator LitresPerSecond(LitresPerMinute x)
    {
        return new LitresPerSecond(x);
    }
}