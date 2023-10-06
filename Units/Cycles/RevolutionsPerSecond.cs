namespace Extender.Units.Cycles;

public sealed class RevolutionsPerSecond : Frequency
{
    public override UnitInfo Unit
    {
        get { return new UnitInfo("revolutions per second", "rps", to => to, from => from); }
    }

    public RevolutionsPerSecond() { }
    public RevolutionsPerSecond(double    value) { Value   = value; }
    public RevolutionsPerSecond(int       value) { Value   = value; }
    public RevolutionsPerSecond(Frequency value) { SiValue = value.SiValue; }

    public static implicit operator RadiansPerSecond(RevolutionsPerSecond x)
    {
        return new RadiansPerSecond(x);
    }

    public static implicit operator RevolutionsPerMinute(RevolutionsPerSecond x)
    {
        return new RevolutionsPerMinute(x);
    }

    public static implicit operator RevolutionsPerHour(RevolutionsPerSecond x)
    {
        return new RevolutionsPerHour(x);
    }

    public static implicit operator RevolutionsPerDay(RevolutionsPerSecond x)
    {
        return new RevolutionsPerDay(x);
    }

    public static implicit operator RevolutionsPerYear(RevolutionsPerSecond x)
    {
        return new RevolutionsPerYear(x);
    }

    public static explicit operator Hertz(RevolutionsPerSecond x) { return new Hertz(x); }

    public static explicit operator KiloHertz(RevolutionsPerSecond x) { return new KiloHertz(x); }

    public static explicit operator MegaHertz(RevolutionsPerSecond x) { return new MegaHertz(x); }

    public static explicit operator GigaHertz(RevolutionsPerSecond x) { return new GigaHertz(x); }

    public static explicit operator TeraHertz(RevolutionsPerSecond x) { return new TeraHertz(x); }
}