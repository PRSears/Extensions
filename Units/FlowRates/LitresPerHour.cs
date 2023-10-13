namespace Extender.Units.FlowRates;

public sealed class LitresPerHour : FlowRate
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
                ("litres per hour", "L/h", to => to * 2.7777777777777776e-7, from => from * 3.6e6);
        }
    }

    public LitresPerHour() { }
    public LitresPerHour(double   value) { Value   = value; }
    public LitresPerHour(int      value) { Value   = value; }
    public LitresPerHour(long     value) { Value   = value; }
    public LitresPerHour(FlowRate value) { SiValue = value.SiValue; }

    public static implicit operator CubicFeetPerMinute(LitresPerHour x)
    {
        return new CubicFeetPerMinute(x);
    }

    public static implicit operator CubicFeetPerSecond(LitresPerHour x)
    {
        return new CubicFeetPerSecond(x);
    }

    public static implicit operator CubicMetresPerSecond(LitresPerHour x)
    {
        return new CubicMetresPerSecond(x);
    }

    public static implicit operator GallonsPerMinute(LitresPerHour x)
    {
        return new GallonsPerMinute(x);
    }

    public static implicit operator LitresPerMinute(LitresPerHour x)
    {
        return new LitresPerMinute(x);
    }

    public static implicit operator LitresPerSecond(LitresPerHour x)
    {
        return new LitresPerSecond(x);
    }
}