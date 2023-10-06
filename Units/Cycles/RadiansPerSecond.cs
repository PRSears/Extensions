namespace Extender.Units.Cycles;

public sealed class RadiansPerSecond : Frequency
{
    public override UnitInfo Unit
    {
        get
        {
            return new UnitInfo
            (
                "radians per second",
                "rad\u22c5s\u22121",
                to => to     / (2 * Math.PI), // converting to Hz
                from => from * (2 * Math.PI)
            );
        }
    }

    public RadiansPerSecond() { }
    public RadiansPerSecond(double    value) { Value   = value; }
    public RadiansPerSecond(int       value) { Value   = value; }
    public RadiansPerSecond(Frequency value) { SiValue = value.SiValue; }

    public static implicit operator RevolutionsPerSecond(RadiansPerSecond x)
    {
        return new RevolutionsPerSecond(x);
    }

    public static implicit operator RevolutionsPerMinute(RadiansPerSecond x)
    {
        return new RevolutionsPerMinute(x);
    }

    public static implicit operator RevolutionsPerHour(RadiansPerSecond x)
    {
        return new RevolutionsPerHour(x);
    }

    public static implicit operator RevolutionsPerDay(RadiansPerSecond x)
    {
        return new RevolutionsPerDay(x);
    }

    public static implicit operator RevolutionsPerYear(RadiansPerSecond x)
    {
        return new RevolutionsPerYear(x);
    }

    public static explicit operator Hertz(RadiansPerSecond x) { return new Hertz(x); }

    public static explicit operator KiloHertz(RadiansPerSecond x) { return new KiloHertz(x); }

    public static explicit operator MegaHertz(RadiansPerSecond x) { return new MegaHertz(x); }

    public static explicit operator GigaHertz(RadiansPerSecond x) { return new GigaHertz(x); }

    public static explicit operator TeraHertz(RadiansPerSecond x) { return new TeraHertz(x); }
}